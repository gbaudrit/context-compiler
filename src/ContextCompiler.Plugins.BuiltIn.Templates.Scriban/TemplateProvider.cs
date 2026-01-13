using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Templates;

namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban
{
    internal sealed class TemplateProvider : ITemplateProvider
    {

        public ITemplateDefinition GetTemplate(string name)
        {
            var resource = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream($"ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Templates.{name}");

            if (resource is null)
            {
                throw new InvalidOperationException($"Template '{name}' not found as embedded resource.");
            }

            using var reader = new StreamReader(resource);
            return new TemplateDefinition() { Name = name, Content = reader.ReadToEnd() };
        }

    }
}
