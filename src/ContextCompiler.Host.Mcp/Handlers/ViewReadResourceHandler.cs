using ContextCompiler.Abstractions.Workspace;

using ModelContextProtocol;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;

namespace ContextCompiler.Host.Mcp.Handlers
{
    internal sealed class ViewReadResourceHandler(IWorkspaceAccessor workspace) : IReadResourceHandler
    {
        private const string _matchingUri = "ctxc://view/";

        public bool CanProcess(RequestContext<ReadResourceRequestParams> context)
        {
            // Implement your logic to determine if this handler can process the request
            return context.Params?.Uri?.StartsWith(_matchingUri, StringComparison.OrdinalIgnoreCase) == true;
        }

        public ValueTask<ReadResourceResult> Process(RequestContext<ReadResourceRequestParams> context, CancellationToken cancellationToken)
        {
            // Implement your logic to process the request and return the result
            string? uri = context.Params?.Uri;
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new McpProtocolException("Missing uri", McpErrorCode.InvalidParams);
            }

            IWorkspaceView? view = workspace.Current.Views.FirstOrDefault(x => x.Name == context.Params?.Uri[_matchingUri.Length..]) ?? throw new McpProtocolException("Resource not found", McpErrorCode.ResourceNotFound);

            return ValueTask.FromResult(new ReadResourceResult
            {
                Contents =
                [
                    new TextResourceContents
                    {
                        Uri = uri,
                        MimeType = "text/json",
                        Text = view.Content
                    }
                ]
            });
        }
    }
}
