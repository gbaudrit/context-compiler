namespace ContextCompiler.Modules.Abstractions.MCP
{
    public interface IMCPPListResourceRequestContext
    {
        IMCPListResourceResultBuilder ResultBuilder { get; }
        IMCPResourceBuilder ResourceBuilder { get; }
    }
}
