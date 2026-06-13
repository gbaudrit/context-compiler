using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Pipelines.Analyze;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Engine;

public interface IAnalyzeEngine
{
    Task<int> AnalyzeAsync(AnalyzeRequest request, CancellationToken cancellationToken);
}

public sealed class AnalyzeEngine(
    ILogger<AnalyzeEngine> logger,
    IAnalyzePipeline analyzePipeline) : IAnalyzeEngine
{
    public async Task<int> AnalyzeAsync(AnalyzeRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        logger.LogInformation("Analyze requested. Source={Source} Goal={Goal}",
            request.SourceUri,
            request.Goal ?? "<none>");

        await analyzePipeline.RunAsync(request, cancellationToken);

        return 0;
    }
}
