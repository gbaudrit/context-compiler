using ContextCompiler.Abstractions.Compiled;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.CompiledContext;

public static class DependencyInjection
{

    public static IServiceCollection AddCompiledContext(this IServiceCollection services)
    {
        // Register core services here
        return services.AddTransient<IEvidenceBuilder, EvidenceBuilder>()
            .AddTransient<IFragmentBuilder, FragmentBuilder>()
            .AddSingleton<ICompiledContext, CompiledContext>()
            .AddTransient<ICompiledContextGraphComputer, CompiledContextGraphComputer>();
    }

}
