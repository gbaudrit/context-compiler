using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

namespace ContextCompiler.Core.Pipelines.Prepare.Modules;

internal sealed class PrepareReportModule(IPrepareReportRenderer renderer) : IPreparePipelineModule
{
    public PreparePipelineModuleMetadata Metadata =>
        IPreparePipelineModule.Meta("prepare.report", PreparePipelineModuleKinds.PrepareReport);

    public async Task<IResult<IPreparePipelineRunResult>> Run(
        IPreparePipelineRunContext context,
        CancellationToken cancellationToken)
    {
        if (context.Inventory is null || context.Classification is null || context.Plan is null)
        {
            return await context.Failure("Inventory, classification, and plan must all be available before rendering the report.");
        }

        await renderer.RenderAsync(
            context.Request,
            context.Inventory,
            context.Classification,
            context.Plan,
            cancellationToken);

        return await context.Success();
    }
}
