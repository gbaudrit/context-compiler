using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines.Prepare.Modules;

internal sealed class InventoryRenderingModule(IInventoryRenderer renderer, [FromKeyedServices(StoreKeys.Prepare)] IStore prepareStore) : IPreparePipelineModule
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

        await renderer.RenderAsync(prepareStore, context.Inventory, cancellationToken);
        return await context.Success();
    }
}
