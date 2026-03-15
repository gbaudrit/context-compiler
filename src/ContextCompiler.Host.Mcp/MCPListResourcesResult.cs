using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp;

internal sealed record MCPListResourcesResult : IMCPListResourcesResult
{
    public required IReadOnlyList<IMCPResource> Resources { get; init; }
}
