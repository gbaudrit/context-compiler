using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Mcp.Core.Resources;

internal record ResourceContents : IMCPResourceContents
{
    public required string Uri { get; init; }
    public required string MimeType { get; init; }
}
