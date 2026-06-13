using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Services.Analyze;

public interface IAnalyzePlanner
{
    Task<AnalyzePlan> CreatePlanAsync(
        ProjectInventory inventory,
        ProjectClassification classification,
        CancellationToken cancellationToken);
}
