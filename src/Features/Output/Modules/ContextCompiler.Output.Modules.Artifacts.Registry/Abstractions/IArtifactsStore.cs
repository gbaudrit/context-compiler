using ContextCompiler.Abstractions.Common;
using ContextCompiler.Output.Modules.Artifacts.Registry.Models;

namespace ContextCompiler.Output.Modules.Artifacts.Registry.Abstractions;

internal interface IArtifactsStore
{

    Task<IReadOnlyList<Artifact>> List(CancellationToken cancellationToken);

    Task<IResult<Artifact>> TryGet(string id, CancellationToken cancellationToken);

}
