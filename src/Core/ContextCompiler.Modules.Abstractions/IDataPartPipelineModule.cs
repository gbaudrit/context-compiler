using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IDataPartPipelineModule : IModule
    {
        static DataPartModuleMetadata Meta(string id, DataPartPipelineModuleKinds kind, int priority = 0)
        {
            return new(id, kind, ModuleApiVersion.Current, priority);
        }

        bool CanProcess(IInputItemContext inputItemContext, IDataPart part);

        Task<IInputItemContextPatch> Run(IInputItemContext inputItemContext, IInputItemContextPatchBuilder patcher, IDataPart part, CancellationToken ct);

        DataPartModuleMetadata Metadata { get; }
    }
}
