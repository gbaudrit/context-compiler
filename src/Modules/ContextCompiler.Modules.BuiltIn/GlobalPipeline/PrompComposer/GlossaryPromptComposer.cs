using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class GlossaryPromptComposer(IPrompt prompt, IGlossaryTermBuilder termBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
    {
        public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.glossary", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

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
