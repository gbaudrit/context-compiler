using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Mcp.Core.Resources.List;

internal sealed record ListResourceResult : IMCPListResourcesResult
{
    public required IReadOnlyList<IMCPResource> Resources { get; init; }
}
