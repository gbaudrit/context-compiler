using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines.Analyze;

namespace ContextCompiler.Core.Pipelines.Analyze;

internal sealed class AnalyzePipelineRunResult(
    ProjectInventory? inventory,
    ProjectClassification? classification,
    AnalyzePlan? plan) : IAnalyzePipelineRunResult
{
    public ProjectInventory? Inventory { get; } = inventory;

    public ProjectClassification? Classification { get; } = classification;

    public AnalyzePlan? Plan { get; } = plan;
}
