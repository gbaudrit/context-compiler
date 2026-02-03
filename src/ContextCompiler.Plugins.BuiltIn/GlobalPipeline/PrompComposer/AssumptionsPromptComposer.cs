using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class AssumptionsPromptComposer(IPrompt prompt, IAssumptionBuilder assumptionBuilder, ICtxcConfigProvider ctxcConfig) : IPromptComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.assumptions", GlobalPipelinePluginKinds.PromptComposer, priority: 10);

        public Task Run(CancellationToken cancellationToken)
        {
            int index = 1;
            List<IAssumption> assumptions = [];
            foreach (string a in ctxcConfig.Current.Context.Assumptions ?? [])
            {
                assumptions.Add(assumptionBuilder.InitNew().WithName($"AS{index++}").WithDescription(a).Build());
            }

            prompt.Assumptions = assumptions;
            return Task.CompletedTask;
        }
    }
}
