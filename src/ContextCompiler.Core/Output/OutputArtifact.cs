using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Core.Output
{
    internal sealed class OutputArtifact : IOutputArtifact
    {
        public required string FileName { get; init; }
        public required string Content { get; init; }
    }
}
