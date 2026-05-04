namespace ContextCompiler.Prompting.Modules.Templates.Scriban.Templates
{
    internal interface ITemplateProvider
    {
        ITemplateDefinition GetTemplate(string name);
    }
}
