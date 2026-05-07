using ContextCompiler.Modules.Abstractions.MCP;
using ContextCompiler.Output.Modules.Artifacts.Registry.Abstractions;
using ContextCompiler.Output.Modules.Artifacts.Registry.Models;

namespace ContextCompiler.Output.Modules.Artifacts.Registry.MCP.Handlers;

internal sealed class ListArtifacts(IArtifactsStore artifactsStore) : IListArtifacts, IMCPListResourcesHandler
{
    public bool CanProcess(IMCPListResourcesRequestContext context)
    {
        return true;
    }

    public async Task<IReadOnlyList<Artifact>> Execute(CancellationToken cancellationToken)
    {
        return await artifactsStore.List(cancellationToken);
    }

    public async Task<IMCPListResourcesResult> GetResources(IMCPListResourcesRequestContext context, CancellationToken cancellationToken)
    {
        IReadOnlyList<Artifact> artifacts = await artifactsStore.List(cancellationToken);

        IEnumerable<IMCPResource> resources = artifacts.Select(x => context.ResourceBuilder.InitNew().WithName(x.Filename)
                                                                                                 .WithUri($"ctxc://artifact/{x.Filename}")
                                                                                                 .WithDescription(x.Description)
                                                                                                 .WithMimeType(x.MimeType)
                                                                                                 .WithSize(x.Size).Build());

        return context.ResultBuilder.WithResources(resources.ToList().AsReadOnly()).Build();
    }
}
