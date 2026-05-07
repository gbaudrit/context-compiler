using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.Sources;
using ContextCompiler.Abstractions.Tags;

namespace ContextCompiler.Core.Pipelines.InputIngestion
{
    internal sealed class InputItemContextBuilder(IInputItemContextDataBuilder inputItemContextDataBuilder, ITagsBuilder tagsBuilder, IServiceProvider serviceProvider) : IInputItemContextBuilder
    {

        private string _inputRoot = "";
        private string _fullPath = "";
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

        public IInputItemContextBuilder WithFullPath(string fullPath)
        {
            _fullPath = fullPath;
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

            return new InputItemContext()
            {
                InputRoot = _inputRoot,
                FullPath = _fullPath,
                RelativePath = _relativePath,
                Source = _source,
                Data = _data ?? inputItemContextDataBuilder.InitNew().Build()
            };
        }

        public IInputItemContextBuilder InitFrom(IInputItemContext context)
        {
            _inputRoot = context.InputRoot;
            _fullPath = context.FullPath;
            _relativePath = context.RelativePath;
            _source = context.Source;
            return this;
        }
    }
}
