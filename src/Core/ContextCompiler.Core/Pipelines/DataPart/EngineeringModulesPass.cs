using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Core.Pipelines.DataPart
{
    internal sealed class EngineeringModulesPass(IModulesRegistry modules) : IDataPartPass
    {
        public string Id => "pass.engineeringmodules";
        public int Priority => 100;
        public DocumentStage Stage => DocumentStage.Engineering;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, IDataPart part, CancellationToken ct)
        {
            if (ctx.Data is null)
            {
                _ = ctx.AddFinding(
                    FindingSeverity.Warning,
                    FindingAction.Skip,
                    Id,
                    $"No data available in context for part '{part.PartId}'. Skipping transcoding.");
                return;
            }

            foreach (IEngineeringModule? mod in modules.EngineeringModules.OrderBy(m => m.Metadata.Priority))
            {
                _ = await mod.ApplyAsync(ctx.Data, ct);
            }
        }
    }
}
