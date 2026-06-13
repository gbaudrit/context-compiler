using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Analyze;

namespace ContextCompiler.Modules.Abstractions.Pipelines.Analyze;

public interface IAnalyzePipelineModule : IModule
{
    static AnalyzePipelineModuleMetadata Meta(string id, AnalyzePipelineModuleKinds kind, int priority = 0)
    {
        return new AnalyzePipelineModuleMetadata(id, kind, priority);
    }

    Task<IResult<IAnalyzePipelineRunResult>> Run(IAnalyzePipelineRunContext context, CancellationToken cancellationToken);

    AnalyzePipelineModuleMetadata Metadata { get; }
}
