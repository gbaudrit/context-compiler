using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules
{
    internal sealed class FromConfigurationSourcesProvider(IModulesLoadConfigProvider cfg, ISourceBuilder sourceBuilder) : IModulesSourcesProvider
    {
        private bool _initialized;

        private readonly List<IModuleSource> _sources = [];

        private void EnsureInitialize()
        {
            if (_initialized)
            {
                return;
            }

            _sources.AddRange(cfg.Current.Sources.Select(x => sourceBuilder.InitNew().WithId(x.Name).WithProvider(x.Provider).WithUrl(new Uri(x.Url)).Build()));
            _initialized = true;
        }

        public IModuleSource GetById(string id)
        {
            EnsureInitialize();
            return _sources.First(x => x.Id == id);
        }

        public bool Exists(string id)
        {
            EnsureInitialize();
            return _sources.Any(x => x.Id == id);
        }
    }
}
