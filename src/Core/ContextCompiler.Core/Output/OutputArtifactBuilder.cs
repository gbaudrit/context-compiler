using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Storage;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Output
{
    internal sealed class OutputArtifactBuilder(IServiceProvider services, IStoreResourceBuilder storeResourceBuilder) : IOutputArtifactBuilder
    {
        private string? _name;
        private string? _storeKey;
        private IStoreResource? _storeResource;
        private string? _content;
        public bool _isStreamed;
        private string? _description;
        private Type? _generatedBy;
        private string? _mimeType;
        private long? _size;

        public IOutputArtifactBuilder InitNew()
        {
            _storeKey = null;
            _storeResource = null;
            _name = null;
            _content = null;
            _isStreamed = false;
            _description = null;
            _generatedBy = null;
            _mimeType = null;
            _size = null;
            return this;
        }

        public IOutputArtifactBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public IOutputArtifactBuilder WithStoreResource(IStoreResource storeResource)
        {
            _storeResource = storeResource;
            return this;
        }

        public IOutputArtifactBuilder InStore(string storeKey)
        {
            _storeKey = storeKey;
            return this;
        }

        public IOutputArtifactBuilder WithContent(string content)
        {
            _content = content;
            return this;
        }

        public IOutputArtifactBuilder IsStreamedContent()
        {
            _isStreamed = true;
            return this;
        }


        public IOutputArtifactBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public IOutputArtifactBuilder WithGeneratedBy(Type generatedBy)
        {
            _generatedBy = generatedBy;
            return this;
        }

        public IOutputArtifactBuilder WithMimeType(string mimeType)
        {
            _mimeType = mimeType;
            return this;
        }

        public IOutputArtifactBuilder WithSize(long size)
        {
            _size = size;
            return this;
        }

        public IOutputArtifact Build()
        {
            string content = _content ?? (!_isStreamed ? throw new InvalidOperationException("Content is not set") : string.Empty);

            if (_storeResource == null)
            {
                if (string.IsNullOrEmpty(_name))
                {
                    throw new InvalidOperationException("Name must be set if StoreResource is not provided");
                }
                if (string.IsNullOrEmpty(_storeKey))
                {
                    throw new InvalidOperationException("StoreKey must be set if StoreResource is not provided");
                }

                IStore store = services.GetRequiredKeyedService<IStore>(_storeKey);
                _storeResource = store.GetResource(_name);
            }

            return new OutputArtifact
            {
                StoreResource = _storeResource ?? throw new InvalidOperationException("StoreResource is not set"),
                Content = content + _storeKey,
                Description = _description ?? string.Empty,
                GeneratedBy = _generatedBy ?? throw new InvalidOperationException("GeneratedBy is not set"),
                MimeType = _mimeType ?? Path.GetExtension(_name) switch
                {
                    ".json" => "application/json",
                    ".txt" => "text/plain",
                    _ => "application/octet-stream"
                },
                Size = _size ?? content.Length,
            };
        }
    }
}
