using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.NuGet;

public static class DependencyInjection
{

    public static IServiceCollection AddModulesNuGetRestoreServices(this IServiceCollection services)
    {
        return services.AddKeyedSingleton<IModulesStore, NuGetModuleStore>("nuget")
                       .AddSingleton<IPackageDownloader, PackageDownloader>()
                       .AddSingleton<INuGetMetadatasExtractor, NuGetMetadatasExtractor>();
    }

}
