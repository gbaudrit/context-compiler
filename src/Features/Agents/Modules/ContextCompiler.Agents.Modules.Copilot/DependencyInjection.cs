using ContextCompiler.Abstractions.DependencyInjection;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Agents.Modules.Copilot;

/// <summary>
/// Extension methods for registering Copilot agent services.
/// </summary>
public class DependencyInjection : IDependencyInjection
{

    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services;
    }

    public IContextCompilerBuilder Configure(IContextCompilerBuilder context)
    {
        return context.ConfigureStorage(x =>
        {
            return x.UpdateStoreName(StoreKeys.Agents, ".agents");
        });
    }
}
