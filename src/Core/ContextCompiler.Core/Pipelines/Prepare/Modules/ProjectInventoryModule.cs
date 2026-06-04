using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

namespace ContextCompiler.Core.Pipelines.Prepare.Modules;

internal sealed class ProjectInventoryModule(IProjectScanner scanner) : IPreparePipelineModule
{
    public PreparePipelineModuleMetadata Metadata =>
        IPreparePipelineModule.Meta("prepare.project-inventory", PreparePipelineModuleKinds.ProjectInventory);

    public async Task<IResult<IPreparePipelineRunResult>> Run(
        IPreparePipelineRunContext context,
        CancellationToken cancellationToken)
    {
        ProjectInventory inventory = await scanner.ScanAsync(context.Request.SourceUri, cancellationToken);
        _ = context.WithInventory(inventory);
        return await context.Success();
    }
}
