using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class ObjectivesPromptComposer(IObjectiveBuilder objectiveBuilder) : IPromptComposerPlugin
    {

        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.objectives", PluginKinds.PromptComposer, priority: 10);

        public ValueTask Run(IPromptComposerContext context, CancellationToken cancellationToken)
        {
            context.Prompt.Objectives = [.. context.Config.Objectives?.Select(o => objectiveBuilder.WithName(o.Key).WithDescription(o.Value).Build()).ToList() ?? []];
            return ValueTask.CompletedTask;
        }
    }
}
