using ContextCompiler.Infrastructure.ModuleLoading;

using Microsoft.Extensions.DependencyInjection;
using ContextCompiler.Cli.Services;
using ContextCompiler.Cli.Handlers;
namespace ContextCompiler.Cli;

internal static class DependencyInjection
{
    public static IServiceCollection AddHostCliServices(this IServiceCollection services)
    {
        return services.AddSingleton<IOutputPathResolver, OutputPathResolver>()
            .AddTransient<ICtxcConfigFilesAddHandler, ConfigFilesAddHandler>()
            .AddModuleLoadingServices();
    }
}
