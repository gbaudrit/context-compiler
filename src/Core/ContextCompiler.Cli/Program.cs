using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics;
using System.Reflection;

using ContextCompiler;
using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Cli;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.DependencyInjection;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Cli;
using ContextCompiler.Cli.Handlers;
using ContextCompiler.Cli.Mcp;
using ContextCompiler.Cli.Modules;
using ContextCompiler.Cli.Skills;
using ContextCompiler.Configuration.Json;
using ContextCompiler.Core;
using ContextCompiler.Core.DependencyInjectionBuilders;
using ContextCompiler.Core.Engine;
using ContextCompiler.Infrastructure.Configuration;
using ContextCompiler.Infrastructure.FileSystem;
using ContextCompiler.Infrastructure.Hashing;
using ContextCompiler.Modules;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Loader;
using ContextCompiler.Modules.NuGet;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using CliCommandFactory = ContextCompiler.Cli.CliCommandFactory;



HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

GlobalCommandLineOptions globals = CliCommandFactory.ParseGlobals(args);
if (!string.IsNullOrEmpty(globals.InputPath) && globals.InputPath == ".")
{
    globals = globals with { InputPath = Environment.CurrentDirectory };
}

builder.Configuration.SetBasePath(AppContext.BaseDirectory)
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables(prefix: "CTXC_");

string[] configurationArgs = GetConfigurationOverrideArgs(args);
if (configurationArgs.Length > 0)
{
    _ = builder.Configuration.AddCommandLine(configurationArgs);
}

Assembly[] assemblies =
    [
        typeof(CompilerEngine).Assembly,
        typeof(PhysicalFileSystem).Assembly
    ];

IHostEnvironment env = builder.Environment;

builder.Logging.ClearProviders().AddConfiguration(builder.Configuration.GetSection("Logging")).AddSimpleConsole(o => o.SingleLine = true);

IContextCompilerBuilder contextCompilerBuilder = builder.Services.AddDependencyInjectionBuilders();

builder.Services
        .AddJsonConfiguration(builder.Configuration, globals.InputPath, TryGetOptionValue(args, "--config"))
        .AddSingleton<IFileSystem, PhysicalFileSystem>()
        .AddSingleton<IHasher, DefaultHasher>()
        .AddSingleton<IConfigProvider, JsonCtxcConfigProvider>()
        .AddSingleton<IConfigLocator, DefaultConfigLocator>()
        .AddSingleton<ICompilerEngine, CompilerEngine>()
        .AddSingleton<IAnalyzeEngine, AnalyzeEngine>()
        .AddSingleton<IPrepareEngine, PrepareEngine>()
        .AddSingleton<ICtxcCompileHandler, CtxcCompileHandler>()
        .AddSingleton<ICtxcAnalyzeHandler, CtxcAnalyzeHandler>()
        .AddSingleton<ICtxcPrepareHandler, CtxcPrepareHandler>()
        .AddSingleton<ICtxcAutopilotHandler, CtxcAutopilotHandler>()
        .AddSingleton<ICtxcNewProjectHandler, NewProjectHandler>()
        .AddSingleton<ICtxcDiffHandler, CtxcDiffHandler>()
        .AddSingleton<ICtxcExplainHandler, CtxcExplainHandler>()
        .AddSingleton<ICtxcHealthHandler, CtxcHealthHandler>()
        .AddSingleton<ICtxcViewsListHandler, CtxcViewsListHandler>()
        .AddSingleton<ICtxcViewsRenderHandler, CtxcViewsRenderHandler>()
        .AddSingleton<ICtxcGuardsReportHandler, CtxcGuardsReportHandler>()
        .AddSingleton<ICtxcModulesListHandler, CtxcModulesListHandler>()
        .AddSingleton<ICtxcModulesAddHandler, CtxcModulesAddHandler>()
        .AddSingleton<ICtxcModulesRemoveHandler, CtxcModulesRemoveHandler>()
        .AddSingleton<ICtxcGraphExportHandler, CtxcGraphExportHandler>()
        .AddSingleton<ICtxcConfigFilesAddHandler, ConfigFilesAddHandler>()
        .AddContextCompiler()
        .AddCompileCoreServices()
        .AddCoreServices()
        .AddModulesLoaderServices()
        .AddModulesNuGetRestoreServices()
        .AddModules()
        .AddModulesCli()
        .AddSkillsCli()
        .AddMcpCli(args);

if (globals.Debug)
{
    _ = Debugger.Launch();
    Debugger.Break();
}

ContextCompiler.Cli.DependencyInjection.AddHostCliServices(builder.Services);

IWorkingFolder workingFolder = new WorkingFolder(globals.InputPath);
_ = builder.Services.AddSingleton(workingFolder);

//builder.Services.Configure<ModulesConfig>(options =>
//{
//    options.ActiveScope = DetermineModuleScope(args);
//});

contextCompilerBuilder.AddWorkspaceModules(workingFolder, builder.Configuration, DetermineModuleScope(args), CancellationToken.None);

using IHost host = builder.Build();

RootCommand root = CliCommandFactory.Create(host.Services);

// DI-driven aggregation: every ICliCommandContributor (modules, mcp, ...) attaches its
// command tree to the unified ctxc CLI.
foreach (ICliCommandContributor contributor in host.Services.GetServices<ICliCommandContributor>())
{
    root.AddCommand(contributor.Build(host.Services));
}

return await root.InvokeAsync(args);

static string DetermineModuleScope(string[] args)
{
    string? command = args.FirstOrDefault(arg => !arg.StartsWith("--", StringComparison.Ordinal));
    return command?.ToLowerInvariant() switch
    {
        "prepare" => ModulesConfig.ScopePrepare,
        "compile" => ModulesConfig.ScopeCompile,
        _ => ModulesConfig.ScopeAll,
    };
}

static string? TryGetOptionValue(string[] args, string optionName)
{
    for (int i = 0; i < args.Length; i++)
    {
        string arg = args[i];
        if (string.Equals(arg, optionName, StringComparison.OrdinalIgnoreCase))
        {
            return i + 1 < args.Length ? args[i + 1] : null;
        }

        string prefix = $"{optionName}=";
        if (arg.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        {
            return arg[prefix.Length..];
        }
    }

    return null;
}

static string[] GetConfigurationOverrideArgs(string[] args)
{
    return [.. args.Where(arg =>
        arg.StartsWith("--", StringComparison.Ordinal)
        && arg.Contains('=', StringComparison.Ordinal)
        && arg.Contains(':', StringComparison.Ordinal))];
}

//static string GetOverrideFileName(string fileName)
//{
//    string extension = Path.GetExtension(fileName);
//    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
//    return $"{fileNameWithoutExtension}.overrides{extension}";
//}



//static void AddJsonFilePair(IConfigurationBuilder configuration, string path, bool optional)
//{
//    _ = configuration.AddJsonFile(path, optional: optional, reloadOnChange: true);
//    _ = configuration.AddJsonFile(Path.Combine(Path.GetDirectoryName(path) ?? string.Empty, GetOverrideFileName(Path.GetFileName(path))), optional: true, reloadOnChange: true);
//}
