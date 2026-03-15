using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp;

internal sealed record MCPReadResourceResult : IMCPReadResourceResult
{

    public required IReadOnlyList<IMCPResourceContents> Contents { get; init; }

}
