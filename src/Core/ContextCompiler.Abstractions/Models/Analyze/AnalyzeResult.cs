using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Models.Analyze;

public sealed class AnalyzeResult
{
    public ProjectInventory? Inventory { get; init; }

    public ProjectClassification? Classification { get; init; }

    public AnalyzePlan? Plan { get; init; }
}
