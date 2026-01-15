using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Prompt
{
    public interface IGlossaryTerm
    {
        string Term { get; init; }
        string Definition { get; init; }
    }
}
