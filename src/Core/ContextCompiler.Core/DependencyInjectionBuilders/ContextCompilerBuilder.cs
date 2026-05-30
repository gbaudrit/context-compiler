using ContextCompiler.Abstractions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.DependencyInjectionBuilders;

internal sealed class ContextCompilerBuilder(IServiceCollection services) : IContextCompilerBuilder
{

    public IServiceCollection Services => services;
    private IContextCompilerStorageBuilder storageBuilder = new ContextCompilerStorageBuilder();

    public IContextCompilerBuilder ConfigureStorage(Func<IContextCompilerStorageBuilder, IContextCompilerStorageBuilder> configure)
    {
        storageBuilder = configure(storageBuilder);
        return this;
    }
}
