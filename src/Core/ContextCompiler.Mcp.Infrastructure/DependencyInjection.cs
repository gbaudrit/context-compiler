using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.DependencyInjection;
using ContextCompiler.Abstractions.Workspace;
using ContextCompiler.Infrastructure.FileSystem;
using ContextCompiler.Mcp.Core.Views.Read;
using ContextCompiler.Mcp.Infrastructure.Extensions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;
using ContextCompiler.Modules.Abstractions.MCP;
using ContextCompiler.Modules.Loader;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

using ModelContextProtocol;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;

namespace ContextCompiler.Mcp.Infrastructure;

public static class DependencyInjection
{

    public static IContextCompilerBuilder AddMcpInfrastructure(this IContextCompilerBuilder contextCompilerBuilder, IConfiguration configuration, string[] args)
    {
        GlobalCommandLineOptions globals = CliCommandFactory.ParseGlobals(args);


        Assembly[] assemblies =
        [
            typeof(PhysicalFileSystem).Assembly
        ];

        if (globals.Debug)
        {
            _ = Debugger.Launch();
            Debugger.Break();
        }

        if (!string.IsNullOrEmpty(globals.InputPath))
        {
            if (globals.InputPath == ".")
            {
                globals = globals with { InputPath = Environment.CurrentDirectory };
            }
        }


        IWorkingFolder workingFolder = new WorkingFolder(globals.InputPath);
        _ = contextCompilerBuilder.Services.AddSingleton(workingFolder);

        IServiceCollection modulesLoaderServices = new ServiceCollection();
        _ = modulesLoaderServices.AddLogging(x => x.AddConfiguration(configuration.GetSection("Logging")).AddSimpleConsole(o => o.SingleLine = true))
                             .AddModulesLoaderServices()
                             .AddSingleton(workingFolder);

        IServiceProvider modulesLoaderServicesProvider = modulesLoaderServices.BuildServiceProvider();
        IModulesLoader modulesLoader = modulesLoaderServicesProvider.GetRequiredService<IModulesLoader>();

        IModulesLoadConfigLocator modulesLoadConfigLocator = modulesLoaderServicesProvider.GetRequiredService<IModulesLoadConfigLocator>();
        IModulesLoadConfigProvider modulesLoadConfigProvider = modulesLoaderServicesProvider.GetRequiredService<IModulesLoadConfigProvider>();
        //ISkillsLoadConfigProvider skillsLoadConfigProvider = modulesLoaderServicesProvider.GetRequiredService<ISkillsLoadConfigProvider>();

        //string? configPath = modulesLoadConfigLocator.Locate(globals.InputPath, "", "");
        //_ = modulesLoadConfigProvider.GetConfigOrDefault(configPath);
        //_ = skillsLoadConfigProvider.GetConfigOrDefault(configPath);

        IEnumerable<Type> moduleTypes = modulesLoader.LoadFromFolder(contextCompilerBuilder, Path.Combine(globals.InputPath, ".ctxc", "modules"), CancellationToken.None).Result;
        modulesLoader.LoadFromAssemblies(contextCompilerBuilder, assemblies).Wait();

        IMcpServerBuilder mcpServerBuilder = contextCompilerBuilder.Services.AddMcpServer()
                                                     .WithStdioServerTransport();

        foreach (Type moduleType in moduleTypes)
        {
            string moduleTypeName = moduleType.Name;
            if (moduleType.GetCustomAttribute<Modules.Abstractions.MCP.McpServerToolTypeAttribute>() != null)
            {
                _ = mcpServerBuilder.WithTools(moduleType);

                List<McpServerTool> mcpServerTools = [];
                IEnumerable<MethodInfo> methods = moduleType.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    Modules.Abstractions.MCP.McpServerToolAttribute? mcpServerToolAttribute = method.GetCustomAttribute<Modules.Abstractions.MCP.McpServerToolAttribute>();
                    DescriptionAttribute? descriptionAttribute = method.GetCustomAttribute<DescriptionAttribute>();

                    if (mcpServerToolAttribute != null)
                    {
                        McpServerTool tool = McpServerTool.Create(method, ctx =>
                        {
                            return ctx.Services?.GetRequiredService(moduleType) ?? throw new InvalidOperationException($"Service not found for type {moduleType.FullName}");
                        });
                        mcpServerTools.Add(tool);
                    }
                }

                _ = mcpServerBuilder.WithTools(mcpServerTools);
                //}
            }
        }

        _ = mcpServerBuilder
            .WithToolsFromAssembly()
            .WithListResourcesHandler(async (ctx, ct) =>
            {
                if (ctx.Services is null)
                {
                    throw new InvalidOperationException("Services not available in context");
                }

                IMCPListResourcesRequestContext mcpRequestContext = new ListResourcesRequestContext(ctx);

                List<Resource> resources = [];
                IEnumerable<IMCPListResourcesHandler> services = ctx.Services.GetServices<IMCPListResourcesHandler>();
                foreach (IMCPListResourcesHandler handler in services)
                {
                    IMCPListResourcesResult resourcesResult = await handler.GetResources(mcpRequestContext, ct);
                    resources.AddRange(resourcesResult.Resources.Select(x => x.ToResource()));
                }

                //WorkspaceState state = ctx.Services.GetRequiredService<WorkspaceState>();

                //foreach (KeyValuePair<string, string> kv in state.Artifacts)
                //{
                //    resources.Add(new Resource
                //    {
                //        Name = kv.Key,
                //        Description = "Context Compiler artifact",
                //        MimeType = GuessMime(kv.Key),
                //        Uri = $"ctxc://artifact/{kv.Key}"
                //    });
                //}

                IWorkspaceLoader workspaceLoader = ctx.Services.GetRequiredService<IWorkspaceLoader>();
                IWorkspace workspace = await workspaceLoader.Load();

                resources.AddRange(workspace.Views.Select(x => x.ToResource()));

                return new ListResourcesResult { Resources = resources };
            })
            .WithReadResourceHandler(async (ctx, ct) =>
            {
                if (ctx.Services is null)
                {
                    throw new InvalidOperationException("Services not available in context");
                }

                IEnumerable<IMCPReadResourceHandler> services = ctx.Services.GetServices<IMCPReadResourceHandler>();

                IMCPReadResourceRequestContext mcpRequestContext = new ReadResourceRequestContext(ctx);

                IMCPReadResourceHandler? handler = services.FirstOrDefault(x => x.CanProcess(mcpRequestContext));

                if (handler != null)
                {
                    try
                    {
                        IMCPReadResourceResult readResourceResult = await handler.Process(mcpRequestContext, ct);

                        IMCPResourceContents? contents = readResourceResult.Contents[0];
                        if (contents is IMCPTextResourceContents textContents)
                        {
                            return new ReadResourceResult
                            {
                                Contents = [new TextResourceContents()
                    {
                        Uri = textContents.Uri,
                        MimeType = textContents.MimeType,
                        Text = textContents.Text
                    }
                                ]
                            };

                        }
                    }
                    catch (MissingUriException ex)
                    {
                        throw new McpProtocolException("Missing uri", ex, McpErrorCode.InvalidParams);
                    }
                    catch (NotFoundException ex)
                    {
                        throw new McpProtocolException($"Resource not found: {ctx.Params?.Uri}", ex, McpErrorCode.ResourceNotFound);
                    }


                    //if (readResourceResult.Contents.Count == 0)
                    //{
                    //    throw new McpProtocolException($"Resource not found: {ctx.Params?.Uri}", McpErrorCode.ResourceNotFound);
                    //}


                }

                //WorkspaceState state = ctx.Services.GetRequiredService<WorkspaceState>();
                //string? uri = ctx.Params?.Uri;
                //if (string.IsNullOrWhiteSpace(uri))
                //{
                //    throw new McpProtocolException("Missing uri", McpErrorCode.InvalidParams);
                //}

                //if (uri.StartsWith("ctxc://artifact/", StringComparison.OrdinalIgnoreCase))
                //{
                //    string name = uri["ctxc://artifact/".Length..];
                //    if (!state.Artifacts.TryGetValue(name, out string? path) || !File.Exists(path))
                //    {
                //        throw new McpProtocolException($"Artifact not found: {name}", McpErrorCode.ResourceNotFound);
                //    }

                //    string text = File.ReadAllText(path);
                //    return ValueTask.FromResult(new ReadResourceResult
                //    {
                //        Contents =
                //        [
                //            new TextResourceContents
                //            {
                //                Uri = uri,
                //                MimeType = GuessMime(name),
                //                Text = text
                //            }
                //        ]
                //    });
                //}

                //if (uri.StartsWith("ctxc://view/", StringComparison.OrdinalIgnoreCase))
                //{
                //    string id = uri["ctxc://view/".Length..];
                //    return !state.Views.TryGetValue(id, out string? md)
                //        ? throw new McpProtocolException($"View not found: {id}", McpErrorCode.ResourceNotFound)
                //        : ValueTask.FromResult(new ReadResourceResult
                //        {
                //            Contents =
                //        [
                //            new TextResourceContents
                //            {
                //                Uri = uri,
                //                MimeType = "text/markdown",
                //                Text = md
                //            }
                //        ]
                //        });
                //}

                throw new McpProtocolException($"Unsupported uri scheme: {ctx.Params?.Uri}", McpErrorCode.MethodNotFound);
            });

        return contextCompilerBuilder;
    }

}
