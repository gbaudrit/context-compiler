using Microsoft.Extensions.DependencyInjection;

using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.Datas.Transcoders.Tabular;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services;
    }
}
