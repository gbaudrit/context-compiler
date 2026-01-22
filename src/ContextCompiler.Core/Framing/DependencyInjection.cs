using ContextCompiler.Abstractions.Prompt;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Framing
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddFraming(this IServiceCollection services)
        {
            // Register core services here
            services.AddSingleton<IObjectiveBuilder, ObjectiveBuilder>();
            services.AddSingleton<IAssumptionBuilder, AssumptionBuilder>();
            services.AddSingleton<IAudienceBuilder, AudienceBuilder>();
            services.AddSingleton<IGlossaryTermBuilder, GlossaryTermBuilder>();
            return services;
        }

    }
}
