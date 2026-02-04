using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp;

internal sealed record TextResourceContents : ResourceContents, IMCPTextResourceContents
{
    public required string Text { get; init; }
}
