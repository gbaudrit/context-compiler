using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Prompt.Composers.Constraints;

public sealed class ConstraintsPromptComposerModule(IPrompt prompt, IMustConstraintBuilder mustConstraintBuilder, IMustNotConstraintBuilder mustNotConstraintBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
{
    public ModuleMetadata Metadata => IModule.Meta("prompt.composers.constraints", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

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
