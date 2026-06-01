using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Reports.Modules.Pipelines.ReactFlow;

/// <summary>
/// Pipeline event listener module that runs early to collect all pipeline events.
/// </summary>
internal sealed class PipelineEventListener(PipelineEventCollector eventCollector) : IGlobalPipelineModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
        "reports.pipelines.reactflow.listener",
        GlobalPipelineModuleKinds.ReportComposition,
        priority: 100);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        // This module doesn't do anything during Run, it just needs to be registered
        // so that the PipelineEventCollector can collect events throughout the pipeline execution
        return context.Success();
    }
}
