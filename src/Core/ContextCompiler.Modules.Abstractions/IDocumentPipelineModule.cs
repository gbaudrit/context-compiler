using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IDocumentPipelineModule : IModule
    {
        static DocumentModuleMetadata Meta(string id, DocumentPipelineModuleKinds kind, int priority = 0)
        {
            return new(id, kind, ModuleApiVersion.Current, priority);
        }

        bool CanProcess(IDocumentContext documentContext);

        Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, CancellationToken ct);

        DocumentModuleMetadata Metadata { get; }
    }
}
