using ContextCompiler.Abstractions.ReasoningIR;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.ReasoningIR;

public static class DependencyInjection
{

    public static IServiceCollection AddReasoningIR(this IServiceCollection services)
    {
        // Register core services here
        services.AddTransient<IEvidenceBuilder, EvidenceBuilder>()
            .AddTransient<IFragmentBuilder, FragmentBuilder>()
            .AddSingleton<IReasoningIr, ReasoningIr>();
        return services;
    }

}
