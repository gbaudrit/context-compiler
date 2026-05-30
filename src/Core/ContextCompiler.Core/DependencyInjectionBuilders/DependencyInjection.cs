using ContextCompiler.Abstractions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.DependencyInjectionBuilders;

public static class DependencyInjection
{

    public static IContextCompilerBuilder AddDependencyInjectionBuilders(this IServiceCollection services)
    {
        IContextCompilerBuilder contextCompilerBuilder = new ContextCompilerBuilder(services);
        _ = services.AddSingleton(contextCompilerBuilder)
                    .AddSingleton<IContextCompilerStorageBuilder, ContextCompilerStorageBuilder>();

        return contextCompilerBuilder;
    }

}
