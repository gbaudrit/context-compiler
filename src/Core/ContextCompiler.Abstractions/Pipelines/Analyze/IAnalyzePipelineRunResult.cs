using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Pipelines.Analyze;

public interface IAnalyzePipelineRunResult
{
    ProjectInventory? Inventory { get; }

    ProjectClassification? Classification { get; }

    AnalyzePlan? Plan { get; }
}
