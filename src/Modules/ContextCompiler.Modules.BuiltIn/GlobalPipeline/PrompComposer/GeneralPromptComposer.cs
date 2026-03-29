using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class GeneralPromptComposer(IPrompt prompt, IOutput output, IConfigProvider ctxcConfig, IModulesRegistry modules, IReasoningIr ir) : IPromptComposerModule
    {
        public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.general", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

        public async Task Run(CancellationToken cancellationToken)
        {
            prompt.Name = ctxcConfig.Current.Context.Name ?? "";
            prompt.Summary = ctxcConfig.Current.Context.Summary ?? "";
            prompt.Domain = ctxcConfig.Current.Context.Domain ?? "";
        }
    }
}
