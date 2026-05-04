using ContextCompiler.Abstractions.Models;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Prompting.Abstractions;

public interface ITemplateModule : IModule
{
    string TemplateId { get; }
    string Apply(CompileOptions options, IPrompt prompt);
}
