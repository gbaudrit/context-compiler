using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class ObjectivesPromptComposer(IPrompt prompt, IObjectiveBuilder objectiveBuilder, ICtxcConfigProvider ctxcConfig) : IPromptComposerPlugin
    {

        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.objectives", GlobalPipelinePluginKinds.PromptComposer, priority: 10);

        public Task Run(CancellationToken cancellationToken)
        {
            int index = 1;
            List<IObjective> objectives = [];
            foreach (string obj in ctxcConfig.Current.Context.Objectives ?? [])
            {
                objectives.Add(objectiveBuilder.InitNew()
                                .WithName($"OBJ{index++}")
                                .WithDescription(obj)
                                .Build());
            }
            prompt.Objectives = objectives;
            return Task.CompletedTask;
        }
    }
}
