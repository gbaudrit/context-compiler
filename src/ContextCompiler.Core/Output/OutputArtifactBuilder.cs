using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Core.Output
{
    internal sealed class OutputArtifactBuilder : IOutputArtifactBuilder
    {
        private string? _fileName;
        private string? _content;
        private string? _description;
        private Type? _generatedBy;
        private string? _mimeType;
        private long? _size;

        public IOutputArtifactBuilder InitNew()
        {
            _fileName = null;
            _content = null;
            _description = null;
            _generatedBy = null;
            _mimeType = null;
            _size = null;
            return this;
        }

        public IOutputArtifactBuilder WithFileName(string fileName)
        {
            _fileName = fileName;
            return this;
        }

        public IOutputArtifactBuilder WithContent(string content)
        {
            _content = content;
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
            return new OutputArtifact
            {
                FileName = _fileName ?? throw new InvalidOperationException("FileName is not set"),
                Content = _content ?? throw new InvalidOperationException("Content is not set"),
                Description = _description ?? string.Empty,
                GeneratedBy = _generatedBy ?? throw new InvalidOperationException("GeneratedBy is not set"),
                MimeType = _mimeType ?? Path.GetExtension(_fileName) switch
                {
                    ".json" => "application/json",
                    ".txt" => "text/plain",
                    _ => "application/octet-stream"
                },
                Size = _size ?? _content.Length,
            };
        }
    }
}
