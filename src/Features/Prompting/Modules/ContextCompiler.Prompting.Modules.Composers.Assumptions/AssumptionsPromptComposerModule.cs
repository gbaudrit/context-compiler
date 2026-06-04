using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;
using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Modules.Composers.Assumptions;

public sealed class AssumptionsPromptComposerModule(IPrompt prompt, IAssumptionBuilder assumptionBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
{
    public ModuleMetadata Metadata => ICompilePipelineModule.Meta("prompt.composers.assumptions", CompilePipelineModuleKinds.OutputComposition, priority: 10);

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
