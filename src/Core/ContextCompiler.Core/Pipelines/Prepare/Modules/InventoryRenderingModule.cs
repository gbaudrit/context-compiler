using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

namespace ContextCompiler.Core.Pipelines.Prepare.Modules;

internal sealed class InventoryRenderingModule(IInventoryRenderer renderer) : IPreparePipelineModule
{
    public PreparePipelineModuleMetadata Metadata =>
        IPreparePipelineModule.Meta("prepare.inventory-rendering", PreparePipelineModuleKinds.InventoryRendering);

    public async Task<IResult<IPreparePipelineRunResult>> Run(
        IPreparePipelineRunContext context,
        CancellationToken cancellationToken)
    {
        if (context.Inventory is null)
        {
            return await context.Failure("Inventory must be available before rendering inventory.json.");
        }

        await renderer.RenderAsync(context.Inventory, cancellationToken);
        return await context.Success();
    }
}
