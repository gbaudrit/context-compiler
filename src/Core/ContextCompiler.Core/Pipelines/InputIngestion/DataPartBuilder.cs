using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion
{
    internal sealed class DataPartBuilder : IDataPartBuilder
    {
        private string _id = string.Empty;
        private ISourceRef? _source;
        private string? _label;
        private object? _payload;
        private IReadOnlyList<ITag> _tags = [];
        private DataPartType _type = DataPartType.Undefined;
        private string? _groupId;

        public IDataPartBuilder InitNew()
        {
            _id = "";
            _source = null;
            _label = null;
            _payload = null;
            _tags = [];
            _type = DataPartType.Undefined;
            _groupId = null;
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

        public IDataPartBuilder WithType(DataPartType type)
        {
            _type = type;
            return this;
        }

        public IDataPartBuilder WithGroupId(string? groupId)
        {
            _groupId = groupId;
            return this;
        }

        public IDataPart Build()
        {
            ArgumentNullException.ThrowIfNull(_id);
            ArgumentNullException.ThrowIfNull(_source);

            return new DataPart(_id, _source, _payload ?? "", _type, _label, _tags, _groupId);
        }
    }
}
