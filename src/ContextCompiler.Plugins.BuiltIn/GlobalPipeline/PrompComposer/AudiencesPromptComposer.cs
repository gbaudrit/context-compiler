using System;
using System.Linq;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class AudiencesPromptComposer(IPrompt prompt, IAudienceBuilder audienceBuilder, ICtxcConfigProvider ctxcConfig) : IPromptComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.audiences", PluginKinds.PromptComposer, priority: 10);

        public ValueTask Run(CancellationToken cancellationToken)
        {
            var list = ctxcConfig.Current.Context.Project?.Audiences?
                .Select(kv => audienceBuilder.InitNew().WithName(kv.Key).WithDescription(kv.Value).Build())
                .ToList() ?? new();
            prompt.Audiences = [.. list];
            return ValueTask.CompletedTask;
        }
    }
}
