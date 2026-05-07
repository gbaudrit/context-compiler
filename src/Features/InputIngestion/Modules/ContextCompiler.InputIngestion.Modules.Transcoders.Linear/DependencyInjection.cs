using Microsoft.Extensions.DependencyInjection;

using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.InputIngestion.Modules.Transcoders.Linear;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services;
    }
}
