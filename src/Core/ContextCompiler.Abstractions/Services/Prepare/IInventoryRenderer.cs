using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Abstractions.Services.Prepare;

public interface IInventoryRenderer
{
    Task RenderAsync(
        IStore outputStore,
        ProjectInventory inventory,
        CancellationToken cancellationToken);
}
