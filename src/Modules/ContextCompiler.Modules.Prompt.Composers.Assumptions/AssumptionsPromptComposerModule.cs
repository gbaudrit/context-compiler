using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;
using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Modules.Prompt.Composers.Assumptions;

public sealed class AssumptionsPromptComposerModule(IPrompt prompt, IAssumptionBuilder assumptionBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("prompt.composers.assumptions", GlobalPipelineModuleKinds.OutputComposition, priority: 10);

    public Task<IResult<IPromptComposerRunResult>> Run(IPromptComposerRunContext context, CancellationToken cancellationToken)
    {
        int index = 1;
        List<IAssumption> assumptions = [];
        foreach (string a in ctxcConfig.Current.Context.Assumptions ?? [])
        {
            assumptions.Add(assumptionBuilder.InitNew().WithName($"AS{index++}").WithDescription(a).Build());
        }

        prompt.Assumptions = assumptions;
        return context.Success();
    }
}
