using ContextCompiler.Abstractions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IDependencyInjection
    {
        IServiceCollection RegisterServices(IServiceCollection services);

        IContextCompilerBuilder Configure(IContextCompilerBuilder context)
        {
            return context;
        }
    }
}
