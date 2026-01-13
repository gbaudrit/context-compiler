using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Templates
{
    internal sealed class TemplateDefinition : ITemplateDefinition
    {
        public required string Name { get; init; }
        public required string Content { get; init; }

    }
}
