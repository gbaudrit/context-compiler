using System.Reflection;

using ContextCompiler.Modules.BuiltIn.Templates.Scriban.Templates;

namespace ContextCompiler.Modules.BuiltIn.Templates.Scriban
{
    internal sealed class TemplateProvider : ITemplateProvider
    {

        public ITemplateDefinition GetTemplate(string name)
        {
            Stream? resource = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream($"ContextCompiler.Modules.BuiltIn.Templates.Scriban.Templates.{name}") ?? throw new InvalidOperationException($"Template '{name}' not found as embedded resource.");
            using StreamReader reader = new(resource);
            return new TemplateDefinition() { Name = name, Content = reader.ReadToEnd() };
        }

    }
}
