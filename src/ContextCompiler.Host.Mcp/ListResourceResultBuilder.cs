using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp;

internal sealed class ListResourceResultBuilder : IMCPListResourceResultBuilder
{

    private IReadOnlyList<IMCPResource>? _resources;

    public IMCPListResourceResultBuilder InitNew()
    {
        _resources = null;
        return this;
    }

    public IMCPListResourceResultBuilder WithResources(IEnumerable<IMCPResource> resources)
    {
        _resources = resources.ToList().AsReadOnly();
        return this;
    }

    public IMCPListResourcesResult Build()
    {
        return new ListResourceResult
        {
            Resources = _resources ?? throw new InvalidOperationException("Resources is not set")
        };
    }


}
