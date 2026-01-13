using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Prompt
{
    public interface IMustNotConstraint
    {
        string Text { get; init; }
    }
}
