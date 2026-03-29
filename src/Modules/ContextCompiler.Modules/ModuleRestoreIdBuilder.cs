using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules
{
    internal sealed class ModuleRestoreIdBuilder : IModuleRestoreIdBuilder
    {

        internal sealed record ModuleRestoreId : IModuleRestoreId
        {
            public required string Id { get; init; }

            public required IModuleRestoreSource Source { get; init; }

            public required string Checksum { get; init; }
        }

        private string? _id;
        private IModuleRestoreSource? _source;
        private string? _checksum;

        public IModuleRestoreIdBuilder InitNew()
        {
            _id = null;
            _source = null;
            _checksum = null;
            return this;
        }

        public IModuleRestoreIdBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public IModuleRestoreIdBuilder WithSource(IModuleRestoreSource source)
        {
            _source = source;
            return this;
        }

        public IModuleRestoreIdBuilder WithChecksum(string checksum)
        {
            _checksum = checksum;
            return this;
        }

        public IModuleRestoreId Build()
        {
            return new ModuleRestoreId
            {
                Id = _id ?? throw new InvalidOperationException("Id must be set before building."),
                Source = _source ?? throw new InvalidOperationException("Source must be set before building."),
                Checksum = _checksum ?? string.Empty
            };
        }

    }
}
