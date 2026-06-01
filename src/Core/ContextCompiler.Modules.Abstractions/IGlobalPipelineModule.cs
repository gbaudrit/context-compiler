using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IGlobalPipelineModule : IModule
    {
        static ModuleMetadata Meta(string id, GlobalPipelineModuleKinds kind, int priority = 0)
        {
            return new(id, kind, ModuleApiVersion.Current, priority);
        }

        Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken);

        ModuleMetadata Metadata { get; }
    }
}
