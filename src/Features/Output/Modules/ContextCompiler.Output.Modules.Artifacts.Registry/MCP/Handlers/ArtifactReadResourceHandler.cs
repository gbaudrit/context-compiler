using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Workspace;
using ContextCompiler.Modules.Abstractions.MCP;
using ContextCompiler.Output.Modules.Artifacts.Registry.Abstractions;
using ContextCompiler.Output.Modules.Artifacts.Registry.Models;

using ModelContextProtocol;

namespace ContextCompiler.Output.Modules.Artifacts.Registry.MCP.Handlers
{
    internal sealed class ArtifactReadResourceHandler(IArtifactsStore store, IOutputArtifactReader outputArtifactReader, IWorkspaceAccessor workspace) : IMCPReadResourceHandler
    {
        private const string _matchingUri = "ctxc://artifact/";

        public bool CanProcess(IMCPReadResourceRequestContext context)
        {
            // Implement your logic to determine if this handler can process the request
            return context.Uri?.StartsWith(_matchingUri, StringComparison.OrdinalIgnoreCase) == true;
        }

        public async Task<IMCPReadResourceResult> Process(IMCPReadResourceRequestContext context, CancellationToken cancellationToken)
        {
            // Implement your logic to process the request and return the result
            string? uri = context.Uri;
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new McpProtocolException("Missing uri", McpErrorCode.InvalidParams);
            }

            string id = uri[_matchingUri.Length..];

            IResult<Artifact> tryGetResult = await store.TryGet(id, cancellationToken);

            if (tryGetResult is ISuccessResult<Artifact> success)
            {
                IMCPReadResourceResult result = context.ResultBuilder.InitNew()
                                            .WithResourceContent(context.ResourceContentsBuilder.InitNew()
                                                                                            .WithUri(uri)
                                                                                            .WithMimeType("text/json")
                                                                                            .WithText(await outputArtifactReader.ReadAllText(success.Value.Filename, cancellationToken))
                                                                                            .Build())
                                                        .Build();
                return result;
            }
            else
            {
                throw new McpProtocolException("Resource not found", McpErrorCode.ResourceNotFound);
            }
        }
    }
}
