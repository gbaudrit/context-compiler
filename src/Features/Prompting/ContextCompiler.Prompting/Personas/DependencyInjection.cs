using ContextCompiler.Prompting.Abstractions.Personas;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Prompting.Personas;

public static class DependencyInjection
{

    public static IServiceCollection AddPersonas(this IServiceCollection services)
    {
        // Register core services here
        return services
            .AddSingleton<IPersonasProvider, PersonasProvider>()
            .AddSingleton<IPersonaBuilder, PersonaResultBuilder>();
    }

}
