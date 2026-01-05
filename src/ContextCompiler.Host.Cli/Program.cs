using System.CommandLine;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Core.Engine;
using ContextCompiler.Core.Pipelines;
using ContextCompiler.Infrastructure.FileSystem;
using ContextCompiler.Infrastructure.Hashing;
using ContextCompiler.Infrastructure.PluginLoading;
using ContextCompiler.Host.Cli;
using ContextCompiler.Host.Cli.Handlers;
using ContextCompiler.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ContextCompiler.Core;
using ContextCompiler.Abstractions.Pipelines;

static ServiceProvider BuildServices()
{
    var assemblies = new[]
    {
        typeof(ContextCompiler.Core.Engine.CompilerEngine).Assembly,
        typeof(ContextCompiler.Infrastructure.FileSystem.PhysicalFileSystem).Assembly,
        typeof(ContextCompiler.Plugins.BuiltIn.BuiltInMetadata).Assembly
    };

    var services = new ServiceCollection()
        .AddLogging(b => b.AddSimpleConsole(o => o.SingleLine = true))
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

    PluginRegistryBuilder.RegisterPluginServices(services, assemblies);
    

    return services.BuildServiceProvider();
}

var sp = BuildServices();
var root = ContextCompiler.Host.Cli.CliCommandFactory.Create(sp);
return await root.InvokeAsync(args);
