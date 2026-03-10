namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPListResourcesHandler
{
    bool CanProcess(IMCPPListResourceRequestContext context);

    Task<IMCPListResourceResult> GetResources(IMCPPListResourceRequestContext context, CancellationToken cancellationToken);
}
