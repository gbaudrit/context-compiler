using ContextCompiler.Host.Cli.Services;
using ContextCompiler.Infrastructure.PluginLoading;
using ContextCompiler.Plugins.BuiltIn.FileReaders;

using Microsoft.Extensions.DependencyInjection;
namespace ContextCompiler.Host.Cli;

internal static class DependencyInjection
{
    public static IServiceCollection AddHostCliServices(this IServiceCollection services)
    {
        services.AddSingleton<IOutputPathResolver, OutputPathResolver>()
            .AddPluginLoadingServices();
        return services;
    }
}
