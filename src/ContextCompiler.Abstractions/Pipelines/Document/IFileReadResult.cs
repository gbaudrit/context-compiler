using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IFileReadResult
    {
        IFileInfos Content { get; }
    }
}
