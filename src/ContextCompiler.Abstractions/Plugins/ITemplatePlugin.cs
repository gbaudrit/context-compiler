namespace ContextCompiler.Abstractions.Plugins;

public interface ITemplatePlugin : IPlugin
{
    string TemplateId { get; }
    string Apply(string compiledViewsMarkdown);
}
