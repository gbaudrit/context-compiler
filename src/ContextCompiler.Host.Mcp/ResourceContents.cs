using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp;

internal sealed record ResourceContents : IMCPResourceContents
{
    public required string Uri { get; init; }
    public required string MimeType { get; init; }
    public required string Text { get; init; }
}
