using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Abstractions.Plugins;

public interface ITemplatePlugin : IPlugin
{
    string TemplateId { get; }
    string Apply(CompileOptions options, IPrompt prompt);
}
