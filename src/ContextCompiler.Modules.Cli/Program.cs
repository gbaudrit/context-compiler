using System.CommandLine;

using ContextCompiler.Abstractions;
using ContextCompiler.Configuration.Json;
using ContextCompiler.Core;
using ContextCompiler.Modules.Cli;
using ContextCompiler.Modules.Cli.Handlers;
using ContextCompiler.Modules.Loader;
using ContextCompiler.Modules.NuGet;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Configuration.SetBasePath(AppContext.BaseDirectory)
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables(prefix: "CTXC_");

GlobalCommandLineOptions globals = CliCommandFactory.ParseGlobals(args);

IWorkingFolder workingFolder = new WorkingFolder(globals.InputPath);

builder.Logging.ClearProviders().AddConfiguration(builder.Configuration.GetSection("Logging")).AddSimpleConsole(o => o.SingleLine = true);

builder.Services.AddSingleton(workingFolder)
                .AddCoreServices()
                .AddJsonConfiguration()
                .AddModulesNuGetRestoreServices()
                .AddModulesLoaderServices();

builder.Services
    .AddSingleton<IRestoreHandler, RestoreHandler>()
    .AddSingleton<IVerifyHandler, VerifyHandler>()
    .AddSingleton<IListHandler, ListHandler>()
    .AddSingleton<IPurgeHandler, PurgeHandler>()
    .AddSingleton<ISchemasAggregateHandler, SchemasAggregateHandler>();

using IHost host = builder.Build();

RootCommand root = CliCommandFactory.Create(host.Services);
return await root.InvokeAsync(args);


