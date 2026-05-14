# ContextCompiler.DevTools.Modules.EventsLogger

## Description

Module DevTools qui collecte tous les événements de pipeline (`IPipelineEvent`) et génère un fichier de log simple listant tous les événements dans l'ordre chronologique.

## Fonctionnalités

- ✅ Collecte automatique de tous les événements de pipeline
- ✅ Tri chronologique des événements
- ✅ Génération d'un fichier de log simple et lisible
- ✅ Support des événements : `PhaseStarted`, `PhaseCompleted`, `PhaseFailed`
- ✅ Affichage des durées d'exécution pour les phases complétées
- ✅ Affichage des erreurs et stack traces pour les phases en échec

## Fichier de sortie

Le module génère un fichier `pipeline-events.log` dans les artefacts de sortie.

### Format du log

```
================================================================================
PIPELINE EVENTS LOG
Generated: 2024-01-15 10:30:45.123 UTC
Total Events: 42
================================================================================

--------------------------------------------------------------------------------
Timestamp: 2024-01-15 10:30:45.100
Event Type: PhaseStarted
Pipeline: input.ingestion
Phase: ReadFiles
Module: readers.text
Item: file1.txt

--------------------------------------------------------------------------------
Timestamp: 2024-01-15 10:30:45.150
Event Type: PhaseCompleted
Pipeline: input.ingestion
Phase: ReadFiles
Module: readers.text
Item: file1.txt
Duration: 50.25 ms

...
```

## Configuration

Aucune configuration requise. Le module s'enregistre automatiquement et commence à collecter les événements dès son chargement.

## Priorité

Priorité : 1000 (s'exécute après les autres modules de rapport)

## Usage

Ajoutez simplement ce module à votre configuration de modules ContextCompiler. Il collectera automatiquement tous les événements et générera le fichier de log à la fin de l'exécution du pipeline global.
