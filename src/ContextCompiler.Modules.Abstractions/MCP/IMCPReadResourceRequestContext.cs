namespace ContextCompiler.Modules.Abstractions.MCP
{
    public interface IMCPReadResourceRequestContext
    {
        IMCPReadResourceResultBuilder ResultBuilder { get; }
        IMCPResourceContentsBuilder ResourceContentsBuilder { get; }
        string Uri { get; }
    }
}
