using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Prompt.Composers.Audiences;

public sealed class AudiencesPromptComposerModule(IPrompt prompt, IAudienceBuilder audienceBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("prompt.composers.audiences", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        List<IAudience> list = ctxcConfig.Current.Context.Audiences?
            .Select(kv => audienceBuilder.InitNew().WithName(kv.Key).WithDescription(kv.Value).Build())
            .ToList() ?? [];
        prompt.Audiences = [.. list];
        return context.Success();
    }
}
