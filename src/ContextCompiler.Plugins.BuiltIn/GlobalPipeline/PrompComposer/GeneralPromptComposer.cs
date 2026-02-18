using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.GlobalPipeline;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class GeneralPromptComposer(IPrompt prompt, IOutput output, ICtxcConfigProvider ctxcConfig, IPluginRegistry plugins, IReasoningIr ir) : IPromptComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.general", GlobalPipelinePluginKinds.PromptComposer, priority: 10);

        public async Task Run(CancellationToken cancellationToken)
        {
            prompt.Name = ctxcConfig.Current.Context.Name ?? "";
            prompt.Summary = ctxcConfig.Current.Context.Summary ?? "";
            prompt.Domain = ctxcConfig.Current.Context.Domain ?? "";
        }
    }
}
