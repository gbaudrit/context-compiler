using ContextCompiler.Prompting.Abstractions.Commands;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Prompting.Commands;

public static class DependencyInjection
{

    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<ICommandsProvider, CommandsProvider>();
    }

}
