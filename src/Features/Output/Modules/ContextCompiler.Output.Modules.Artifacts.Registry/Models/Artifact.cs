namespace ContextCompiler.Output.Modules.Artifacts.Registry.Models;

internal sealed record Artifact
{
    public required string Filename { get; init; }
    public required string Description { get; init; }
    public required string MimeType { get; init; }
    public required long Size { get; init; }
    public required string GeneratedBy { get; init; }

}
