using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Abstractions.DependencyInjection;

public interface IContextCompilerBuilder
{

    IContextCompilerBuilder ConfigureStorage(Func<IContextCompilerStorageBuilder, IContextCompilerStorageBuilder> configure);

    IServiceCollection Services { get; }

}
