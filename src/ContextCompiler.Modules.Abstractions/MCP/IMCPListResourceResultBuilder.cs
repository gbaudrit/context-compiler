
namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPListResourceResultBuilder
{
    IMCPListResourcesResult Build();
    IMCPListResourceResultBuilder InitNew();
    IMCPListResourceResultBuilder WithResources(IEnumerable<IMCPResource> resources);
}
