using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.DependencyInjection;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Core;
using ContextCompiler.Core.DependencyInjectionBuilders;
using ContextCompiler.Infrastructure;
using ContextCompiler.Modules;
using ContextCompiler.Modules.Abstractions.Loading;
using ContextCompiler.Modules.Loader;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler;

internal sealed class ContextCompilerAutonomousServiceProviderCreator(IWorkingFolder workingFolder, IConfiguration configuration) : IContextCompilerAutonomousServiceProviderCreator
{
    public async Task<IServiceProvider> WithModulesLoaded(CancellationToken cancellationToken)
    {
        ServiceCollection services = new();
        IContextCompilerBuilder contextCompilerBuilder = services.AddDependencyInjectionBuilders();

        _ = contextCompilerBuilder.Services
            .AddLogging()
            .AddSingleton(workingFolder)
            .AddSingleton(configuration)
            .AddCoreServices()
            .AddModules()
            .AddModulesLoaderServices()
            .AddDefaultInfrastructure();

        ServiceProvider serviceProvider = contextCompilerBuilder.Services.BuildServiceProvider();

        IModulesLoader modulesLoader = serviceProvider.GetRequiredService<IModulesLoader>();
        IStore modulesStore = serviceProvider.GetRequiredKeyedService<IStore>(StoreKeys.Modules);

        _ = await modulesLoader.LoadFromFolder(contextCompilerBuilder, modulesStore.Uri.AbsolutePath, cancellationToken);

        return contextCompilerBuilder.Services.BuildServiceProvider();
    }
}
