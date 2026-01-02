using ContextCompiler.Host.Cli.Services;
using Microsoft.Extensions.DependencyInjection;
namespace ContextCompiler.Host.Cli;

internal static class DependencyInjection
{
    public static IServiceCollection AddHostCliServices(this IServiceCollection services)
    {
        services.AddSingleton<IOutputPathResolver, OutputPathResolver>();
        return services;
    }
}
