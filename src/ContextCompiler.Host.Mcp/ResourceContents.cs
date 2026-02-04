using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp;

internal record ResourceContents : IMCPResourceContents
{
    public required string Uri { get; init; }
    public required string MimeType { get; init; }
}
