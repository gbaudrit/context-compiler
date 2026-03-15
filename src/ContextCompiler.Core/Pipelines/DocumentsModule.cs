using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Core.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Modules.BuiltIn;

namespace ContextCompiler.Core.Pipelines;

internal sealed class DocumentsModule(
    IDocumentPipelineRunner documentPipelineRunner,
    IGuardian guardian,
    IWorkingFolder workingFolder,
    IReasoningIr reasoningIr) : IDocumentsModule
{
    public ModuleMetadata Metadata => BuiltInMetadata.Meta("documents", GlobalPipelineModuleKinds.Transcoder, priority: 10);

    public async Task Run(CancellationToken cancellationToken)
    {
        DocumentsContext documentsContext = new() { RootPath = workingFolder.Path };
        await documentPipelineRunner.RunAsync(documentsContext, cancellationToken);

        guardian.Load(documentsContext);

        IReadOnlyList<IPipelineFinding> findings = guardian.Findings;
        if (findings.Any(f => f.Action == FindingAction.Block && f.Severity == FindingSeverity.Critical))
        {
            throw new PipelineAbortedException("Pipeline aborted due to critical findings in documents context.");
        }

        foreach (IDocumentContext r in documentsContext.Documents)
        {
            foreach (IFragment f in r.Fragments)
            {
                reasoningIr.Add(f);
            }
        }
    }
}
