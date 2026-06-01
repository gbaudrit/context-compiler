using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IInputIngestionPipelineModule : IModule
    {
        static InputIngestionModuleMetadata Meta(string id, InputIngestionPipelineModuleKinds kind, int priority = 0)
        {
            return new(id, kind, ModuleApiVersion.Current, priority);
        }

        bool CanProcess(IInputItemContext InputItemContext);

        Task<IResult<IInputIngestionPipelineRunResult>> Run(IInputIngestionPipelineRunContext context, CancellationToken ct);

        InputIngestionModuleMetadata Metadata { get; }
    }
}
