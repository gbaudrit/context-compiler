using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Templates
{
    internal interface ITemplateProvider
    {
        ITemplateDefinition GetTemplate(string name);
    }
}
