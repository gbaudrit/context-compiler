using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Commands;
using ContextCompiler.Prompting.Framing;
using ContextCompiler.Prompting.Personas;
using ContextCompiler.Prompting.Pipelines.PromptComposition;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Prompting;

public class DependencyInjection : IDependencyInjection, IDelayedFeatureDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        // Register core services here
        return services.AddPromptComposerPipeline()
                       .AddFraming()
                       .AddCommands()
                       .AddPersonas()
                       .AddSingleton<IPrompt, Prompt>();
    }

    public IServiceCollection DelayedRegisterServices(IServiceCollection services, IReadOnlyList<Type> modules)
    {
        foreach (Type t in modules)
        {
            if (typeof(ITemplateModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(ITemplateModule), t);
            }

            if (typeof(IPersonaModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IPersonaModule), t);
            }
            if (typeof(IPromptComposerModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IPromptComposerModule), t);
            }
        }

        return services;
    }
}
