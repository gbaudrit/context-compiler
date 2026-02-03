namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Templates
{
    internal interface ITemplateProvider
    {
        ITemplateDefinition GetTemplate(string name);
    }
}
