using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Modules.Abstractions;

public interface ITemplateModule : IModule
{
    string TemplateId { get; }
    string Apply(CompileOptions options, IPrompt prompt);
}
