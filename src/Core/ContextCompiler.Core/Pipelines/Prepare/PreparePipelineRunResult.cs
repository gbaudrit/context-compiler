using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines.Prepare;

namespace ContextCompiler.Core.Pipelines.Prepare;

internal sealed class PreparePipelineRunResult(
    ProjectInventory? inventory,
    ProjectClassification? classification,
    PreparePlan? plan) : IPreparePipelineRunResult
{
    public ProjectInventory? Inventory { get; } = inventory;
    public ProjectClassification? Classification { get; } = classification;
    public PreparePlan? Plan { get; } = plan;
}
