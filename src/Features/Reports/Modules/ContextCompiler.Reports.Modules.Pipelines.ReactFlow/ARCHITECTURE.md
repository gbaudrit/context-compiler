# Architecture du Module ReactFlow

## Vue d'ensemble

Le module ContextCompiler.Reports.Modules.Pipelines.ReactFlow est composé de deux parties principales :

1. **Module .NET (C#)** : Collecte les événements de pipeline et génère l'artifact HTML
2. **Application React** : Visualise les données de pipeline de manière interactive

## Architecture .NET

### Composants Principaux

```
ContextCompiler.Reports.Modules.Pipelines.ReactFlow/
├── DependencyInjection.cs              # Enregistrement du module
├── PipelineEventCollector.cs           # Collecte les événements PhaseStarted/Completed/Failed
├── PipelineEventListener.cs            # Module qui s'enregistre tôt pour écouter les événements
├── ReactFlowPipelineReportModule.cs    # Module principal qui génère l'artifact
├── PipelineDataConverter.cs            # Convertit les événements en JSON
└── ReactFlowHtmlGenerator.cs           # Génère le HTML final avec données injectées
```

### Flux de Données

```
Pipeline Events
	↓
PipelineEventCollector (collecte pendant l'exécution)
	↓
ReactFlowPipelineReportModule (à la fin du pipeline)
	↓
PipelineDataConverter (événements → JSON)
	↓
ReactFlowHtmlGenerator (build React + inject JSON)
	↓
IOutput (artifact HTML)
```

### Enregistrement du Module

```csharp
services.AddReactFlowPipelineReportModule();
```

Cela enregistre :
- `PipelineEventCollector` (singleton)
- `PipelineEventListener` (module global, priorité 100 - tôt)
- `ReactFlowPipelineReportModule` (module global, priorité 900 - tard)

## Architecture React

### Structure des Composants

```
App.tsx (root)
├── Header.tsx (statistiques)
├── PipelineGraph.tsx (React Flow)
│   ├── PipelineNode.tsx
│   ├── StageNode.tsx
│   └── StepNode.tsx
└── Sidebar.tsx (filtres + détails)
```

### Gestion de l'État (Zustand)

Le store centralisé gère :
- **rawData** : Données brutes du pipeline (GraphData)
- **nodes/edges** : Nœuds et arêtes React Flow avec layout
- **selectedNodeId** : Nœud actuellement sélectionné
- **collapsedNodes** : Set des nœuds repliés
- **filters** : Filtres actifs (pipeline, phase, module, item)
- **viewState** : Options d'affichage (showPipelineIds, showHierarchy, fitView)
- **filteredNodeIds** : Set des nœuds visibles après filtrage

### Services

#### layoutService.ts

Utilise ELK.js pour calculer le layout automatique :
- Conversion GraphData → ELK graph
- Configuration du layout (horizontal, layered, crossingMinimization)
- Conversion ELK graph → React Flow nodes/edges

#### usePerformance.ts

Hooks d'optimisation :
- `useOptimizedNodes` : Memoization des nœuds filtrés
- `useOptimizedEdges` : Memoization des arêtes filtrées
- `useViewportNodes` : Virtualisation (render uniquement les nœuds visibles)
- `useDebouncedFilter` : Debouncing des filtres
- `useGraphStats` : Calcul des statistiques

### Types de Données

```typescript
GraphData {
  pipelines: PipelineNode[]
  stages: StageNode[]
  steps: StepNode[]
  edges: EdgeData[]
}

PipelineNode {
  id, name, type, parentId?, stages[]
}

StageNode {
  id, name, type, pipelineId, steps[]
}

StepNode {
  id, name, type, stageId, moduleId, itemId?,
  status, duration, startTime?, endTime?, errorMessage?
}
```

## Flux de Traitement

### 1. Collecte des Événements (.NET)

```
PipelineEventListener s'enregistre (priorité 100)
	↓
Pipeline s'exécute
	↓
Événements PhaseStarted/Completed/Failed émis
	↓
PipelineEventCollector.HandleAsync() capture chaque événement
```

### 2. Génération du Rapport (.NET)

```
ReactFlowPipelineReportModule.Run() (priorité 900)
	↓
Récupère tous les événements via PipelineEventCollector.GetEvents()
	↓
PipelineDataConverter.ConvertToJson(events)
	→ Group par pipeline
	→ Group par phase (stages)
	→ Match Started/Completed/Failed (steps)
	→ Génère les edges
	→ Retourne JSON
	↓
ReactFlowHtmlGenerator.GenerateHtml(json)
	→ Vérifie Node.js disponible
	→ npm install (si nécessaire)
	→ npm run build
	→ Lit dist/index.html
	→ Injecte JSON via window.PIPELINE_DATA
	→ Retourne HTML final
	↓
output.AddArtifact("pipeline-report-reactflow.html")
```

### 3. Visualisation (React)

```
HTML chargé dans navigateur
	↓
main.tsx monte <App />
	↓
App.tsx charge window.PIPELINE_DATA
	↓
useGraphStore.loadData(data)
	↓
useEffect calcule layout via calculateLayout(data, collapsedNodes)
	→ ELK.js calcule positions
	→ Retourne nodes/edges avec coordonnées
	↓
PipelineGraph affiche avec React Flow
	↓
User interagit (click, filter, collapse)
	↓
Store mis à jour → Re-render avec nouveaux nodes/edges
```

## Optimisations de Performance

### .NET

- **Lock** : Thread-safety pour PipelineEventCollector
- **Build cache** : Vérifie si dist/ existe et est récent (<5 min)
- **Fallback HTML** : Si build échoue, retourne HTML simple avec JSON brut

### React

- **React.memo** : Tous les composants de nœuds
- **useMemo** : Filtrage, stats, layout
- **useCallback** : Handlers d'événements
- **Zustand** : État centralisé léger (pas de Redux overhead)
- **ELK.js** : Algorithm optimisé pour grands graphes
- **React Flow** : Virtualisation intégrée des nœuds hors viewport

### Layout

- **Hiérarchique** : Pipelines → Stages → Steps
- **Horizontal** : Direction LEFT-TO-RIGHT
- **Layered** : Algorithm layered avec crossing minimization
- **Orthogonal routing** : Edges à angles droits
- **Spacing optimisé** : Espacement entre nœuds et layers

## Extensibilité

### Ajouter un nouveau type de nœud

1. Créer le composant React (ex: `TaskNode.tsx`)
2. Enregistrer dans `nodeTypes` de `PipelineGraph.tsx`
3. Ajouter le type dans `types.ts`
4. Adapter `layoutService.ts` pour gérer les dimensions
5. Adapter `PipelineDataConverter.cs` pour générer le JSON

### Ajouter un nouveau filtre

1. Ajouter le champ dans `Filters` interface (`types.ts`)
2. Ajouter le select dans `Sidebar.tsx`
3. Adapter `applyFilters()` dans `graphStore.ts`
4. Ajouter l'option dans `useFilterOptions()`

### Ajouter une nouvelle vue

1. Créer le composant (ex: `TimelineView.tsx`)
2. Ajouter un toggle dans `Sidebar.tsx`
3. Conditionner l'affichage dans `App.tsx`
4. Partager le même `useGraphStore` pour cohérence

## Dépendances

### .NET

- ContextCompiler.Modules.Abstractions
- Microsoft.Extensions.Logging.Abstractions
- System.Text.Json

### React

- react@18.3.1
- react-dom@18.3.1
- reactflow@11.11.4
- elkjs@0.9.3
- zustand@4.5.5
- typescript@5.7.2
- vite@6.0.3

## Limitations et Améliorations Futures

### Actuelles

- Le layout complet est recalculé à chaque collapse/expand
- Pas de streaming pour très gros graphes (>10k nœuds)
- Build React nécessite Node.js installé

### Améliorations Possibles

1. **Layout incrémental** : Ne recalculer que les sous-graphes affectés
2. **Streaming** : Charger progressivement les nœuds au scroll
3. **Worker threads** : Calculer le layout dans un Web Worker
4. **Export SVG/PNG** : Ajouter des fonctionnalités d'export
5. **Recherche** : Chercher des nœuds par nom/id/propriété
6. **Historique** : Navigation dans l'historique des sélections
7. **Comparaison** : Comparer deux exécutions de pipeline
8. **Bundle précompilé** : Embarquer le build React dans le package NuGet

## Sécurité

- Pas de backend : L'application est entièrement côté client
- Données injectées dans HTML : Utilise `window.PIPELINE_DATA` (safe)
- Pas de CORS : Tout est dans un fichier HTML statique
- Pas d'authentification requise : Le fichier HTML est local

## Tests

### Tests .NET

Tester avec :
```bash
dotnet build
```

### Tests React

```bash
cd react-app
npm install
npm run build
```

### Test E2E

1. Exécuter un pipeline ContextCompiler avec le module enregistré
2. Vérifier que `pipeline-report-reactflow.html` est généré
3. Ouvrir le fichier dans un navigateur
4. Vérifier que le graphe s'affiche correctement
5. Tester les interactions (zoom, pan, sélection, filtres, collapse)

## Packaging et Distribution

### Structure du Package NuGet

Le module est distribué via NuGet avec la structure suivante :

```
ContextCompiler.Reports.Modules.Pipelines.ReactFlow.nupkg
├── lib/net10.0/
│   ├── ContextCompiler.Reports.Modules.Pipelines.ReactFlow.dll
│   ├── ContextCompiler.Reports.Modules.Pipelines.ReactFlow.pdb
│   └── ContextCompiler.Reports.Modules.Pipelines.ReactFlow.xml
├── contentFiles/any/any/                    ← NuGet standard for static assets
│   └── react-app/
│       └── dist/                            ← Pre-built React application
│           ├── index.html
│           └── assets/
│               ├── index.js  (~1.7 MB uncompressed)
│               └── style.css (~8 KB)
├── README.md
├── ARCHITECTURE.md
├── USAGE.md
└── CHANGELOG.md
```

**Taille du package :** ~560 KB compressé, ~1.77 MB décompressé

### Résolution des Assets

Le module résout le chemin de l'application React selon la hiérarchie suivante :

1. **`{package-root}/contentFiles/any/any/react-app/`** (NuGet convention - production)
2. **`{package-root}/module-assets/react-app/`** (Alternative convention)
3. **`{package-root}/react-app/`** (Legacy fallback)
4. **`{module-directory}/react-app/`** (Development mode)
5. **Source tree search** (Development mode - recherche du `.csproj`)

Cette stratégie multi-path permet au module de fonctionner :
- ✅ En production (package NuGet extrait)
- ✅ En développement local (source tree)
- ✅ Avec différentes conventions de packaging

### Exemple de Résolution de Chemin

Quand le module est chargé depuis un package NuGet :

```
Installation path:
  {InstallRoot}/ContextCompiler.Reports.Modules.Pipelines.ReactFlow/0.1.0/{hash}/
    lib/net10.0/
      Module.dll  ← GetType().Assembly.Location
    contentFiles/any/any/
      react-app/
        dist/     ← Assets trouvés ici
          index.html
          assets/
```

**Algorithme :**
1. Obtenir le chemin de l'assembly : `lib/net10.0/Module.dll`
2. Remonter 2 niveaux pour atteindre la racine du package
3. Chercher `contentFiles/any/any/react-app/` (trouvé ✅)
4. `ReactFlowHtmlGenerator` cherche ensuite `dist/index.html`

### Build et Package

Le build React est **automatique** lors du packaging :

```bash
dotnet pack --configuration Release
```

Le target MSBuild `BuildReactApp` :
- Vérifie si `react-app/dist/index.html` existe
- Si absent : lance `npm install && npm run build`
- Si présent : skip (smart caching)

Voir [BUILD-INSTRUCTIONS.md](BUILD-INSTRUCTIONS.md) pour plus de détails.

## Références

- [React Flow Documentation](https://reactflow.dev/)
- [ELK.js Documentation](https://eclipse.dev/elk/)
- [Zustand Documentation](https://github.com/pmndrs/zustand)
- [Vite Documentation](https://vitejs.dev/)
