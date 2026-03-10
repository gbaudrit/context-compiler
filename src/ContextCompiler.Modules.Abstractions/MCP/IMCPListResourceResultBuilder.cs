
namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPListResourceResultBuilder
{
    IMCPListResourceResult Build();
    IMCPListResourceResultBuilder InitNew();
    IMCPListResourceResultBuilder WithResources(IEnumerable<IMCPResource> resources);
}
