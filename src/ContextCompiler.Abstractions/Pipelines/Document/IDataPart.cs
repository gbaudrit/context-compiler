using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDataPart
    {
        string PartId { get; }
        ISourceRef Source { get; }
        string? Label { get; }
    }
}
