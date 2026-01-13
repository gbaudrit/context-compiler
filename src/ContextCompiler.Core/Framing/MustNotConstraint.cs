using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class MustNotConstraint : IMustNotConstraint
    {

        public required string Text { get; init; }

    }
}
