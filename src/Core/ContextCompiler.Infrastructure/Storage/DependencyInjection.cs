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
                ICtxcWorkingFolder ctxcWorkingFolder = sp.GetRequiredService<ICtxcWorkingFolder>();

                IStoreConfiguration rootStoreConfiguration = storeConfigurationBuilder.InitNew()
                    .WithRootUri(new FileSystemStoreResourceUri() { Uri = new Uri(ctxcWorkingFolder.Path + "/") })
                    .Build();

                return rootStoreConfiguration;
            });

            _ = services.AddKeyedSingleton<IStore, FileSystemStore>(StoreKeys.Root);


            services.TryAddDefaultStore(StoreKeys.Output)
                    .TryAddDefaultStore(StoreKeys.Modules)
                    .TryAddDefaultStore(StoreKeys.Reports)
                    .TryAddDefaultStore(StoreKeys.Cache)
                    .TryAddDefaultStore(StoreKeys.Diagnostics)
                    .TryAddDefaultStore(StoreKeys.Externals)
                    .TryAddDefaultStore(StoreKeys.Temp)
                    .TryAddDefaultStore(StoreKeys.Agents, StoreKeys.Output)
                    .TryAddDefaultStore(StoreKeys.Skills, StoreKeys.Agents)
                    .TryAddSingleton<IStoreResourceBuilder, StoreResourceBuilder>();

            return services;
        }

        private static IServiceCollection TryAddDefaultStore(this IServiceCollection services, string storeKey)
        {
            return services.TryAddDefaultStore(storeKey, StoreKeys.Root);
        }

        private static IServiceCollection TryAddDefaultStore(this IServiceCollection services, string storeKey, string parentKey)
        {
            services.TryAddKeyedSingleton<IStore>(storeKey, (sp, o) =>
            {
                IStore parent = sp.GetRequiredKeyedService<IStore>(parentKey);
                IStoreConfiguration storeConfiguration = sp.GetRequiredKeyedService<IStoreConfiguration>(storeKey);
                FileSystemStore store = new(storeConfiguration.Name, sp);
                store.Init().GetAwaiter().GetResult();
                return store;
            });

            services.TryAddKeyedSingleton(storeKey, (sp, o) =>
            {
                IStoreConfigurationBuilder storeConfigurationBuilder = sp.GetRequiredService<IStoreConfigurationBuilder>();
                ICtxcWorkingFolder ctxcWorkingFolder = sp.GetRequiredService<ICtxcWorkingFolder>();
                IStoreConfiguration parentConfiguration = sp.GetRequiredKeyedService<IStoreConfiguration>(parentKey);

                IStoreConfiguration storeConfiguration = storeConfigurationBuilder.InitNew()
                    .WithParentId(parentKey)
                    .WithRootUri(parentConfiguration.Uri)
                    .WithName(storeKey)
                    .Build();

                return storeConfiguration;
            });
            return services;
        }

    }
}
