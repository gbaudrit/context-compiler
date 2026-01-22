using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.DataPart
{
    internal sealed class DataPartPipelineRunner(IEnumerable<IDataPartPass> passes) : IDataPartPipelineRunner
    {

        public async ValueTask<IPipelineRunResult> RunAsync(IDocumentContext ctx, IDataPart part, CancellationToken ct)
        {
            passes = passes
                .OrderBy(p => (int)p.Stage)
                .ThenBy(p => p.Priority)
                .ThenBy(p => p.Id, StringComparer.Ordinal)
                .ToArray();

            try
            {
                foreach (var pass in passes)
                {
                    ct.ThrowIfCancellationRequested();

                    await pass.ExecuteAsync(ctx, part, ct);

                    // hard stop rule
                    var blocked = ctx.Findings.Any(f => f.Severity == FindingSeverity.Critical && f.Action == FindingAction.Block);
                    if (blocked)
                        return new PipelineRunResult(false, ExitCode: 2, ctx.Findings);
                }

                return new PipelineRunResult(true, 0, ctx.Findings);
            }
            catch (OperationCanceledException) { throw; }
            catch (Exception ex)
            {
                ctx.AddFinding(
                    FindingSeverity.Critical,
                    FindingAction.Block,
                    PassId: "pipeline.runner",
                    Message: $"Internal error: {ex.GetType().Name}"
                );

                return new PipelineRunResult(false, ExitCode: 1, ctx.Findings);
            }
        }
    }
}
