using ContextCompiler.Abstractions.Cli;
using ContextCompiler.Cli.Modules.Handlers;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Cli.Modules;

public static class DependencyInjection
{
    /// <summary>
    /// Registers the modules CLI handlers and contributes the <c>modules</c> top-level command
    /// to the unified <c>ctxc</c> CLI through DI.
    /// </summary>
    public static IServiceCollection AddModulesCli(this IServiceCollection services)
    {
        return services
            .AddSingleton<IRestoreHandler, RestoreHandler>()
            .AddSingleton<IVerifyHandler, VerifyHandler>()
            .AddSingleton<IListHandler, ListHandler>()
            .AddSingleton<IPurgeHandler, PurgeHandler>()
            .AddSingleton<IModulesPlanHandler, ModulesPlanHandler>()
            .AddSingleton<ISchemasAggregateHandler, SchemasAggregateHandler>()
            .AddSingleton<ICliCommandContributor, ModulesCliContributor>();
    }
}
