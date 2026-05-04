using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Abstractions.Loading
{
    public interface IModuleRegistryBuilder
    {
        void RegisterModuleServices(IServiceCollection services, IEnumerable<Type> types);
        Task RunDelayedFeatureDependencyInjection(IServiceCollection services);
    }
}
