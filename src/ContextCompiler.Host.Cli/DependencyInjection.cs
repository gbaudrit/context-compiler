using ContextCompiler.Host.Cli.Services;
using ContextCompiler.Infrastructure.ModuleLoading;
using ContextCompiler.Host.Cli.Handlers;

using Microsoft.Extensions.DependencyInjection;
namespace ContextCompiler.Host.Cli;

internal static class DependencyInjection
{
    public static IServiceCollection AddHostCliServices(this IServiceCollection services)
    {
        return services.AddSingleton<IOutputPathResolver, OutputPathResolver>()
            .AddTransient<ICtxcConfigFilesAddHandler, ConfigFilesAddHandler>()
            .AddModuleLoadingServices();
    }
}
