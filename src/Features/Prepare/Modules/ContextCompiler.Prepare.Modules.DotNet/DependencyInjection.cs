using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Prepare.Modules.DotNet;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services.AddTransient<IDotNetProjectAnalyzer, DotNetProjectAnalyzer>();
    }
}
