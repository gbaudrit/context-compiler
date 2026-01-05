using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Plugins;

public interface ITemplatePlugin : IPlugin
{
    string TemplateId { get; }
    string Apply(CompileOptions options, Prompt prompt);
}
