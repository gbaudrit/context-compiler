using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Abstractions.Services.Analyze;

public interface IAnalyzeRenderer
{
    Task RenderAsync(
        IStore rootStore,
        IStore prepareStore,
        ProjectInventory inventory,
        ProjectClassification classification,
        AnalyzePlan plan,
        CancellationToken cancellationToken);
}
