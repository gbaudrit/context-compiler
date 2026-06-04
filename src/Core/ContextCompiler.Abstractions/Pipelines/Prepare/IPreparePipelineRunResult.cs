using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Pipelines.Prepare;

public interface IPreparePipelineRunResult
{
    ProjectInventory? Inventory { get; }

    ProjectClassification? Classification { get; }

    PreparePlan? Plan { get; }
}
