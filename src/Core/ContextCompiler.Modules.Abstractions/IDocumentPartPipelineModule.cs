using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IDocumentPartPipelineModule : IModule
    {
        static DocumentPartModuleMetadata Meta(string id, DocumentPartPipelineModuleKinds kind, int priority = 0)
        {
            return new(id, kind, ModuleApiVersion.Current, priority);
        }

        bool CanProcess(IDocumentContext documentContext, IDataPart part);

        Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, IDataPart part, CancellationToken ct);

        DocumentPartModuleMetadata Metadata { get; }
    }
}
