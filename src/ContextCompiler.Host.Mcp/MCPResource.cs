using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp;

internal sealed record MCPResource : IMCPResource
{
    public required string Name { get; init; }

    public string? Title { get; init; }

    public required string Uri { get; init; }

    public string? Description { get; init; }

    public string? MimeType { get; init; }

    public long? Size { get; init; }
}
