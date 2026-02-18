using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.GlobalPipeline;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class ConstraintsPromptComposer(IPrompt prompt, IMustConstraintBuilder mustConstraintBuilder, IMustNotConstraintBuilder mustNotConstraintBuilder, ICtxcConfigProvider ctxcConfig) : IPromptComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.constraints", GlobalPipelinePluginKinds.PromptComposer, priority: 10);

        public Task Run(CancellationToken cancellationToken)
        {
            int index = 1;
            List<IMustConstraint> must = [];
            foreach (string a in ctxcConfig.Current.Context.Constraints?.Must ?? [])
            {
                must.Add(mustConstraintBuilder.InitNew().WithId($"MUST{index++}").WithText(a).Build());
            }

            List<IMustNotConstraint> mustNot = [];
            foreach (string a in ctxcConfig.Current.Context.Constraints?.MustNot ?? [])
            {
                mustNot.Add(mustNotConstraintBuilder.InitNew().WithId($"MUSTNOT{index++}").WithText(a).Build());
            }

            prompt.MustConstraints = must;
            prompt.MustNotConstraints = mustNot;
            return Task.CompletedTask;
        }
    }
}
