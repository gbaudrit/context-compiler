namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPListResourceResult
{
    IReadOnlyList<IMCPResource> Resources { get; }
}
