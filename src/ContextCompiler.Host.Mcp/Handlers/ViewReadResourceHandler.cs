using ContextCompiler.Abstractions.Workspace;
using ContextCompiler.Modules.Abstractions.MCP;

using ModelContextProtocol;

namespace ContextCompiler.Host.Mcp.Handlers
{
    internal sealed class ViewReadResourceHandler(IWorkspaceAccessor workspace) : IMCPReadResourceHandler
    {
        private const string _matchingUri = "ctxc://view/";

        public bool CanProcess(IMCPReadResourceRequestContext context)
        {
            // Implement your logic to determine if this handler can process the request
            return context.Uri?.StartsWith(_matchingUri, StringComparison.OrdinalIgnoreCase) == true;
        }

        public Task<IMCPReadResourceResult> Process(IMCPReadResourceRequestContext context, CancellationToken cancellationToken)
        {
            // Implement your logic to process the request and return the result
            string? uri = context.Uri;
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new McpProtocolException("Missing uri", McpErrorCode.InvalidParams);
            }

            IWorkspaceView? view = workspace.Current.Views.FirstOrDefault(x => x.Name == context.Uri[_matchingUri.Length..]) ?? throw new McpProtocolException("Resource not found", McpErrorCode.ResourceNotFound);

            return Task.FromResult(context.ResultBuilder.InitNew()
                                                        .WithResourceContent(context.ResourceContentsBuilder.InitNew()
                                                                                                            .WithUri(uri)
                                                                                                            .WithMimeType("text/json")
                                                                                                            .WithText(view.Content)
                                                                                                            .Build())
                                                        .Build());
        }
    }
}
