using ContextCompiler.Abstractions.Personas;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Personas;

public static class DependencyInjection
{

    public static IServiceCollection AddPersonas(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<IPersonaResultBuilder, PersonaResultBuilder>();
    }

}
