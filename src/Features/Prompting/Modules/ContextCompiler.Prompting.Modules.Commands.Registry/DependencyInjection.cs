using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Prompting.Modules.Commands.Registry.Abstractions;
using ContextCompiler.Prompting.Modules.Commands.Registry.MCP.Handlers;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Prompting.Modules.Commands.Registry;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services
            .AddSingleton<ICommandsStore, CommandsStore>()
            .AddTransient<ICommandsIndexSerializer, CommandsIndexSerializer>()
            .AddTransient<IListCommands, ListCommands>();
    }
}
