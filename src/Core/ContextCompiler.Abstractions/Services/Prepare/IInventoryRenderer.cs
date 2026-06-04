using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Services.Prepare;

public interface IInventoryRenderer
{
    Task RenderAsync(
        ProjectInventory inventory,
        CancellationToken cancellationToken);
}
