using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules
{
    internal sealed class ModuleRestoreRequestBuilder(IModuleRestoreIdBuilder moduleRestoreIdBuilder, IModuleRestoreVersionBuilder moduleRestoreVersionBuilder) : IModuleRestoreRequestBuilder
    {

        internal sealed record ModuleRestoreRequest : IModuleRestoreRequest
        {
            public required IModuleRestoreId PackageId { get; init; }
            public required IModuleRestoreVersion Version { get; init; }
            public required string ExtractPath { get; init; }
        }

        private IModuleRestoreId? _packageId;
        private string? _packageIdId;
        private string? _packageChecksum;

        private IModuleRestoreSource? _source;
        private string? _sourceId;
        private string? _extractPath;
        private IModuleRestoreVersion? _version;
        private string? _versionRaw;
        private string? _versionMin;
        private string? _versionMax;
        private IModuleRestoreVersion.BoundOperator? _versionMinBoundOperator;
        private IModuleRestoreVersion.BoundOperator? _versionMaxBoundOperator;

        public IModuleRestoreRequestBuilder InitNew()
        {
            _packageId = null;
            _packageIdId = null;
            _packageChecksum = null;
            _source = null;
            _sourceId = null;
            _extractPath = null;
            _version = null;
            _versionRaw = null;
            _versionMin = null;
            _versionMax = null;
            _versionMinBoundOperator = null;
            _versionMaxBoundOperator = null;
            return this;
        }

        public IModuleRestoreRequestBuilder WithPackageId(IModuleRestoreId packageId)
        {
            _packageId = packageId;
            return this;
        }

        public IModuleRestoreRequestBuilder WithPackageIdId(string packageIdId)
        {
            _packageIdId = packageIdId;
            return this;
        }

        public IModuleRestoreRequestBuilder WithPackageChecksum(string packageChecksum)
        {
            _packageChecksum = packageChecksum;
            return this;
        }

        public IModuleRestoreRequestBuilder WithSource(IModuleRestoreSource source)
        {
            _source = source;
            return this;
        }


        public IModuleRestoreRequestBuilder WithSourceId(string sourceId)
        {
            _sourceId = sourceId;
            return this;
        }

        public IModuleRestoreRequestBuilder WithExtractPath(string extractPath)
        {
            _extractPath = extractPath;
            return this;
        }

        public IModuleRestoreRequestBuilder WithVersion(IModuleRestoreVersion version)
        {
            _version = version;
            return this;
        }

        public IModuleRestoreRequestBuilder WithVersionRaw(string versionRaw)
        {
            _versionRaw = versionRaw;
            return this;
        }

        public IModuleRestoreRequestBuilder WithVersionMin(string versionMin)
        {
            _versionMin = versionMin;
            return this;
        }

        public IModuleRestoreRequestBuilder WithVersionMax(string versionMax)
        {
            _versionMax = versionMax;
            return this;
        }

        public IModuleRestoreRequestBuilder WithVersionMinBoundOperator(IModuleRestoreVersion.BoundOperator versionMinBoundOperator)
        {
            _versionMinBoundOperator = versionMinBoundOperator;
            return this;
        }

        public IModuleRestoreRequestBuilder WithVersionMaxBoundOperator(IModuleRestoreVersion.BoundOperator versionMaxBoundOperator)
        {
            _versionMaxBoundOperator = versionMaxBoundOperator;
            return this;
        }


        public IModuleRestoreRequest Build()
        {
            return _packageId == null
                ? throw new InvalidOperationException("PackageId is required")
                : (IModuleRestoreRequest)new ModuleRestoreRequest
                {
                    PackageId = _packageId ?? moduleRestoreIdBuilder.InitNew()
                                                                    .WithId(_packageIdId ?? throw new InvalidOperationException("PackageIdId is required"))
                                                                    .WithSource(_source ?? new ModuleRestoreSource
                                                                    {
                                                                        Id = _sourceId ?? throw new InvalidOperationException("SourceId is required"),
                                                                    })
                                                                    .WithChecksum(_packageChecksum ?? throw new InvalidOperationException("PackageChecksum is required"))
                                                                    .Build(),
                    Version = _version ?? moduleRestoreVersionBuilder.InitNew()
                                                         .WithRaw(_versionRaw ?? throw new InvalidOperationException("VersionRaw is required"))
                                                         .WithMin(_versionMin ?? throw new InvalidOperationException("VersionMin is required"))
                                                         .WithMax(_versionMax ?? throw new InvalidOperationException("VersionMax is required"))
                                                         .WithMinBoundOperator(_versionMinBoundOperator ?? IModuleRestoreVersion.BoundOperator.Exactly)
                                                         .WithMaxBoundOperator(_versionMaxBoundOperator ?? IModuleRestoreVersion.BoundOperator.Exactly)
                                                         .Build(),
                    ExtractPath = _extractPath ?? throw new InvalidOperationException("ExtractPath is required")
                };
        }
    }
}
