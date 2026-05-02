using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Sources;
using ContextCompiler.Abstractions.Tags;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class DocumentContextBuilder(IDocumentContextDataBuilder documentContextDataBuilder, ITagsBuilder tagsBuilder, IServiceProvider serviceProvider) : IDocumentContextBuilder
    {

        private string _inputRoot = "";
        private string _fullPath = "";
        private string _relativePath = "";
        private ISource? _source;
        private IDocumentContextData? _data;

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

        public IDocumentContextBuilder WithData(IDocumentContextData data)
        {
            _data = data;
            return this;
        }

        public IDocumentContextBuilder FromSource(ISource source)
        {
            _source = source;
            return this;
        }

        public IDocumentContext Build()
        {
            ArgumentNullException.ThrowIfNull(_source, nameof(_source));

            return new DocumentContext()
            {
                InputRoot = _inputRoot,
                FullPath = _fullPath,
                RelativePath = _relativePath,
                Source = _source,
                Data = _data ?? documentContextDataBuilder.InitNew().Build()
            };
        }

        public IDocumentContextBuilder InitFrom(IDocumentContext context)
        {
            _inputRoot = context.InputRoot;
            _fullPath = context.FullPath;
            _relativePath = context.RelativePath;
            _source = context.Source;
            return this;
        }
    }
}
