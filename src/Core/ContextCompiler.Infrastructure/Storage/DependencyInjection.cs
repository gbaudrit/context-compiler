using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Storage;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContextCompiler.Infrastructure.Storage
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddFileSystemStorage(this IServiceCollection services)
        {
            services.TryAddKeyedSingleton(StoreKeys.Root, (sp, o) =>
            {
                IStoreConfigurationBuilder storeConfigurationBuilder = sp.GetRequiredService<IStoreConfigurationBuilder>();
                ICompiledWorkingFolder ctxcCompiledWorkingFolder = sp.GetRequiredService<ICompiledWorkingFolder>();

                IStoreConfiguration rootStoreConfiguration = storeConfigurationBuilder.InitNew()
                    .WithRootUri(new FileSystemStoreResourceUri() { Uri = new Uri(ctxcCompiledWorkingFolder.Path) })
                    .Build();

                return rootStoreConfiguration;
            });


            services.TryAddDefaultStore(StoreKeys.Output)
                    .TryAddDefaultStore(StoreKeys.Modules)
                    .TryAddDefaultStore(StoreKeys.Reports)
                    .TryAddDefaultStore(StoreKeys.Cache)
                    .TryAddDefaultStore(StoreKeys.Diagnostics)
                    .TryAddDefaultStore(StoreKeys.Externals)
                    .TryAddDefaultStore(StoreKeys.Temp)
                    .TryAddSingleton<IStoreResourceBuilder, StoreResourceBuilder>();

            return services;
        }

        private static IServiceCollection TryAddDefaultStore(this IServiceCollection services, string storeKey)
        {
            services.TryAddKeyedSingleton<IStore, FileSystemStore>(storeKey);
            services.TryAddKeyedSingleton(storeKey, (sp, o) =>
            {
                IStoreConfigurationBuilder storeConfigurationBuilder = sp.GetRequiredService<IStoreConfigurationBuilder>();
                ICtxcWorkingFolder ctxcWorkingFolder = sp.GetRequiredService<ICtxcWorkingFolder>();
                IStoreConfiguration parentConfiguration = sp.GetRequiredKeyedService<IStoreConfiguration>(StoreKeys.Root);

                IStoreConfiguration rootStoreConfiguration = storeConfigurationBuilder.InitNew()
                    .WithParentId(StoreKeys.Root)
                    .WithRootUri(parentConfiguration.Root)
                    .Build();

                return rootStoreConfiguration;
            });
            return services;
        }

    }
}
