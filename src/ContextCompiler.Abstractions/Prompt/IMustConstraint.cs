using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Rendering;

namespace ContextCompiler.Abstractions.Prompt
{
    public interface IMustConstraint
    {
        string Text { get; init; }
    }
}
