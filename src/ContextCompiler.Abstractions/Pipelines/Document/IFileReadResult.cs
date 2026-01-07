using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IFileReadResult
    {
        byte[] Bytes { get; }
    }
}
