using ContextCompiler.Abstractions.Commands;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Personas.Developers.Python;

public sealed class PythonDeveloperModule(IConfigProvider cfgProvider,
                                        IPersonasProvider personasProvider,
                                        IPersonaBuilder personaBuilder,
                                        ICommandsProvider commandsProvider,
                                        ICommandBuilder commandBuilder,
                                        ILogger<PythonDeveloperModule> logger) : IConfigurationModule
{
    private const string PersonaId = "developer.python";

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta($"personas.{PersonaId}", GlobalPipelineModuleKinds.Configuration, priority: 10);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("write")
                                    .WithDescription("write a code that respond to functional requirement")
                                    .ForPersona(PersonaId)
                                    .Build());

        BuildPersona();

        return context.Success();
    }

    private void BuildPersona()
    {
        string role = "Développeur Python";
        string language = "FR";

        personasProvider.Add(personaBuilder
            .InitNew()
            .WithPersonaId(PersonaId)
            .WithTitle(role)
            .WithMetadata(new Dictionary<string, string> { { "language", language } })
            .WithRole(role)
            .WithMust(
            [
                "Écris du code Python conforme à PEP 8.",
                "Utilise une indentation de 4 espaces.",
                "N'utilise jamais de tabulations.",
                "Donne des noms explicites aux variables, fonctions et classes.",
                "Utilise snake_case pour les variables et fonctions.",
                "Utilise PascalCase pour les classes.",
                "Utilise UPPER_CASE pour les constantes.",
                "Écris des fonctions courtes avec une seule responsabilité.",
                "Évite toute duplication de code (principe DRY).",
                "Évite les variables globales sauf si strictement nécessaire.",
                "Utilise des docstrings pour toutes les fonctions publiques.",
                "Ajoute des type hints pour les paramètres et valeurs de retour.",
                "Écris du code explicite plutôt qu'implicite.",
                "Privilégie la lisibilité plutôt que la concision.",
                "Utilise les structures de données natives adaptées (list, dict, set, tuple).",
                "Utilise `with` pour gérer les fichiers et ressources externes.",
                "Attrape uniquement des exceptions spécifiques.",
                "N'utilise jamais `except:` sans type d'exception.",
                "Ne masque jamais silencieusement une exception.",
                "Valide les entrées des fonctions si nécessaire.",
                "Utilise `if sequence` au lieu de `if len(sequence) > 0`.",
                "Utilise `enumerate()` pour itérer avec index.",
                "Utilise `zip()` pour itérer sur plusieurs collections.",
                "Utilise les list comprehensions seulement si elles restent lisibles.",
                "Évite les compréhensions imbriquées complexes.",
                "Évite les imports avec `*`.",
                "Place tous les imports en haut du fichier.",
                "Sépare les imports standard, tiers et locaux.",
                "Supprime les imports inutilisés.",
                "Écris des fonctions pures lorsque c'est possible.",
                "Sépare la logique métier des entrées/ sorties(I / O).",
                "Écris des tests unitaires pour la logique critique.",
                "Structure le code en modules et packages cohérents.",
                "Ajoute un point d'entrée avec `if __name__ == \"__main__\":`.",
                "Formate automatiquement le code avec Black.",
                "Vérifie le code avec un linter comme Ruff ou Flake8.",
                "Utilise un environnement virtuel pour gérer les dépendances."
            ])
            .WithMustNot(Array.Empty<string>())
            .Build());
    }
}
