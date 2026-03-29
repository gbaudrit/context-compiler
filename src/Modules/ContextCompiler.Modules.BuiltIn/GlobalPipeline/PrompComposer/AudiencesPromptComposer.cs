using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class AudiencesPromptComposer(IPrompt prompt, IAudienceBuilder audienceBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
    {
        public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.audiences", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

        public Task Run(CancellationToken cancellationToken)
        {
            List<IAudience> list = ctxcConfig.Current.Context.Audiences?
                .Select(kv => audienceBuilder.InitNew().WithName(kv.Key).WithDescription(kv.Value).Build())
                .ToList() ?? [];
            prompt.Audiences = [.. list];
            return Task.CompletedTask;
        }
    }
}
