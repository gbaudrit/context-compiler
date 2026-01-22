using System;
using System.Linq;
using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Prompt;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class PersonasPromptComposer(IPrompt prompt,
                                                 IOutput output,
                                                 IAssumptionBuilder assumptionBuilder,
                                                 ICtxcConfigProvider ctxcConfig,
                                                 IPluginRegistry plugins,
                                                 ILogger<PersonasPromptComposer> logger) : IPromptComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.personas", GlobalPipelinePluginKinds.PromptComposer, priority: 10);

        public async Task Run(CancellationToken cancellationToken)
        {
            // Personas (existing integration)
            var personasMeta = new List<IPersonaResult>();
            if (ctxcConfig.Current.Personas is not null && ctxcConfig.Current.Personas.Active.Count > 0)
            {
                foreach (var id in ctxcConfig.Current.Personas.Active)
                {
                    var plugin = plugins.Personas.FirstOrDefault(p => string.Equals(p.PersonaId, id, StringComparison.Ordinal));
                    if (plugin is null)
                    {
                        logger.LogWarning("Persona not found: {Id}", id);
                        continue;
                    }
                    IReadOnlyDictionary<string, object>? inputs = null;
                    if (ctxcConfig.Current.Personas.Params is not null && ctxcConfig.Current.Personas.Params.TryGetValue(id, out var pval) && pval is not null)
                    {
                        if (pval is JsonElement je && je.ValueKind == JsonValueKind.Object)
                        {
                            var dict = new Dictionary<string, object>();
                            foreach (var prop in je.EnumerateObject())
                                dict[prop.Name] = prop.Value.ToString();
                            inputs = dict;
                        }
                    }
                    personasMeta.Add(await plugin.BuildAsync(new PersonaContext(inputs), cancellationToken));
                }
            }
            prompt.Personas = personasMeta;
        }
    }
}
