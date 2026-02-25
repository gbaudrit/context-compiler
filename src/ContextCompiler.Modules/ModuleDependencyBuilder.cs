using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules
{
    internal sealed class ModuleDependencyBuilder : IModuleDependencyBuilder
    {
        internal sealed record ModuleDependency : IModuleDependency
        {
            public required string Id { get; init; }
            public required string Version { get; init; }
        }

        private string _id = string.Empty;
        private string _version = string.Empty;

        public IModuleDependencyBuilder InitNew()
        {
            _id = string.Empty;
            _version = string.Empty;
            return this;
        }

        public IModuleDependencyBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public IModuleDependencyBuilder WithVersion(string version)
        {
            _version = version;
            return this;
        }

        public IModuleDependency Build()
        {
            return new ModuleDependency() { Id = _id, Version = _version };
        }

    }
}
