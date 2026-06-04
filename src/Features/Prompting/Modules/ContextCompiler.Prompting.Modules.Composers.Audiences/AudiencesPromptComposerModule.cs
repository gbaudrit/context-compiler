using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;
using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Modules.Composers.Audiences;

public sealed class AudiencesPromptComposerModule(IPrompt prompt, IAudienceBuilder audienceBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
{
    public ModuleMetadata Metadata => ICompilePipelineModule.Meta("prompt.composers.audiences", CompilePipelineModuleKinds.OutputComposition, priority: 10);

    public Task<IResult<IPromptComposerRunResult>> Run(IPromptComposerRunContext context, CancellationToken cancellationToken)
    {
        List<IAudience> list = ctxcConfig.Current.Context.Audiences?
            .Select(kv => audienceBuilder.InitNew().WithName(kv.Key).WithDescription(kv.Value).Build())
            .ToList() ?? [];
        prompt.Audiences = [.. list];
        return context.Success();
    }
}
