using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines.Prepare;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Engine;

public interface IPrepareEngine
{
    Task<int> PrepareAsync(PrepareRequest request, CancellationToken cancellationToken);
}

public sealed class PrepareEngine(
    ILogger<PrepareEngine> logger,
    IPreparePipeline preparePipeline) : IPrepareEngine
{
    public async Task<int> PrepareAsync(PrepareRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        logger.LogInformation("Prepare requested. Source={Source} Goal={Goal}",
            request.SourceUri,
            request.Goal ?? "<none>");

        await preparePipeline.RunAsync(request, cancellationToken);

        return 0;
    }
}
