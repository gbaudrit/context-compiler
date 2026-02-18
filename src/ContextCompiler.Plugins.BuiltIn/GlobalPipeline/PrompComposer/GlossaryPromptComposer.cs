using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.GlobalPipeline;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class GlossaryPromptComposer(IPrompt prompt, IGlossaryTermBuilder termBuilder, ICtxcConfigProvider ctxcConfig) : IPromptComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.glossary", GlobalPipelinePluginKinds.PromptComposer, priority: 10);

        public Task Run(CancellationToken cancellationToken)
        {
            List<IGlossaryTerm> list = ctxcConfig.Current.Context.Glossary?
                .Select(kv => termBuilder.InitNew().WithTerm(kv.Key).WithDefinition(kv.Value).Build())
                .ToList() ?? [];
            prompt.Glossary = [.. list];
            return Task.CompletedTask;
        }
    }
}
