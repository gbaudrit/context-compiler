using ContextCompiler.Host.Cli.Services;
using ContextCompiler.Infrastructure.PluginLoading;

using Microsoft.Extensions.DependencyInjection;
namespace ContextCompiler.Host.Cli;

internal static class DependencyInjection
{
    public static IServiceCollection AddHostCliServices(this IServiceCollection services)
    {
        return services.AddSingleton<IOutputPathResolver, OutputPathResolver>()
            .AddPluginLoadingServices();
    }
}
