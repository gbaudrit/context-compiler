using Microsoft.Extensions.DependencyInjection;

using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.DevTools.SourcesConsole;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services;
    }
}
