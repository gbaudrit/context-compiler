using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines.Analyze;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Modules.Abstractions.Pipelines.Analyze;

namespace ContextCompiler.Core.Pipelines.Analyze.Modules;

internal sealed class ProjectClassificationModule(IProjectClassifier classifier) : IAnalyzePipelineModule
{
    public AnalyzePipelineModuleMetadata Metadata =>
        IAnalyzePipelineModule.Meta("analyze.project-classification", AnalyzePipelineModuleKinds.ProjectClassification);

    public async Task<IResult<IAnalyzePipelineRunResult>> Run(
        IAnalyzePipelineRunContext context,
        CancellationToken cancellationToken)
    {
        if (context.Inventory is null)
        {
            return await context.Failure("Inventory must be available before project classification.");
        }

        ProjectClassification classification = await classifier.ClassifyAsync(context.Inventory, cancellationToken);
        _ = context.WithClassification(classification);
        return await context.Success();
    }
}
