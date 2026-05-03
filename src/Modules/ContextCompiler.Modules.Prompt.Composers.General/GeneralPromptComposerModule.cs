using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;

namespace ContextCompiler.Modules.Prompt.Composers.General;

public sealed class GeneralPromptComposerModule(IPrompt prompt, IOutput output, IConfigProvider ctxcConfig, IModulesRegistry modules, IReasoningIr ir) : IPromptComposerModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("prompt.composers.general", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        prompt.Name = ctxcConfig.Current.Context.Name ?? "";
        prompt.Summary = ctxcConfig.Current.Context.Summary ?? "";
        prompt.Domain = ctxcConfig.Current.Context.Domain ?? "";

        return await context.Success();
    }
}
