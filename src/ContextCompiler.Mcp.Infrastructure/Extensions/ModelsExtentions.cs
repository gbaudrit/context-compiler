using ContextCompiler.Abstractions.Workspace;
using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Mcp.Infrastructure.Extensions;

internal static class ModelsExtentions
{

    public static ModelContextProtocol.Protocol.Resource ToResource(this IWorkspaceView view)
    {
        return new ModelContextProtocol.Protocol.Resource
        {
            Name = view.Name,
            Description = view.Description,
            MimeType = "application/json",
            Uri = $"ctxc://view/{view.Name}"
        };
    }
    public static ModelContextProtocol.Protocol.Resource ToResource(this IMCPResource mcpResource)
    {
        return new ModelContextProtocol.Protocol.Resource
        {
            Name = mcpResource.Name,
            Description = mcpResource.Description,
            MimeType = mcpResource.MimeType,
            Uri = mcpResource.Uri
        };
    }

}
