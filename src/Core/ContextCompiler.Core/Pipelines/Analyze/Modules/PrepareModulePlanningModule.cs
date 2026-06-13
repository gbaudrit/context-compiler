using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Pipelines.Analyze;
using ContextCompiler.Abstractions.Services.Analyze;
using ContextCompiler.Modules.Abstractions.Pipelines.Analyze;

namespace ContextCompiler.Core.Pipelines.Analyze.Modules;

internal sealed class PrepareModulePlanningModule(IAnalyzePlanner planner) : IAnalyzePipelineModule
{
    public AnalyzePipelineModuleMetadata Metadata =>
        IAnalyzePipelineModule.Meta("analyze.prepare-module-planning", AnalyzePipelineModuleKinds.PrepareModulePlanning);

    public async Task<IResult<IAnalyzePipelineRunResult>> Run(
        IAnalyzePipelineRunContext context,
        CancellationToken cancellationToken)
    {
        if (context.Inventory is null)
        {
            return await context.Failure("Inventory must be available before prepare module planning.");
        }

        if (context.Classification is null)
        {
            return await context.Failure("Classification must be available before prepare module planning.");
        }

        AnalyzePlan plan = await planner.CreatePlanAsync(context.Inventory, context.Classification, cancellationToken);
        _ = context.WithPlan(plan);
        return await context.Success();
    }
}
