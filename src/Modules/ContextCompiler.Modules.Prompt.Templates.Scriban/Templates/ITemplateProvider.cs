namespace ContextCompiler.Modules.Prompt.Templates.Scriban.Templates
{
    internal interface ITemplateProvider
    {
        ITemplateDefinition GetTemplate(string name);
    }
}
