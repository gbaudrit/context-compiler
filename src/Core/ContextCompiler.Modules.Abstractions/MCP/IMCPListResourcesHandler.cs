namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPListResourcesHandler
{
    bool CanProcess(IMCPListResourcesRequestContext context);

    Task<IMCPListResourcesResult> GetResources(IMCPListResourcesRequestContext context, CancellationToken cancellationToken);
}
