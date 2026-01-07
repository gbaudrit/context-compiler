using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDataPartBuilder
    {
        IDataPart Build();
        IDataPartBuilder InitNew();
        IDataPartBuilder WithId(string id);
        IDataPartBuilder WithLabel(string? label);
        IDataPartBuilder WithPayload(object? payload);
        IDataPartBuilder WithSource(ISourceRef source);
    }
}
