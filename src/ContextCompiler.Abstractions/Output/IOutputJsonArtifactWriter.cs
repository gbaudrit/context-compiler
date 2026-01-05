using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputJsonArtifactWriter
    {

        Task Write<T>(string name, T health);

    }
}
