using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules
{
    internal sealed class ModuleMetadatasBuilder : IModuleMetadatasBuilder
    {
        internal sealed record ModuleMetadatas : IModuleMetadatas
        {
            public required string Id { get; init; }
            public required string Source { get; init; }
            public required string[] Authors { get; init; }
            public Uri? RepositoryUrl { get; init; }
            public required IEnumerable<IModuleDependency> Dependencies { get; init; }
            public required IEnumerable<string> Files { get; init; }
            public required IModuleSignature Signature { get; init; }
            public required IModuleVersion Version { get; init; }
            public required string Checksum { get; init; }
        }

        internal sealed record ModuleSignature : IModuleSignature
        {
            public required bool IsSigned { get; init; }

            public bool Required { get; init; }

            public required string Note { get; init; }

            public required string SignerFingerprint { get; init; }
        }

        internal sealed record ModuleVersion : IModuleVersion
        {
            public required string Value { get; init; }
        }

        private string _id = string.Empty;
        private string _source = string.Empty;
        private string _version = string.Empty;
        private string[] _authors = [];
        private Uri? _repositoryUrl;
        private readonly List<IModuleDependency> _dependencies = [];
        private readonly List<string> _files = [];
        private bool _isSigned;
        private bool _requiredSignature;
        private string? _signatureNote;
        private string? _checksum;
        private string? _signerFingerprint;


        public IModuleMetadatasBuilder InitNew()
        {
            _id = string.Empty;
            _source = string.Empty;
            _version = string.Empty;
            _authors = [];
            _repositoryUrl = null;
            _dependencies.Clear();
            _files.Clear();
            _isSigned = false;
            _requiredSignature = false;
            _signatureNote = null;
            _signerFingerprint = null;
            _checksum = null;
            return this;
        }

        public IModuleMetadatasBuilder InitNewFrom(IModuleMetadatas moduleMetadatas)
        {
            _id = moduleMetadatas.Id;
            _source = moduleMetadatas.Source;
            _version = moduleMetadatas.Version.Value;
            _authors = moduleMetadatas.Authors;
            _repositoryUrl = moduleMetadatas.RepositoryUrl;
            _dependencies.Clear();
            _dependencies.AddRange(moduleMetadatas.Dependencies);
            _files.Clear();
            _files.AddRange(moduleMetadatas.Files);
            _isSigned = moduleMetadatas.Signature.IsSigned;
            _signatureNote = moduleMetadatas.Signature.Note;
            _requiredSignature = moduleMetadatas.Signature.Required;
            _signerFingerprint = moduleMetadatas.Signature.SignerFingerprint;
            _checksum = moduleMetadatas.Checksum;
            return this;
        }

        public IModuleMetadatasBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public IModuleMetadatasBuilder WithSource(string source)
        {
            _source = source;
            return this;
        }

        public IModuleMetadatasBuilder WithVersion(string version)
        {
            _version = version;
            return this;
        }

        public IModuleMetadatasBuilder WithAuthors(params string[] authors)
        {
            _authors = authors;
            return this;
        }

        public IModuleMetadatasBuilder WithRepositoryUrl(Uri? repositoryUrl)
        {
            _repositoryUrl = repositoryUrl;
            return this;
        }

        public IModuleMetadatasBuilder AddDependency(IModuleDependency dependency)
        {
            _dependencies.Add(dependency);
            return this;
        }

        public IModuleMetadatasBuilder WithDependencies(IEnumerable<IModuleDependency> dependencies)
        {
            _dependencies.AddRange(dependencies);
            return this;
        }

        public IModuleMetadatasBuilder AddFile(string file)
        {
            _files.Add(file);
            return this;
        }

        public IModuleMetadatasBuilder WithFiles(IEnumerable<string> files)
        {
            _files.AddRange(files);
            return this;
        }

        public IModuleMetadatasBuilder WithIsSigned(bool isSigned)
        {
            _isSigned = isSigned;
            return this;
        }

        public IModuleMetadatasBuilder WithSignatureNote(string? signatureNote)
        {
            _signatureNote = signatureNote;
            return this;
        }

        public IModuleMetadatasBuilder WithRequiredSignature(bool requiredSignature)
        {
            _requiredSignature = requiredSignature;
            return this;
        }

        public IModuleMetadatasBuilder WithSignerFingerprint(string signerFingerprint)
        {
            _signerFingerprint = signerFingerprint;
            return this;
        }


        public IModuleMetadatasBuilder WithChecksum(string checksum)
        {
            _checksum = checksum;
            return this;
        }

        public IModuleMetadatas Build()
        {
            return new ModuleMetadatas
            {
                Id = _id,
                Source = _source,
                Version = new ModuleVersion { Value = _version },
                Authors = _authors,
                RepositoryUrl = _repositoryUrl,
                Dependencies = _dependencies.AsReadOnly(),
                Files = _files.AsReadOnly(),
                Signature = new ModuleSignature
                {
                    IsSigned = _isSigned,
                    Note = _signatureNote ?? "",
                    Required = _requiredSignature,
                    SignerFingerprint = _signerFingerprint ?? ""
                },
                Checksum = _checksum ?? ""
            };
        }
    }
}
