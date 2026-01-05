using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Output
{
    public interface IWrittenArtifact
    {
        string Path { get; }
    }
}
