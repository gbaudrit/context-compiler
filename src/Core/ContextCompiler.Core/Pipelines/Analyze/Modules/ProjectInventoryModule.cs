using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines.Analyze;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Modules.Abstractions.Pipelines.Analyze;

namespace ContextCompiler.Core.Pipelines.Analyze.Modules;

internal sealed class ProjectInventoryModule(IProjectScanner scanner) : IAnalyzePipelineModule
{
    public AnalyzePipelineModuleMetadata Metadata =>
        IAnalyzePipelineModule.Meta("analyze.project-inventory", AnalyzePipelineModuleKinds.ProjectInventory);

    public async Task<IResult<IAnalyzePipelineRunResult>> Run(
        IAnalyzePipelineRunContext context,
        CancellationToken cancellationToken)
    {
        ProjectInventory inventory = await scanner.ScanAsync(context.Request.SourceUri, cancellationToken);
        _ = context.WithInventory(inventory);
        return await context.Success();
    }
}
