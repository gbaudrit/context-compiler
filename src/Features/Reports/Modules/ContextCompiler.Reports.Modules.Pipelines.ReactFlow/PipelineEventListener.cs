using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Reports.Modules.Pipelines.ReactFlow;

/// <summary>
/// Pipeline event listener module that runs early to collect all pipeline events.
/// </summary>
internal sealed class PipelineEventListener(PipelineEventCollector eventCollector) : ICompilePipelineModule
{
    public ModuleMetadata Metadata => ICompilePipelineModule.Meta(
        "reports.pipelines.reactflow.listener",
        CompilePipelineModuleKinds.ReportComposition,
        priority: 100);

    public Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
    {
        // This module doesn't do anything during Run, it just needs to be registered
        // so that the PipelineEventCollector can collect events throughout the pipeline execution
        return context.Success();
    }
}
