using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Core.Pipelines;
using ContextCompiler.Core.Pipelines.DataPart;
using ContextCompiler.Core.Pipelines.Document;

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
