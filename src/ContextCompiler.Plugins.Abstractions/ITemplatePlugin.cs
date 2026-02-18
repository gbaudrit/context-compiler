using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Plugins.Abstractions;

public interface ITemplatePlugin : IPlugin
{
    string TemplateId { get; }
    string Apply(CompileOptions options, IPrompt prompt);
}
