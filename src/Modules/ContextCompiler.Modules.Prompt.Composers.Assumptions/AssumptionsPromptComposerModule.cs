using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Prompt.Composers.Assumptions;

public sealed class AssumptionsPromptComposerModule(IPrompt prompt, IAssumptionBuilder assumptionBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
{
    public ModuleMetadata Metadata => IModule.Meta("prompt.composers.assumptions", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

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
