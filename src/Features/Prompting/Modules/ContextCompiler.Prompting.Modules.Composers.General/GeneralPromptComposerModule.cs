using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;
using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Prompting.Modules.Composers.General;

public sealed class GeneralPromptComposerModule(IPrompt prompt, IOutput output, IConfigProvider ctxcConfig, IModulesRegistry modules, ICompiledContext ir) : IPromptComposerModule
{
    public ModuleMetadata Metadata => ICompilePipelineModule.Meta("prompt.composers.general", CompilePipelineModuleKinds.OutputComposition, priority: 10);

    public async Task<IResult<IPromptComposerRunResult>> Run(IPromptComposerRunContext context, CancellationToken cancellationToken)
    {
        prompt.Name = ctxcConfig.Current.Context.Name ?? "";
        prompt.Summary = ctxcConfig.Current.Context.Summary ?? "";
        prompt.Domain = ctxcConfig.Current.Context.Domain ?? "";

        return await context.Success();
    }
}
