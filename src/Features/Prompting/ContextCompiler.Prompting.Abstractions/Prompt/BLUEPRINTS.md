# Blueprints in ContextCompiler

## Overview

Les Blueprints sont des structures prédéfinies qui encapsulent un ensemble cohérent de contraintes, objectifs, hypothèses, termes de glossaire et commandes pour un type spécifique de projet ou contexte.

## Structure d'un Blueprint

Un `IBlueprint` contient :

- **Id** : Identifiant unique du blueprint
- **Name** : Nom descriptif
- **Description** : Description détaillée du blueprint
- **MustConstraints** : Liste des contraintes obligatoires
- **MustNotConstraints** : Liste des contraintes interdites
- **Objectives** : Liste des objectifs à atteindre
- **Assumptions** : Liste des hypothèses sur lesquelles le blueprint repose
- **Glossary** : Dictionnaire de termes et définitions
- **Commands** : Liste des commandes disponibles
- **Steps** : Liste des étapes avec leurs contraintes spécifiques

## Structure d'un BlueprintStep

Un `IBlueprintStep` contient :

- **Content** : Description textuelle de l'étape
- **MustConstraints** : Contraintes MUST spécifiques à cette étape
- **MustNotConstraints** : Contraintes MUST NOT spécifiques à cette étape

## Création d'un Blueprint

### Via IBlueprintBuilder

```csharp
public class MyBlueprint(IBlueprintBuilder blueprintBuilder) : IBlueprintModule
{
    public Task<IBlueprint> BuildAsync(CancellationToken cancellationToken)
    {
        var blueprint = blueprintBuilder
            .InitNew()
            .WithId("my-blueprint")
            .WithName("My Custom Blueprint")
            .WithDescription("Description of my blueprint")
            
            // Ajouter des contraintes
            .AddMustConstraint(mustConstraint)
            .AddMustNotConstraint(mustNotConstraint)
            
            // Ajouter des objectifs
            .AddObjective(objective)
            
            // Ajouter des hypothèses
            .AddAssumption(assumption)
            
            // Ajouter des termes au glossaire
            .AddGlossaryTerm(term)
            
            // Ajouter des commandes
            .AddCommand(command)
            
            .Build();

        return Task.FromResult(blueprint);
    }
}
```

## Utilisation dans le Prompt

Les blueprints sont automatiquement composés dans le prompt via le module `BlueprintsPromptComposerModule` :

```csharp
public sealed class BlueprintsPromptComposerModule(
    IPrompt prompt,
    IModulesRegistry modulesRegistry) : IPromptComposerModule
{
    public async Task Run(CancellationToken cancellationToken)
    {
        List<IBlueprint> blueprints = [];
        
        foreach (var blueprintModule in modulesRegistry.GetModules<IBlueprintModule>())
        {
            var blueprint = await blueprintModule.BuildAsync(cancellationToken);
            blueprints.Add(blueprint);
        }
        
        prompt.Blueprints = blueprints;
    }
}
```

## Exemples de Blueprints

### Blueprint pour application web .NET

```csharp
var blueprint = blueprintBuilder
    .InitNew()
    .WithId("dotnet-webapp")
    .WithName(".NET Web Application")
    .WithDescription("Blueprint pour une application web .NET moderne")
    
    .AddMustConstraint(mustConstraintBuilder.InitNew()
        .WithId("MUST1")
        .WithText("Utiliser .NET 10 ou supérieur")
        .Build())
    
    .AddObjective(objectiveBuilder.InitNew()
        .WithName("OBJ1")
        .WithDescription("Créer une application sécurisée et performante")
        .Build())
    
    .Build();
```

## Intégration avec les Modules

Pour créer un module qui fournit un blueprint :

1. Implémenter l'interface `IBlueprintModule`
2. Injecter les builders nécessaires
3. Retourner le blueprint construit dans `BuildAsync`

```csharp
public sealed class MyBlueprintModule(
    IBlueprintBuilder blueprintBuilder,
    IMustConstraintBuilder mustConstraintBuilder) : IBlueprintModule
{
    public ModuleMetadata Metadata => IModule.Meta(
        "blueprints.my-blueprint", 
        CompilePipelineModuleKinds.Blueprint, 
        priority: 10);

    public Task<IBlueprint> BuildAsync(CancellationToken cancellationToken)
    {
        // Construction du blueprint
        return Task.FromResult(/* blueprint */);
    }
}
```

## Avantages des Blueprints

1. **Réutilisabilité** : Définir une fois, utiliser partout
2. **Cohérence** : Garantir que tous les projets d'un type suivent les mêmes règles
3. **Modularité** : Composer des blueprints complexes à partir de blueprints simples
4. **Traçabilité** : Tous les éléments d'un contexte sont documentés et structurés
5. **Extensibilité** : Facile d'ajouter de nouveaux blueprints sans modifier le code existant
