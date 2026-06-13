using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Prepare.Modules.DotNet;

public interface IDotNetProjectAnalyzer
{
    Task<DotNetAnalysis> AnalyzeAsync(Uri sourceUri, ProjectInventory inventory, CancellationToken cancellationToken);
}
