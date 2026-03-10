using ContextCompiler.Modules.Artifacts.Registry.Models;

namespace ContextCompiler.Modules.Artifacts.Registry.Abstractions;

internal interface IListArtifacts
{
    Task<IReadOnlyList<Artifact>> Execute(CancellationToken cancellationToken);
}
