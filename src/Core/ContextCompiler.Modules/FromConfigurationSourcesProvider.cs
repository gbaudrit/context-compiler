using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ContextCompiler.Modules
{
    internal sealed class FromConfigurationSourcesProvider(
        IOptions<ModulesConfig> cfgOptions,
        [FromKeyedServices(StoreKeys.Root)] IStore rootStore,
        ISourceBuilder sourceBuilder) : IModulesSourcesProvider
    {
        private bool _initialized;

        private readonly List<IModuleSource> _sources = [];

        private void EnsureInitialize()
        {
            if (_initialized)
            {
                return;
            }

            _sources.AddRange(cfgOptions.Value.Sources.Select(x => sourceBuilder.InitNew()
                                                                                .WithId(x.Name)
                                                                                .WithProvider(x.Provider)
                                                                                .WithUrl(ToUri(x.Url))
                                                                                .WithValidatePackagesSignature(x.ValidatePackagesSignature)
                                                                                .Build()));
            _initialized = true;
        }

        public IModuleSource GetById(string id)
        {
            EnsureInitialize();
            return _sources.First(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));
        }

        public bool Exists(string id)
        {
            EnsureInitialize();
            return _sources.Any(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));
        }

        private Uri ToUri(string value)
        {
            return Uri.TryCreate(value, UriKind.Absolute, out Uri? uri)
                ? uri
                : new Uri(rootStore.Container.GetResource(value).Uri.AbsolutePath);
        }

        public IEnumerable<IModuleSource> GetAllOrdered()
        {
            EnsureInitialize();
            return _sources;
        }
    }
}
