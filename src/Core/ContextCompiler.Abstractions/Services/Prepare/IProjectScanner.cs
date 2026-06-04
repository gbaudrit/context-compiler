using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Services.Prepare;

public interface IProjectScanner
{
    Task<ProjectInventory> ScanAsync(
        Uri sourceUri,
        CancellationToken cancellationToken);
}
