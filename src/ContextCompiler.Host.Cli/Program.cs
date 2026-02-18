using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics;
using System.Reflection;

using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Configuration.Json;
using ContextCompiler.Core;
using ContextCompiler.Core.Engine;
using ContextCompiler.Host.Cli;
using ContextCompiler.Host.Cli.Handlers;
using ContextCompiler.Infrastructure.Configuration;
using ContextCompiler.Infrastructure.FileSystem;
using ContextCompiler.Infrastructure.Hashing;
using ContextCompiler.Plugins.Abstractions.Loading;
using ContextCompiler.Plugins.Loader;

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
        typeof(CompilerEngine).Assembly,
        typeof(PhysicalFileSystem).Assembly,
        typeof(ContextCompiler.Plugins.BuiltIn.BuiltInMetadata).Assembly,
        typeof(ContextCompiler.Plugins.BuiltIn.Templates.Scriban.DependencyInjection).Assembly,
        typeof(ContextCompiler.Plugins.Readers.Excel.ExcelFileReaderPlugin).Assembly
    ];

IHostEnvironment env = builder.Environment;

builder.Logging.ClearProviders().AddConfiguration(builder.Configuration.GetSection("Logging")).AddSimpleConsole(o => o.SingleLine = true);

builder.Services
        .AddJsonConfiguration()
        .AddSingleton<IFileSystem, PhysicalFileSystem>()
        .AddSingleton<IHasher, DefaultHasher>()
        .AddSingleton<ICtxcConfigProvider, JsonCtxcConfigProvider>()
        .AddSingleton<IConfigLocator, DefaultConfigLocator>()
        .AddSingleton<ICompilerEngine, CompilerEngine>()
        .AddSingleton<ICtxcCompileHandler, CtxcCompileHandler>()
        .AddSingleton<ICtxcNewProjectHandler, NewProjectHandler>()
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
        .AddSingleton<ICtxcConfigFilesAddHandler, ConfigFilesAddHandler>()
        .AddCompileCoreServices()
        .AddPluginsLoaderServices();

ContextCompiler.Host.Cli.DependencyInjection.AddHostCliServices(builder.Services);

GlobalCommandLineOptions globals = CliCommandFactory.ParseGlobals(args);

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
_ = builder.Services.AddSingleton(workingFolder);

IServiceCollection pluginsLoaderServices = new ServiceCollection();
pluginsLoaderServices.AddLogging(x => x.AddConfiguration(builder.Configuration.GetSection("Logging")).AddSimpleConsole(o => o.SingleLine = true))
                     .AddPluginsLoaderServices()
                     .AddSingleton(workingFolder);

IServiceProvider pluginsLoaderServicesProvider = pluginsLoaderServices.BuildServiceProvider();
IPluginsLoader pluginsLoader = pluginsLoaderServicesProvider.GetRequiredService<IPluginsLoader>();

await pluginsLoader.LoadFromFolder(Path.Combine(globals.InputPath, ".ctxc", "plugins"), builder.Services, CancellationToken.None);


using IHost host = builder.Build();

RootCommand root = CliCommandFactory.Create(host.Services);
return await root.InvokeAsync(args);
