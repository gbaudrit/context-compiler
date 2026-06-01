using ContextCompiler.Modules.Abstractions.MCP;

using Microsoft.Extensions.DependencyInjection;

using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;

namespace ContextCompiler.Mcp.Infrastructure;

internal sealed class RequestContext(RequestContext<ListResourcesRequestParams> context) : IMCPPListResourceRequestContext
{

    public IMCPListResourceResultBuilder ResultBuilder { get; } = context.Services?.GetRequiredService<IMCPListResourceResultBuilder>() ?? throw new InvalidOperationException("IMCPListResourceResultBuilder not found");
    public IMCPResourceBuilder ResourceBuilder { get; } = context.Services?.GetRequiredService<IMCPResourceBuilder>() ?? throw new InvalidOperationException("IMCPResourceBuilder not found");


}
