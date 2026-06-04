# Vue Interactive - Solution Complète

## Problème résolu ✅

### Avant
Le diagramme détaillé générait tous les événements sur une seule ligne horizontale, rendant le graphe illisible quand il y avait beaucoup d'événements (ex: 1000 fichiers traités).

### Après ⭐
La nouvelle **vue interactive** (`pipeline-report-interactive.html`) permet de :
- **Filtrer dynamiquement** les événements
- **Se concentrer** sur ce qui importe (un item, une phase, un module)
- **Visualiser les hiérarchies** de pipelines parent/enfant
- **Diagramme lisible** : Le graphe devient vertical et gérable

## Fonctionnalités principales

### 1. Système de filtrage complet

| Filtre | Description | Cas d'usage |
|--------|-------------|-------------|
| **Pipeline** | Sélectionner un pipeline spécifique | Analyser un sous-pipeline particulier |
| **Phase** | Se concentrer sur une phase | Débugger une étape problématique |
| **Module** | Voir les événements d'un module | Analyser l'exécution d'un module |
| **Item** | Tracer le parcours d'un item | **Résout le problème de lisibilité** |

### 2. Hiérarchie des pipelines

#### Détection automatique
Le module utilise `ISubPipelineRunContext` pour détecter les relations parent/enfant :

```csharp
if (e.RunContext is ISubPipelineRunContext subContext)
{
    parentPipelineId = subContext.Parent.Pipeline.Id;
}
```

#### Visualisation
- Liens affichés avec `==>|sub-pipeline|`
- Checkbox pour activer/désactiver
- Exemple :
  ```mermaid
  CompilePipeline ==>|sub-pipeline| InputIngestionPipeline
  InputIngestionPipeline ==>|sub-pipeline| DocumentProcessingPipeline
  ```

### 3. Génération dynamique du diagramme

Le diagramme Mermaid est généré **côté client** en JavaScript :
- Les événements sont sérialisés en JSON
- Le JavaScript filtre et génère le code Mermaid
- Mermaid v11 rend le diagramme dans le navigateur
- Mise à jour instantanée lors du changement de filtres

## Architecture

```
InteractiveMermaidHtmlGenerator.cs
├── Sérialisation des événements en JSON
│   ├── Extraction de PipelineId via RunContext.Pipeline.Id
│   ├── Détection de ParentPipelineId via ISubPipelineRunContext
│   └── Informations : Name, PhaseId, ModuleId, ItemId, Timestamp, Duration, Error
├── Génération HTML
│   ├── Section Filtres (Pipeline, Phase, Module, Item)
│   ├── Checkbox "Show pipeline hierarchy links"
│   ├── Boîte d'information (événements totaux / filtrés)
│   └── Container pour le diagramme Mermaid
└── JavaScript
    ├── Fonction populateFilters() : Remplit les dropdowns
    ├── Fonction applyFilters() : Filtre les événements
    ├── Fonction generateDiagram() : Génère le code Mermaid
    └── Event listeners : Change, DOMContentLoaded
```

## Exemple de flux utilisateur

### Scénario : Pipeline avec 500 fichiers

```
1. Exécution du pipeline
   ├── 500 fichiers traités
   ├── Plusieurs phases par fichier
   └── ~3000 événements générés

2. Ouverture de pipeline-report-detailed.html
   └── ❌ Diagramme horizontal illisible

3. Ouverture de pipeline-report-interactive.html
   ├── ✅ Page avec filtres affichée
   ├── Dropdown "Item" contient les 500 fichiers
   └── Message : "Total events: 3000"

4. Sélection d'un fichier spécifique
   ├── Choisir "src/MyFile.cs" dans le dropdown "Item"
   ├── Cliquer "Apply Filters"
   └── ✅ Message : "Filtered events: 6"

5. Résultat
   └── ✅ Diagramme vertical lisible avec 6 événements
       (Started/Completed pour chaque phase du fichier)
```

## Avantages de la solution

### Pour les développeurs
- ✅ **Debugging efficace** : Isoler un item problématique
- ✅ **Analyse ciblée** : Se concentrer sur une phase spécifique
- ✅ **Compréhension** : Voir les hiérarchies de pipelines

### Pour les performances
- ✅ **Pas de limite** : Gère des milliers d'événements
- ✅ **Rendu rapide** : Filtrage côté client instantané
- ✅ **Scalable** : Le JSON est optimisé

### Pour l'UX
- ✅ **Intuitif** : Interface de filtrage simple
- ✅ **Flexible** : Combinaison de filtres
- ✅ **Interactif** : Mise à jour en temps réel

## Comparaison des trois vues

| Vue | Cas d'usage | Avantages | Inconvénients |
|-----|-------------|-----------|---------------|
| **Interactive** ⭐ | Exploration, debugging | Filtres, hiérarchie, lisible | Nécessite JavaScript |
| **Detailed** | Analyse complète | Tous les détails, statique | Peut être illisible si trop d'événements |
| **Condensed** | Vue d'ensemble | Compact, statistiques | Moins de détails |

## Recommandation

🎯 **Utiliser `pipeline-report-interactive.html` comme première approche**

C'est la vue la plus puissante et flexible. Elle résout tous les problèmes de lisibilité tout en offrant le maximum d'informations.

Les vues detailed et condensed restent utiles pour :
- Des captures d'écran statiques
- Des rapports offline
- Une vue sans JavaScript
