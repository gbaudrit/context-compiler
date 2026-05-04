namespace ContextCompiler.Prompting.Modules.Templates.Scriban.Templates
{
    internal interface ITemplateDefinition
    {
        string Name { get; init; }
        string Content { get; init; }
    }
}
