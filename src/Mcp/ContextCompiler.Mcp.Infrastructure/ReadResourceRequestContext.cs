using ContextCompiler.Modules.Abstractions.MCP;

using Microsoft.Extensions.DependencyInjection;

using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;

namespace ContextCompiler.Mcp.Infrastructure;

internal sealed class ReadResourceRequestContext(RequestContext<ReadResourceRequestParams> context) : IMCPReadResourceRequestContext
{

    public string Uri => context.Params?.Uri ?? "";

    public IMCPReadResourceResultBuilder ResultBuilder { get; } = context.Services?.GetRequiredService<IMCPReadResourceResultBuilder>() ?? throw new InvalidOperationException("IMCPReadResourceResultBuilder not found");
    public IMCPResourceContentsBuilder ResourceContentsBuilder { get; } = context.Services?.GetRequiredService<IMCPResourceContentsBuilder>() ?? throw new InvalidOperationException("IMCPResourceContentsBuilder not found");


}
