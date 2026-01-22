using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Core.Output
{
    internal sealed class OutputArtifactBuilder : IOutputArtifactBuilder
    {
        private string? _fileName;
        private string? _content;

        public IOutputArtifactBuilder InitNew()
        {
            _fileName = null;
            _content = null;
            return this;
        }

        public IOutputArtifactBuilder WithFileName(string fileName)
        {
            _fileName = fileName;
            return this;
        }

        public IOutputArtifactBuilder WithContent(string content)
        {
            _content = content;
            return this;
        }

        public IOutputArtifact Build()
        {
            return new OutputArtifact
            {
                FileName = _fileName ?? throw new InvalidOperationException("FileName is not set"),
                Content = _content ?? throw new InvalidOperationException("Content is not set")
            };
        }
    }
}
