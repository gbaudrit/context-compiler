using Microsoft.Extensions.DependencyInjection;

using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.Connectors.Git;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services.AddSingleton<IGitProcessClient, GitProcessClient>();
    }
}
