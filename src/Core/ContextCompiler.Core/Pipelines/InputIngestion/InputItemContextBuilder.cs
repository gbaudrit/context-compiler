using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.Sources;
using ContextCompiler.Abstractions.Tags;

namespace ContextCompiler.Core.Pipelines.InputIngestion
{
    internal sealed class InputItemContextBuilder(IInputItemContextDataBuilder inputItemContextDataBuilder, ITagsBuilder tagsBuilder, IServiceProvider serviceProvider) : IInputItemContextBuilder
    {

        private string _inputRoot = "";
        private Uri? _uri;
        private string _relativePath = "";
        private ISource? _source;
        private IInputItemContextData? _data;

        public IInputItemContextBuilder InitNew()
        {
            return this;
        }
        public IInputItemContextBuilder WithInputRoot(string inputRoot)
        {
            _inputRoot = inputRoot;
            return this;
        }

        public IInputItemContextBuilder WithUri(Uri uri)
        {
            _uri = uri;
            return this;
        }

        public IInputItemContextBuilder WithRelativePath(string relativePath)
        {
            _relativePath = relativePath;
            return this;
        }

        public IInputItemContextBuilder WithData(IInputItemContextData data)
        {
            _data = data;
            return this;
        }

        public IInputItemContextBuilder FromSource(ISource source)
        {
            _source = source;
            return this;
        }

        public IInputItemContext Build()
        {
            ArgumentNullException.ThrowIfNull(_source, nameof(_source));
            ArgumentNullException.ThrowIfNull(_uri, nameof(_uri));

            return new InputItemContext()
            {
                InputRoot = _inputRoot,
                Uri = _uri,
                RelativePath = _relativePath,
                Source = _source,
                Data = _data ?? inputItemContextDataBuilder.InitNew().Build()
            };
        }

        public IInputItemContextBuilder InitFrom(IInputItemContext context)
        {
            _inputRoot = context.InputRoot;
            _uri = context.Uri;
            _relativePath = context.RelativePath;
            _source = context.Source;
            return this;
        }
    }
}
