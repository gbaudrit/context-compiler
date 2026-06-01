namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPReadResourceResult
{
    IReadOnlyList<IMCPResourceContents> Contents { get; }
}
