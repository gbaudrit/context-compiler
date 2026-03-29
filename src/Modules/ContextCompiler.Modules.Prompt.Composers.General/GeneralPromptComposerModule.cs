using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Prompt.Composers.General;

public sealed class GeneralPromptComposerModule(IPrompt prompt, IOutput output, IConfigProvider ctxcConfig, IModulesRegistry modules, IReasoningIr ir) : IPromptComposerModule
{
    public ModuleMetadata Metadata => IModule.Meta("prompt.composers.general", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

    public async Task Run(CancellationToken cancellationToken)
    {
        prompt.Name = ctxcConfig.Current.Context.Name ?? "";
        prompt.Summary = ctxcConfig.Current.Context.Summary ?? "";
        prompt.Domain = ctxcConfig.Current.Context.Domain ?? "";

        await Task.CompletedTask;
    }
}
