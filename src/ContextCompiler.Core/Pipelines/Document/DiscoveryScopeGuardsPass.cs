using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class DiscoveryScopeGuardsPass(IPluginRegistry plugins) : IDocumentPass
    {
        public string Id => "guards.discovery";
        public int Priority => 100;
        public DocumentStage Stage => DocumentStage.Discovery;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
        {
            List<IGuardPlugin> guards = [.. plugins.Guards.Where(g => g.Stage == Stage).OrderBy(g => g.Metadata.Priority)];
            List<IPipelineFinding> findings = [];
            foreach (IGuardPlugin? g in guards)
            {
                IReadOnlyList<IPipelineFinding> f = await g.EvaluateAsync(new GuardContext(ctx), ct);
                if (f.Count > 0)
                {
                    findings.AddRange(f);
                }
            }
        }
    }
}
