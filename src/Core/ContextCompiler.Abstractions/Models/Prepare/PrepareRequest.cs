namespace ContextCompiler.Abstractions.Models.Prepare;

public sealed class PrepareRequest
{
    public required Uri SourceUri { get; init; }

    public string? Goal { get; init; }

    public string? Description { get; init; }
}
