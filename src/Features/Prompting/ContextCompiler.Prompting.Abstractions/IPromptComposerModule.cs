using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Versioning;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

namespace ContextCompiler.Prompting.Abstractions;

public interface IPromptComposerModule : IModule
{
    static ModuleMetadata Meta(string id, CompilePipelineModuleKinds kind, int priority = 0)
    {
        return new(id, kind, ModuleApiVersion.Current, priority);
    }

    Task<IResult<IPromptComposerRunResult>> Run(IPromptComposerRunContext context, CancellationToken cancellationToken);

    ModuleMetadata Metadata { get; }
}
