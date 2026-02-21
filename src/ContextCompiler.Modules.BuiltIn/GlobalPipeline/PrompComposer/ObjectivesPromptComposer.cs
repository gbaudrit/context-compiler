using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class ObjectivesPromptComposer(IPrompt prompt, IObjectiveBuilder objectiveBuilder, ICtxcConfigProvider ctxcConfig) : IPromptComposerModule
    {

        public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.objectives", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

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
