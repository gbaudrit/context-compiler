namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPListResourcesResult
{
    IReadOnlyList<IMCPResource> Resources { get; }
}
