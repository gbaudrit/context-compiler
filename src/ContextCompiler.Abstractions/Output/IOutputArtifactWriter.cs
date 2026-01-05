using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputArtifactWriter
    {
        Task Write(string name, string content);
    }
}
