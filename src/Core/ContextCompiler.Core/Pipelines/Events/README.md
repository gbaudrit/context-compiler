# Pipeline Events

Le système d'événements de pipeline permet de publier des événements lors de l'exécution des phases de pipeline.

## Événements disponibles

- **PhaseStarted** : Publié au début d'une phase
- **PhaseCompleted** : Publié à la fin d'une phase avec succès
- **PhaseFailed** : Publié lorsqu'une phase échoue

## Utilisation

### Publication manuelle d'événements

```csharp
await eventPublisher.PublishPhaseStartedAsync(
    pipelineId: "doc-pipeline",
    phaseId: "reading",
    moduleId: "excel-reader",
    cancellationToken);

await eventPublisher.PublishPhaseCompletedAsync(
    pipelineId: "doc-pipeline",
    phaseId: "reading",
    moduleId: "excel-reader",
    duration: TimeSpan.FromMilliseconds(150),
    cancellationToken);

await eventPublisher.PublishPhaseFailedAsync(
    pipelineId: "doc-pipeline",
    phaseId: "reading",
    moduleId: "excel-reader",
    exception: ex,
    cancellationToken);
```

### Publication automatique avec gestion d'erreurs

La méthode `PublishPhaseAsync` gère automatiquement la publication des événements Started/Completed/Failed :

```csharp
// Avec retour de valeur
IInputItemContextPatch result = await eventPublisher.PublishPhaseAsync(
    pipelineId: "doc-pipeline",
    phaseId: "processing",
    moduleId: "guard-module",
    action: async () => await ProcessDocumentAsync(context),
    cancellationToken);

// Sans retour de valeur
await eventPublisher.PublishPhaseAsync(
    pipelineId: "doc-pipeline",
    phaseId: "validation",
    moduleId: "schema-validator",
    action: async () => await ValidateAsync(context),
    cancellationToken);
```

## Injection de dépendance

Le service est automatiquement enregistré lors de l'appel à `AddPipelines()` :

```csharp
services.AddPipelines();
```

## Implémentation personnalisée

Pour implémenter un gestionnaire d'événements personnalisé, implémentez `IPipelineEventPublisher`.

Seule la méthode `PublishAsync<TEvent>` doit être implémentée, toutes les autres méthodes ont des implémentations par défaut dans l'interface :

```csharp
public class CustomEventPublisher : IPipelineEventPublisher
{
    public ValueTask PublishAsync<TEvent>(TEvent e, CancellationToken cancellationToken = default)
        where TEvent : IPipelineEvent
    {
        // Votre logique personnalisée (ex: envoi à un message broker, métriques, etc.)
        return ValueTask.CompletedTask;
    }
}
```

Puis enregistrez votre implémentation :

```csharp
services.AddSingleton<IPipelineEventPublisher, CustomEventPublisher>();
```

## Architecture

Les méthodes d'aide (`PublishPhaseStartedAsync`, `PublishPhaseCompletedAsync`, `PublishPhaseFailedAsync`, `PublishPhaseAsync`) sont définies dans l'interface `IPipelineEventPublisher` et implémentées dans la classe `PipelineEventPublisher`.

Cela signifie :
- ✅ Toutes les méthodes sont dans la classe concrète
- ✅ L'interface définit le contrat complet
- ✅ Pas besoin de méthodes d'extension
