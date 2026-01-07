using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document
{
    public sealed record DataPart(string PartId,
                                  ISourceRef Source,
                                  string? Label = null) : IDataPart;

}
