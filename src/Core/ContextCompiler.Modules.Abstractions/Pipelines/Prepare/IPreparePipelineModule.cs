using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Prepare;
using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

public interface IPreparePipelineModule : IModule
{
    static PreparePipelineModuleMetadata Meta(string id, PreparePipelineModuleKinds kind, int priority = 0)
    {
        return new(id, kind, ModuleApiVersion.Current, priority);
    }

    Task<IResult<IPreparePipelineRunResult>> Run(IPreparePipelineRunContext context, CancellationToken cancellationToken);

    PreparePipelineModuleMetadata Metadata { get; }
}
