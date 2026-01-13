using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class MustConstraint : IMustConstraint
    {

        public required string Text { get; init; }

    }
}
