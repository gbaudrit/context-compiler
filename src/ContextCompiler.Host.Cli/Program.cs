using System.CommandLine;
using System.Reflection;

using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Core;
using ContextCompiler.Core.Engine;
using ContextCompiler.Host.Cli;
using ContextCompiler.Host.Cli.Handlers;
using ContextCompiler.Infrastructure.Configuration;
using ContextCompiler.Infrastructure.FileSystem;
using ContextCompiler.Infrastructure.Hashing;
using ContextCompiler.Infrastructure.PluginLoading;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;



HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Configuration.SetBasePath(AppContext.BaseDirectory)
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables(prefix: "CTXC_");

Assembly[] assemblies =
    [
        typeof(ContextCompiler.Core.Engine.CompilerEngine).Assembly,
        typeof(ContextCompiler.Infrastructure.FileSystem.PhysicalFileSystem).Assembly,
        typeof(ContextCompiler.Plugins.BuiltIn.BuiltInMetadata).Assembly,
        typeof(ContextCompiler.Plugins.BuiltIn.Templates.Scriban.DependencyInjection).Assembly,
        typeof(ContextCompiler.Plugins.Readers.PDF.PdfFileReaderPlugin).Assembly
    ];

IHostEnvironment env = builder.Environment;

builder.Logging.ClearProviders().AddConfiguration(builder.Configuration.GetSection("Logging")).AddSimpleConsole(o => o.SingleLine = true);

builder.Services
        .AddSingleton<IFileSystem, PhysicalFileSystem>()
        .AddSingleton<IHasher, DefaultHasher>()
        .AddSingleton<ContextCompiler.Abstractions.Configuration.ICtxcConfigProvider, JsonCtxcConfigProvider>()
        .AddSingleton<ContextCompiler.Abstractions.Configuration.IConfigLocator, DefaultConfigLocator>()
        .AddSingleton<ICompilerEngine, CompilerEngine>()
        // CLI handlers
        .AddSingleton<ICtxcCompileHandler, CtxcCompileHandler>()
        .AddSingleton<ICtxcDiffHandler, CtxcDiffHandler>()
        .AddSingleton<ICtxcExplainHandler, CtxcExplainHandler>()
        .AddSingleton<ICtxcHealthHandler, CtxcHealthHandler>()
        .AddSingleton<ICtxcViewsListHandler, CtxcViewsListHandler>()
        .AddSingleton<ICtxcViewsRenderHandler, CtxcViewsRenderHandler>()
        .AddSingleton<ICtxcGuardsReportHandler, CtxcGuardsReportHandler>()
        .AddSingleton<ICtxcPluginsListHandler, CtxcPluginsListHandler>()
        .AddSingleton<ICtxcPluginsAddHandler, CtxcPluginsAddHandler>()
        .AddSingleton<ICtxcPluginsRemoveHandler, CtxcPluginsRemoveHandler>()
        .AddSingleton<ICtxcGraphExportHandler, CtxcGraphExportHandler>()
        .AddCoreServices()
        .AddHostCliServices();

PluginRegistryBuilder.RegisterPluginServices(builder.Services, assemblies);

using IHost host = builder.Build();

RootCommand root = ContextCompiler.Host.Cli.CliCommandFactory.Create(host.Services);
return await root.InvokeAsync(args);
