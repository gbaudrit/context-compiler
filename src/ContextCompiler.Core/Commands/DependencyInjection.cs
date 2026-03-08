using ContextCompiler.Abstractions.Commands;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Commands;

public static class DependencyInjection
{

    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<ICommandsProvider, CommandsProvider>();
    }

}
