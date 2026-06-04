using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Services.Prepare;

public interface IPreparePlanner
{
    Task<PreparePlan> CreatePlanAsync(
        ProjectInventory inventory,
        string? goal,
        CancellationToken cancellationToken);
}
