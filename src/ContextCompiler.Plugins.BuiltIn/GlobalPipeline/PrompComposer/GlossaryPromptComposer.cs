using System;
using System.Linq;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class GlossaryPromptComposer(IPrompt prompt, IGlossaryTermBuilder termBuilder, ICtxcConfigProvider ctxcConfig) : IPromptComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.glossary", PluginKinds.PromptComposer, priority: 10);

        public ValueTask Run(CancellationToken cancellationToken)
        {
            var list = ctxcConfig.Current.Context.Glossary?
                .Select(kv => termBuilder.InitNew().WithTerm(kv.Key).WithDefinition(kv.Value).Build())
                .ToList() ?? new();
            prompt.Glossary = [.. list];
            return ValueTask.CompletedTask;
        }
    }
}
