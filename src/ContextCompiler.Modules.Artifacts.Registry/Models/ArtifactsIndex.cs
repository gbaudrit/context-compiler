namespace ContextCompiler.Modules.Artifacts.Registry.Models;

internal sealed record ArtifactsIndex
{

    public required IReadOnlyList<Artifact> Artifacts { get; init; }

}
