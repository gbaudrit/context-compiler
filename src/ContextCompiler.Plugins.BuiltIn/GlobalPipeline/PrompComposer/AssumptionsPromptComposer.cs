using System;
using System.Linq;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class AssumptionsPromptComposer(IPrompt prompt, IAssumptionBuilder assumptionBuilder, ICtxcConfigProvider ctxcConfig) : IPromptComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.assumptions", PluginKinds.PromptComposer, priority: 10);

        public ValueTask Run(CancellationToken cancellationToken)
        {
            var list = ctxcConfig.Current.Context.Assumptions?
                .Select(a => assumptionBuilder.InitNew().WithName(a.Key).WithDescription(a.Value).Build())
                .ToList() ?? new();
            prompt.Assumptions = [.. list];
            return ValueTask.CompletedTask;
        }
    }
}
