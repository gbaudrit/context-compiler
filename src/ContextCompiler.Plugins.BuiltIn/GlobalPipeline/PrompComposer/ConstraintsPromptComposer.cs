using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class ConstraintsPromptComposer(IPrompt prompt, IMustConstraintBuilder mustConstraintBuilder, IMustNotConstraintBuilder mustNotConstraintBuilder, ICtxcConfigProvider ctxcConfig) : IPromptComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.constraints", GlobalPipelinePluginKinds.PromptComposer, priority: 10);

        public Task Run(CancellationToken cancellationToken)
        {
            var index = 1;
            var must = new List<IMustConstraint>();
            foreach (var a in ctxcConfig.Current.Context.Constraints?.Must ?? [])
            {
                must.Add(mustConstraintBuilder.InitNew().WithId($"MUST{index++}").WithText(a).Build());
            }

            var mustNot = new List<IMustNotConstraint>();
            foreach (var a in ctxcConfig.Current.Context.Constraints?.MustNot ?? [])
            {
                mustNot.Add(mustNotConstraintBuilder.InitNew().WithId($"MUSTNOT{index++}").WithText(a).Build());
            }

            prompt.MustConstraints = must;
            prompt.MustNotConstraints = mustNot;
            return Task.CompletedTask;
        }
    }
}
