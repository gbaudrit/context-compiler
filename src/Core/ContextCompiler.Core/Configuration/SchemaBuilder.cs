using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Core.Configuration
{
    internal sealed class SchemaBuilder : ISchemaBuilder
    {

        private string? _name;
        private string? _content;
        private string? _path;

        public ISchemaBuilder InitNew()
        {
            _name = null;
            _content = null;
            _path = null;
            return this;
        }

        public ISchemaBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ISchemaBuilder WithContent(string content)
        {
            _content = content;
            return this;
        }

        public ISchemaBuilder WithPath(string path)
        {
            _path = path;
            return this;
        }

        public ISchema Build()
        {
            ArgumentException.ThrowIfNullOrEmpty(_name);
            ArgumentException.ThrowIfNullOrEmpty(_content);
            ArgumentException.ThrowIfNullOrEmpty(_path);

            return new Schema
            {
                Name = _name,
                Content = _content,
                Path = _path
            };

        }
    }
}
