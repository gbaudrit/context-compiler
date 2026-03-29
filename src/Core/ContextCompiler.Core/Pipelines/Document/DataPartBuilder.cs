using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class DataPartBuilder : IDataPartBuilder
    {

        private string _id = string.Empty;
        private ISourceRef? _source;
        private string? _label;
        private object? _payload;
        private IReadOnlyList<ITag> _tags = [];

        public IDataPartBuilder InitNew()
        {
            _id = "";
            _source = null;
            _label = null;
            _payload = null;
            _tags = [];
            return this;
        }

        public IDataPartBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public IDataPartBuilder WithSource(ISourceRef source)
        {
            _source = source;
            return this;
        }

        public IDataPartBuilder WithLabel(string? label)
        {
            _label = label;
            return this;
        }

        public IDataPartBuilder WithPayload(object? payload)
        {
            _payload = payload;
            return this;
        }

        public IDataPartBuilder WithTags(IReadOnlyList<ITag> tags)
        {
            _tags = tags;
            return this;
        }

        public IDataPart Build()
        {
            ArgumentNullException.ThrowIfNull(_id);
            ArgumentNullException.ThrowIfNull(_source);

            return new DataPart(_id, _source, _payload ?? "", _label, _tags);
        }

    }
}

