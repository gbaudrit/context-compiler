using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Prompt
{
    public interface IAudience
    {
        string Name { get; init; }
        string Description { get; init; }
    }
}
