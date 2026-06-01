using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IDelayedFeatureDependencyInjection
    {
        IServiceCollection DelayedRegisterServices(IServiceCollection services, IReadOnlyList<Type> modules);
    }
}
