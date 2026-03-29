using ContextCompiler.Abstractions.Prompt;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Framing
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddFraming(this IServiceCollection services)
        {
            // Register core services here
            return services.AddTransient<IObjectiveBuilder, ObjectiveBuilder>()
                           .AddTransient<IAssumptionBuilder, AssumptionBuilder>()
                           .AddTransient<IAudienceBuilder, AudienceBuilder>()
                           .AddTransient<IGlossaryTermBuilder, GlossaryTermBuilder>()
                           .AddTransient<IMustConstraintBuilder, MustConstraintBuilder>()
                           .AddTransient<IMustNotConstraintBuilder, MustNotConstraintBuilder>()
                           .AddTransient<ICommandBuilder, CommandBuilder>();
        }

    }
}
