using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Guards
{
    public interface IGuardContext
    {
        IDocumentContext DocumentContext { get; }
        IDataPart? Part { get; }
    }
}
