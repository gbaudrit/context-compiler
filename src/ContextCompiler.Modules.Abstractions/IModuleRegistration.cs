using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IModuleRegistration
    {
        IServiceCollection RegisterServices(IServiceCollection services);
    }
}
