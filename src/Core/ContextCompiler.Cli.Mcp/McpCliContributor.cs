using System.CommandLine;

using ContextCompiler.Abstractions.Cli;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.DependencyInjection;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Configuration.Json;
using ContextCompiler.Core;
using ContextCompiler.Core.DependencyInjectionBuilders;
using ContextCompiler.Core.Engine;
using ContextCompiler.Infrastructure.Configuration;
using ContextCompiler.Infrastructure.FileSystem;
using ContextCompiler.Infrastructure.Hashing;
using ContextCompiler.Mcp.Core;
using ContextCompiler.Mcp.Infrastructure;
using ContextCompiler.Modules.Loader;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Mcp;

internal sealed class McpCliContributor(McpCliEntryArgs entryArgs) : ICliCommandContributor
{
    public Command Build(IServiceProvider services)
    {
        Command mcp = new("mcp", "Model Context Protocol server commands.");
        Command serve = new("serve", "Run the Context Compiler MCP server (stdio transport).");

        serve.SetHandler(async () =>
        {
            await RunMcpServerAsync(entryArgs.Args);
        });

        mcp.AddCommand(serve);
        return mcp;
    }

    private static async Task RunMcpServerAsync(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        _ = builder.Logging.AddConsole(o => o.LogToStandardErrorThreshold = LogLevel.Information);

        IContextCompilerBuilder contextCompilerBuilder = builder.Services.AddDependencyInjectionBuilders();

        _ = builder.Services
            .AddSingleton<IFileSystem, PhysicalFileSystem>()
            .AddSingleton<IHasher, DefaultHasher>()
            .AddSingleton<IConfigProvider, JsonCtxcConfigProvider>()
            .AddSingleton<IConfigLocator, DefaultConfigLocator>()
            .AddSingleton<ICompilerEngine, CompilerEngine>()
            .AddCoreServices()
            .AddModulesLoaderServices()
            .AddMcpCore();

        _ = contextCompilerBuilder.AddMcpInfrastructure(builder.Configuration, args);

        await builder.Build().RunAsync();
    }
}
