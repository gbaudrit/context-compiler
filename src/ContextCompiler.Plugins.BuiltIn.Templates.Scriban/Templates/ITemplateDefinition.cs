using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Templates
{
    internal interface ITemplateDefinition
    {
        string Name { get; init; }
        string Content { get; init; }
    }
}
