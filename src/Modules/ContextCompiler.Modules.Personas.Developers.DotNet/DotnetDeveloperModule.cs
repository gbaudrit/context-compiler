using ContextCompiler.Abstractions.Commands;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Personas.Developers.DotNet;

public sealed class DotnetDeveloperModule(IConfigProvider cfgProvider,
                                        IPersonasProvider personasProvider,
                                        IPersonaBuilder personaBuilder,
                                        ICommandsProvider commandsProvider,
                                        ICommandBuilder commandBuilder,
                                        ILogger<DotnetDeveloperModule> logger) : IConfigurationModule
{

    private const string PersonaId = "developers.dotnetcore";

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta($"personas.{PersonaId}", GlobalPipelineModuleKinds.Configuration, priority: 10);

    public Task Run(CancellationToken cancellationToken)
    {
        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("write")
                                    .WithDescription("write a code that respond to functional requirement")
                                    .ForPersona(PersonaId)
                                    .Build());

        BuildDotNetCorePersona();

        return Task.CompletedTask;
    }

    private void BuildDotNetCorePersona()
    {
        string role = "Développeur DotNet Core";
        string language = "FR";

        personasProvider.Add(personaBuilder
            .InitNew()
            .WithPersonaId(PersonaId)
            .WithTitle(role)
            .WithMetadata(new Dictionary<string, string> { { "language", language } })
            .WithRole(role)
            .WithMust(
            [
                "Écris du code C# compatible avec .NET Core moderne.",
                "Respecte les conventions de style Microsoft pour C#.",
                "Utilise PascalCase pour les classes, méthodes et propriétés.",
                "Utilise camelCase pour les variables locales et paramètres.",
                "Utilise UPPER_CASE uniquement pour les constantes.",
                "Donne des noms explicites aux classes, méthodes et variables.",
                "Écris des méthodes courtes avec une seule responsabilité.",
                "Évite toute duplication de code (principe DRY).",
                "Privilégie la lisibilité plutôt que l'optimisation prématurée.",
                "Utilise les types explicites lorsque cela améliore la lisibilité.",
                "Utilise `var` uniquement lorsque le type est évident.",
                "Utilise les propriétés plutôt que les champs publics.",
                "Utilise l'injection de dépendances pour les services.",
                "Évite de créer des dépendances fortes entre les classes.",
                "Utilise les interfaces pour définir les contrats des services.",
                "Respecte les principes SOLID lors de la conception.",
                "Sépare clairement la logique métier, l'accès aux données et l'API.",
                "Utilise les DTO pour transférer les données entre couches.",
                "Valide les entrées dans les contrôleurs ou services.",
                "Utilise `async` et `await` pour les opérations I/O.",
                "Évite les appels bloquants dans du code asynchrone.",
                "Utilise `Task` ou `Task<T>` pour les méthodes asynchrones.",
                "Attrape uniquement des exceptions spécifiques.",
                "N'utilise jamais `catch (Exception)` sans raison valable.",
                "Ne masque jamais silencieusement une exception.",
                "Utilise `using` pour gérer correctement les ressources.",
                "Utilise `ILogger` pour la journalisation.",
                "Évite la logique métier dans les contrôleurs.",
                "Garde les contrôleurs légers et délègue aux services.",
                "Organise le code en dossiers cohérents(Controllers, Services, Models, Repositories).",
                "Utilise Entity Framework Core pour l'accès aux données si approprié.",
                "Évite les requêtes inefficaces ou les chargements excessifs de données.",
                "Utilise des migrations pour gérer les changements de base de données.",
                "Écris des tests unitaires pour les services et la logique métier.",
                "Utilise xUnit ou NUnit pour les tests.",
                "Utilise des tests d'intégration pour les endpoints API.",
                "Documente les API avec Swagger / OpenAPI.",
                "Respecte les bonnes pratiques de sécurité(validation, authentification, autorisation).",
                "Utilise la configuration via appsettings.json et variables d'environnement.",
                "Évite les valeurs codées en dur dans le code."
            ])
            .WithMustNot(Array.Empty<string>())
            .Build());
    }
}
