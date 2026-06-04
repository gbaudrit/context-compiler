using ContextCompiler.Abstractions.Common;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

namespace ContextCompiler.Prompting.Modules.Composers.Blueprints;

public sealed class BlueprintsPromptComposerModule : IPromptComposerModule
{
    public ModuleMetadata Metadata => IPromptComposerModule.Meta("prompt.composers.blueprints", CompilePipelineModuleKinds.OutputComposition, priority: 10);

    public async Task<IResult<IPromptComposerRunResult>> Run(IPromptComposerRunContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await context.Success();
    }
}
