using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Services.Prepare;

public interface IConfigurationRenderer
{
    Task RenderAsync(
        PreparePlan plan,
        CancellationToken cancellationToken);
}
