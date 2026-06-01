using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.MCP;
using ContextCompiler.Output.Modules.Artifacts.Registry.Abstractions;
using ContextCompiler.Output.Modules.Artifacts.Registry.MCP.Handlers;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Output.Modules.Artifacts.Registry;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services.AddSingleton<IArtifactsStore, ArtifactsStore>()
                       .AddTransient<IJsonIndexSerializer, JsonIndexSerializer>()
                       .AddTransient<IListArtifacts, ListArtifacts>()
                       .AddTransient<IMCPReadResourceHandler, ArtifactReadResourceHandler>();
    }
}
