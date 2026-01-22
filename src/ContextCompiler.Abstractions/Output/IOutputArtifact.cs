using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputArtifact
    {

        public string FileName { get; init; }
        public string Content { get; init; }

    }
}
