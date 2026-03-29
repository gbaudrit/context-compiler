using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Files
{
    internal sealed class FileReadResultBuilder : IFileReadResultBuilder
    {

        private IFileInfos? _documentContent;

        public IFileReadResultBuilder InitNew()
        {
            _documentContent = null;
            return this;
        }

        public IFileReadResultBuilder WithContent(IFileInfos content)
        {
            _documentContent = content;
            return this;
        }

        public IFileReadResult Build()
        {
            return _documentContent is null
                ? throw new InvalidOperationException("FileReadResultBuilder: DocumentContent is not set.")
                : (IFileReadResult)new FileReadResult() { Content = _documentContent };
        }

    }
}
