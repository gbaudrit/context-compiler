using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IDependencyInjection
    {
        IServiceCollection RegisterServices(IServiceCollection services);
    }
}
