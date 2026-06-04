using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Services.Prepare;

public interface IPrepareReportRenderer
{
    Task RenderAsync(
        PrepareRequest request,
        ProjectInventory inventory,
        ProjectClassification classification,
        PreparePlan plan,
        CancellationToken cancellationToken);
}
