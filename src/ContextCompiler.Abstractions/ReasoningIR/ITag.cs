using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.ReasoningIR
{
    public interface ITag
    {
        string Name { get; }
        string? Value { get; }
    }
}
