using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;
using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Modules.Prompt.Composers.Objectives;

public sealed class ObjectivesPromptComposerModule(IPrompt prompt, IObjectiveBuilder objectiveBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
{

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("prompt.composers.objectives", GlobalPipelineModuleKinds.OutputComposition, priority: 10);

    public Task<IResult<IPromptComposerRunResult>> Run(IPromptComposerRunContext context, CancellationToken cancellationToken)
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
