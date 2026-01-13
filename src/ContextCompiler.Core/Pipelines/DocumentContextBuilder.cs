using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Tags;

namespace ContextCompiler.Core.Pipelines
{
    internal sealed class DocumentContextBuilder(ITagsBuilder tagsBuilder, IServiceProvider serviceProvider) : IDocumentContextBuilder
    {

        private string _inputRoot = "";
        private string _fullPath = "";
        private string _relativePath = "";

        public IDocumentContextBuilder InitNew()
        {
            return this;
        }
        public IDocumentContextBuilder WithInputRoot(string inputRoot)
        {
            _inputRoot = inputRoot;
            return this;
        }

        public IDocumentContextBuilder WithFullPath(string fullPath)
        {
            _fullPath = fullPath;
            return this;
        }

        public IDocumentContextBuilder WithRelativePath(string relativePath)
        {
            _relativePath = relativePath;
            return this;
        }

        public IDocumentContext Build()
        {
            return new DocumentContext(tagsBuilder, serviceProvider)
            {
                InputRoot = _inputRoot,
                FullPath = _fullPath,
                RelativePath = _relativePath
            };
        }
    }
}
