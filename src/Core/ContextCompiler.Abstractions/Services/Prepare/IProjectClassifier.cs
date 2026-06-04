using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Services.Prepare;

public interface IProjectClassifier
{
    Task<ProjectClassification> ClassifyAsync(
        ProjectInventory inventory,
        CancellationToken cancellationToken);
}
