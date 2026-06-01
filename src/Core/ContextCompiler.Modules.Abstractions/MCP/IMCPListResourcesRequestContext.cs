namespace ContextCompiler.Modules.Abstractions.MCP
{
    public interface IMCPListResourcesRequestContext
    {
        IMCPListResourceResultBuilder ResultBuilder { get; }
        IMCPResourceBuilder ResourceBuilder { get; }
    }
}
