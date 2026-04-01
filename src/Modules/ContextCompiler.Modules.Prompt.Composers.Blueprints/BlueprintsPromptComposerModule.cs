using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Prompt.Composers.Blueprints;

public sealed class BlueprintsPromptComposerModule(
    IPrompt prompt,
    IBlueprintBuilder blueprintBuilder,
    IConfigProvider ctxcConfig,
    IModulesRegistry modulesRegistry) : IPromptComposerModule
{
    public ModuleMetadata Metadata => IModule.Meta("prompt.composers.blueprints", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

    public async Task Run(CancellationToken cancellationToken)
    {
        // Récupérer les blueprints depuis les modules enregistrés
        List<IBlueprint> blueprints = [];

        // Exemple : construire un blueprint depuis la configuration
        // ou depuis des modules qui implémentent une interface de blueprint
        foreach (var blueprintModule in modulesRegistry.GetModules<IBlueprintModule>())
        {
            var blueprint = await blueprintModule.BuildAsync(cancellationToken);
            blueprints.Add(blueprint);
        }

        // Assigner les blueprints au prompt
        prompt.Blueprints = blueprints;

        await Task.CompletedTask;
    }
}
