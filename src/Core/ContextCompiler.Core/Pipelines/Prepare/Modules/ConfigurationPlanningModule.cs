using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

namespace ContextCompiler.Core.Pipelines.Prepare.Modules;

internal sealed class ConfigurationPlanningModule(IPreparePlanner planner) : IPreparePipelineModule
{
    public PreparePipelineModuleMetadata Metadata =>
        IPreparePipelineModule.Meta("prepare.configuration-planning", PreparePipelineModuleKinds.ConfigurationPlanning);

    public async Task<IResult<IPreparePipelineRunResult>> Run(
        IPreparePipelineRunContext context,
        CancellationToken cancellationToken)
    {
        if (context.Inventory is null)
        {
            return await context.Failure("Inventory must be available before planning.");
        }

        PreparePlan plan = await planner.CreatePlanAsync(context.Inventory, context.Request.Goal, cancellationToken);
        _ = context.WithPlan(plan);
        return await context.Success();
    }
}
