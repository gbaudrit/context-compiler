using ContextCompiler.Modules.Artifacts.Registry.Models;

namespace ContextCompiler.Modules.Artifacts.Registry.Abstractions;

internal interface IArtifactsStore
{

    Task<IReadOnlyList<Artifact>> List(CancellationToken cancellationToken);

}
