namespace ContextCompiler.Abstractions.Models.Analyze;

public sealed class AnalyzeRequest
{
    public required Uri SourceUri { get; init; }

    public string? Goal { get; init; }

    public string? Description { get; init; }
}
