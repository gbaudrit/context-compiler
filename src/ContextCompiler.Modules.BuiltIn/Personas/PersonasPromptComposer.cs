using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.BuiltIn.Personas
{
    internal sealed class PersonasPromptComposer(IPrompt prompt,
                                                 IOutput output,
                                                 IAssumptionBuilder assumptionBuilder,
                                                 IConfigProvider ctxcConfig,
                                                 IModulesRegistry modules,
                                                 ILogger<PersonasPromptComposer> logger) : IPromptComposerModule
    {
        public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.personas", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

        public async Task Run(CancellationToken cancellationToken)
        {
            // Personas (existing integration)
            List<IPersonaResult> personasMeta = [];
            if (ctxcConfig.Current.Personas is not null && ctxcConfig.Current.Personas.Active.Count > 0)
            {
                foreach (string id in ctxcConfig.Current.Personas.Active)
                {
                    IPersonaModule? module = modules.Personas.FirstOrDefault(p => string.Equals(p.PersonaId, id, StringComparison.Ordinal));
                    if (module is null)
                    {
                        logger.LogWarning("Persona not found: {Id}", id);
                        continue;
                    }
                    IReadOnlyDictionary<string, object>? inputs = null;
                    if (ctxcConfig.Current.Personas.Params is not null && ctxcConfig.Current.Personas.Params.TryGetValue(id, out object? pval) && pval is not null)
                    {
                        if (pval is JsonElement je && je.ValueKind == JsonValueKind.Object)
                        {
                            Dictionary<string, object> dict = [];
                            foreach (JsonProperty prop in je.EnumerateObject())
                            {
                                dict[prop.Name] = prop.Value.ToString();
                            }

                            inputs = dict;
                        }
                    }
                    personasMeta.Add(await module.BuildAsync(new PersonaContext(inputs), cancellationToken));
                }
            }
            prompt.Personas = personasMeta;
        }
    }
}
