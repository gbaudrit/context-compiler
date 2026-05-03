using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Prompt.Composers.Objectives;

public sealed class ObjectivesPromptComposerModule(IPrompt prompt, IObjectiveBuilder objectiveBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
{

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("prompt.composers.objectives", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
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
        return context.Success();
    }
}
