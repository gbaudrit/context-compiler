using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputArtifactCreator<T>
    {
        IOutputArtifact Create(T input);
    }
}
