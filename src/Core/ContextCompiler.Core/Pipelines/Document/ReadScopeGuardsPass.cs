using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class ReadScopeGuardsPass(IModulesRegistry modules) : IDocumentPass
    {
        public string Id => "guards.readscope";
        public int Priority => 100;
        public DocumentStage Stage => DocumentStage.FileRead;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
        {
            List<IGuardModule> guards = [.. modules.Guards.Where(g => g.Stage == Stage).OrderBy(g => g.Metadata.Priority)];
            List<IPipelineFinding> findings = [];
            foreach (IGuardModule? g in guards)
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
