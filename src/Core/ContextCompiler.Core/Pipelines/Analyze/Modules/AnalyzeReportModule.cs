using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Analyze;
using ContextCompiler.Abstractions.Services.Analyze;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions.Pipelines.Analyze;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines.Analyze.Modules;

internal sealed class AnalyzeReportModule(
    IAnalyzeRenderer renderer,
    [FromKeyedServices(StoreKeys.Root)] IStore rootStore,
    [FromKeyedServices(StoreKeys.Prepare)] IStore prepareStore) : IAnalyzePipelineModule
{
    public AnalyzePipelineModuleMetadata Metadata =>
        IAnalyzePipelineModule.Meta("analyze.report", AnalyzePipelineModuleKinds.AnalyzeReport);

    public async Task<IResult<IAnalyzePipelineRunResult>> Run(
        IAnalyzePipelineRunContext context,
        CancellationToken cancellationToken)
    {
        if (context.Inventory is null)
        {
            return await context.Failure("Inventory must be available before analyze report rendering.");
        }

        if (context.Classification is null)
        {
            return await context.Failure("Classification must be available before analyze report rendering.");
        }

        if (context.Plan is null)
        {
            return await context.Failure("Analyze plan must be available before analyze report rendering.");
        }

        await renderer.RenderAsync(rootStore, prepareStore, context.Inventory, context.Classification, context.Plan, cancellationToken);
        return await context.Success();
    }
}
