using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class GlossaryTerm : IGlossaryTerm
    {

        public required string Term { get; init; }
        public required string Definition { get; init; }

    }
}
