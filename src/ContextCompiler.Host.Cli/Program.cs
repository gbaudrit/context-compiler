using System.CommandLine;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Core.Engine;
using ContextCompiler.Core.Pipelines;
using ContextCompiler.Infrastructure.FileSystem;
using ContextCompiler.Infrastructure.Hashing;
using ContextCompiler.Infrastructure.PluginLoading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

static ServiceProvider BuildServices()
{
    var assemblies = new[]
    {
        typeof(ContextCompiler.Core.Engine.CompilerEngine).Assembly,
        typeof(ContextCompiler.Infrastructure.FileSystem.PhysicalFileSystem).Assembly,
        typeof(ContextCompiler.Plugins.BuiltIn.BuiltInMetadata).Assembly
    };

    var registry = PluginRegistryBuilder.FromAssemblies(assemblies);

    return new ServiceCollection()
        .AddLogging(b => b.AddSimpleConsole(o => o.SingleLine = true))
        .AddSingleton<IFileSystem, PhysicalFileSystem>()
        .AddSingleton<IHasher, DefaultHasher>()
        .AddSingleton<IPluginRegistry>(registry)
        .AddSingleton<ICompilerEngine, CompilerEngine>()
        .BuildServiceProvider();
}

var root = new RootCommand("Context Compiler CLI (ctxc)");

var compile = new Command("compile", "Compile context into reasoning artifacts");
var inputOpt = new Option<string>("--input") { IsRequired = true };
var outputOpt = new Option<string>("--output") { IsRequired = true };
var maxChars = new Option<int>("--max-chars", () => 120_000, "Maximum characters in prompt.context.md");
compile.AddOption(inputOpt);
compile.AddOption(outputOpt);
compile.AddOption(maxChars);

compile.SetHandler(async (input, output, max) =>
{
    using var sp = BuildServices();
    var engine = sp.GetRequiredService<ICompilerEngine>();
    var rc = await engine.CompileAsync(new CompileRequest(input, output, new CompileOptions(MaxCharacters: max)), CancellationToken.None);
    Environment.ExitCode = rc;
}, inputOpt, outputOpt, maxChars);

root.AddCommand(compile);
return await root.InvokeAsync(args);
