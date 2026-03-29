namespace ContextCompiler.Modules.Prompt.Templates.Scriban.Templates
{
    internal interface ITemplateDefinition
    {
        string Name { get; init; }
        string Content { get; init; }
    }
}
