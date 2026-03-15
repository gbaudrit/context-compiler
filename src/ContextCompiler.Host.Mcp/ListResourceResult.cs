using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp;

internal sealed record ListResourceResult : IMCPListResourcesResult
{
    public required IReadOnlyList<IMCPResource> Resources { get; init; }
}
