using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Configuration.Json;
using ContextCompiler.Core;
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


// Context Compiler MCP Server (stdio)
// Exposes:
// - tools: compile_context, list_artifacts, read_artifact, list_views
// - resources: ctxc://artifact/<name> , ctxc://view/<id>
// Designed for VS Code / Copilot MCP consumption.

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(o => o.LogToStandardErrorThreshold = LogLevel.Information);


builder.Services
    .AddSingleton<IFileSystem, PhysicalFileSystem>()
    .AddSingleton<IHasher, DefaultHasher>()
    .AddSingleton<IConfigProvider, JsonCtxcConfigProvider>()
    .AddSingleton<IConfigLocator, DefaultConfigLocator>()
    .AddSingleton<ICompilerEngine, CompilerEngine>()
    .AddCoreServices()
    .AddModulesLoaderServices()
    .AddMcpCore()
    .AddMcpInfrastructure(builder.Configuration, args);


await builder.Build().RunAsync();




