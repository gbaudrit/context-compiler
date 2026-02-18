using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Plugins.Abstractions;

namespace ContextCompiler.Core.Pipelines.DataPart
{
    internal sealed class FragmentGuardsPass(IPluginRegistry plugins) : IDataPartPass
    {
        public string Id => "guards.fragment";
        public int Priority => 100;
        public DocumentStage Stage => DocumentStage.Fragment;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, IDataPart part, CancellationToken ct)
        {
            List<IGuardPlugin> guards = [.. plugins.Guards.Where(g => g.Stage == Stage).OrderBy(g => g.Metadata.Priority)];
            List<IPipelineFinding> findings = [];
            foreach (IGuardPlugin? g in guards)
            {
                IReadOnlyList<IPipelineFinding> f = await g.EvaluateAsync(new GuardContext(ctx, part), ct);
                if (f.Count > 0)
                {
                    findings.AddRange(f);
                }
            }
        }
    }
}
