using ContextCompiler.Abstractions.Prompt;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Framing
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddFraming(this IServiceCollection services)
        {
            // Register core services here
            services.AddTransient<IObjectiveBuilder, ObjectiveBuilder>();
            services.AddTransient<IAssumptionBuilder, AssumptionBuilder>();
            services.AddTransient<IAudienceBuilder, AudienceBuilder>();
            services.AddTransient<IGlossaryTermBuilder, GlossaryTermBuilder>();
            services.AddTransient<IMustConstraintBuilder, MustConstraintBuilder>();
            services.AddTransient<IMustNotConstraintBuilder, MustNotConstraintBuilder>();
            services.AddTransient<ICommandBuilder, CommandBuilder>();
            return services;
        }

    }
}
