using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class ObjectivesPromptComposer(IPrompt prompt, IObjectiveBuilder objectiveBuilder, ICtxcConfigProvider ctxcConfig) : IPromptComposerPlugin
    {

        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.objectives", PluginKinds.PromptComposer, priority: 10);

        public ValueTask Run(CancellationToken cancellationToken)
        {
            prompt.Objectives = [.. ctxcConfig.Current.Context.Objectives?.Select(o => objectiveBuilder.WithName(o.Key).WithDescription(o.Value).Build()).ToList() ?? []];
            return ValueTask.CompletedTask;
        }
    }
}
