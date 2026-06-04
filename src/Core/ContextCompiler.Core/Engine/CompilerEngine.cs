using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Engine;

public interface ICompilerEngine
{
    Task<int> CompileAsync(CompileRequest request, CancellationToken ct);
}

public sealed record CompileRequest(string InputPath, string OutputPath, string Name, bool Clean, CompileOptions? Options = null);

public sealed class CompilerEngine(
    ILogger<CompilerEngine> logger,
    ICompilePipeline compilePipelineRunner,
    IFileSystem fs,
    IHasher hasher,
    IModulesRegistry modules,
    IConfigProvider configProvider,
    IConfigLocator configLocator,
    IOutput output
) : ICompilerEngine
{
    public async Task<int> CompileAsync(CompileRequest request, CancellationToken ct)
    {
        CompileOptions options = request.Options ?? new CompileOptions();
        string? configPath = configLocator.Locate(request.InputPath, options.ConfigPath, request.Name);
        _ = configProvider.GetConfigOrDefault(configPath);
        logger.LogInformation("Compile requested. Input={Input} Output={Output}", request.InputPath, request.OutputPath);

        //if (options.InlineViews == null)
        //{
        //    options = options with
        //    {
        //        InlineViews = cfg.Views?.Inline ?? true
        //    };
        //}

        await compilePipelineRunner.RunAsync(request.InputPath, request.OutputPath, request.Clean, output, ct);

        return 0;
    }
}
