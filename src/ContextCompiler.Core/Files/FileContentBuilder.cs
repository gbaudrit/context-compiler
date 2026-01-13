using ContextCompiler.Abstractions.Files;

namespace ContextCompiler.Core.Files
{
    internal sealed class FileContentBuilder : IFileContentBuilder
    {
        private string _path = string.Empty;
        private string _mediaType = string.Empty;
        private Type? _readerType;
        private IReadOnlyDictionary<string, string>? _metadata = new Dictionary<string, string>();

        public IFileContentBuilder InitNew()
        {
            _path = string.Empty;
            _mediaType = string.Empty;
            _readerType = null;
            return this;
        }
        public IFileContentBuilder WithPath(string path)
        {
            _path = path;
            return this;
        }
        public IFileContentBuilder WithMediaType(string mediaType)
        {
            _mediaType = mediaType;
            return this;
        }
        public IFileContentBuilder WithReaderType<TReader>() where TReader : IFileReader
        {
            _readerType = typeof(TReader);
            return this;
        }
        
        public IFileContentBuilder WithMetadata(IReadOnlyDictionary<string, string>? metadata)
        {
            _metadata = metadata;
            return this;
        }

        public IFileInfos Build()
        {
            ArgumentNullException.ThrowIfNull(_readerType);

            return new FileContent(_path, _mediaType, _readerType, null, _metadata);
        }



    }
}
