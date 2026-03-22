using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Mcp.Core.Resources;

internal sealed record TextResourceContents : ResourceContents, IMCPTextResourceContents
{
    public required string Text { get; init; }
}
