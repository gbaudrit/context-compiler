using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class Objective : IObjective
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
    }
}
