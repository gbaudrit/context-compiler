using ContextCompiler.Output.Modules.Artifacts.Registry.Models;

namespace ContextCompiler.Output.Modules.Artifacts.Registry.Abstractions;

internal interface IListArtifacts
{
    Task<IReadOnlyList<Artifact>> Execute(CancellationToken cancellationToken);
}
