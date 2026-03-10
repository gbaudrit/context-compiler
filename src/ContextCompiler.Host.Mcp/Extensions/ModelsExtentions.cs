using ContextCompiler.Abstractions.Workspace;
using ContextCompiler.Modules.Abstractions.MCP;

using ModelContextProtocol.Protocol;

namespace ContextCompiler.Host.Mcp.Extensions;

internal static class ModelsExtentions
{

    public static Resource ToResource(this IWorkspaceView view)
    {
        return new Resource
        {
            Name = view.Name,
            Description = view.Description,
            MimeType = "application/json",
            Uri = $"ctxc://view/{view.Name}"
        };
    }
    public static Resource ToResource(this IMCPResource mcpResource)
    {
        return new Resource
        {
            Name = mcpResource.Name,
            Description = mcpResource.Description,
            MimeType = mcpResource.MimeType,
            Uri = mcpResource.Uri
        };
    }

}
