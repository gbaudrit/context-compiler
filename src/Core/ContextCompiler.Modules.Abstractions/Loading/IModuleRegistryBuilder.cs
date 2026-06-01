using ContextCompiler.Abstractions.DependencyInjection;

namespace ContextCompiler.Modules.Abstractions.Loading
{
    public interface IModuleRegistryBuilder
    {
        void RegisterModuleServices(IContextCompilerBuilder contextCompilerBuilder, IEnumerable<Type> types);
        Task RunDelayedFeatureDependencyInjection(IContextCompilerBuilder contextCompilerBuilder);
    }
}
