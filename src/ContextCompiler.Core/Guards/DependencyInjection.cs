using ContextCompiler.Abstractions.Guards;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Guards;

public static class DependencyInjection
{

    public static IServiceCollection AddGuards(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<IGuardian, Guardian>();
    }

}
