using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class DataPartBuilder : IDataPartBuilder
    {

        private string _id = string.Empty;
        private ISourceRef? _source;
        private string? _label;
        private object? _payload;

        public IDataPartBuilder InitNew()
        {
            _id = "";
            _source = null;
            _label = null;
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

        public IDataPart Build()
        {
            ArgumentNullException.ThrowIfNull(_id);
            ArgumentNullException.ThrowIfNull(_source);

            return new DataPart(_id, _source, _label);
        }

    }
}

