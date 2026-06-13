using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.DependencyInjection;
using ContextCompiler.Core;
using ContextCompiler.Core.DependencyInjectionBuilders;
using ContextCompiler.Core.Storage;
using ContextCompiler.Infrastructure;
using ContextCompiler.Modules;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;
using ContextCompiler.Modules.Loader;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler;

public static class DependencyInjection
{

    public static IServiceCollection AddContextCompiler(this IServiceCollection services)
    {
        return services.AddSingleton<IContextCompilerAutonomousServiceProviderCreator, ContextCompilerAutonomousServiceProviderCreator>();
    }

    public static IContextCompilerBuilder AddRequiredServicesForLoadModules(this IServiceCollection services, IServiceProvider rootServiceProvider)
    {
        IContextCompilerBuilder contextCompilerBuilder = services.AddDependencyInjectionBuilders();
        IWorkingFolder workingFolder = rootServiceProvider.GetRequiredService<IWorkingFolder>();
        IConfiguration configuration = rootServiceProvider.GetRequiredService<IConfiguration>();

        _ = services.AddSingleton(workingFolder)
            .AddSingleton(configuration)
            .AddCoreServices()
            .AddModules()
            .AddModulesLoaderServices()
            .AddDefaultInfrastructure();

        return contextCompilerBuilder;
    }

    public static IContextCompilerBuilder AddWorkspaceModules(this IContextCompilerBuilder contextCompilerBuilder, IWorkingFolder workingFolder, IConfiguration configuration, string scope, CancellationToken cancellationToken)
    {
        IServiceCollection modulesLoaderServices = new ServiceCollection();
        _ = modulesLoaderServices.AddContextCompiler()
                             .AddLogging()
                             .AddSingleton(configuration)
                             .AddCoreServices()
                             .AddStorage()
                             .AddModulesLoaderServices()
                             .AddDefaultInfrastructure()
                             .AddSingleton(workingFolder)
                             .Configure<ModulesConfig>(options =>
                             {
                                 options.ActiveScope = scope;
                             });

        IServiceProvider modulesLoaderServicesProvider = modulesLoaderServices.BuildServiceProvider();
        IModulesLoader modulesLoader = modulesLoaderServicesProvider.GetRequiredService<IModulesLoader>();

        modulesLoader.LoadFromFolder(contextCompilerBuilder, Path.Combine(workingFolder.Path, ".ctxc", "modules"), CancellationToken.None).Wait(cancellationToken);
        //modulesLoader.LoadFromAssemblies(contextCompilerBuilder, assemblies).Wait(cancellationToken);
        return contextCompilerBuilder;
    }



}
