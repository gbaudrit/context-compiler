using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp;

internal sealed record MCPListResourceResult : IMCPListResourceResult
{
    public required IReadOnlyList<IMCPResource> Resources { get; init; }
}
