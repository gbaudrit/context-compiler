namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPReadResourceHandler
{

    bool CanProcess(IMCPReadResourceRequestContext context);

    Task<IMCPReadResourceResult> Process(IMCPReadResourceRequestContext context, CancellationToken cancellationToken);

}
