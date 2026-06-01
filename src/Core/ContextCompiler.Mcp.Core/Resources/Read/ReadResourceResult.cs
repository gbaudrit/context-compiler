using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Mcp.Core.Resources.Read;

internal sealed record ReadResourceResult : IMCPReadResourceResult
{

    public required IReadOnlyList<IMCPResourceContents> Contents { get; init; }

}
