# ContextCompiler.Reports.Modules.Pipelines.ReactFlow

Module qui génère des visualisations interactives de pipelines complexes avec React Flow et ELK.js pour le layout automatique.

## Fonctionnalités

- **Visualisation interactive** : Graphe de pipeline interactif avec zoom, pan et minimap
- **Layout automatique** : Utilise ELK.js pour positionner automatiquement les nœuds de manière hiérarchique horizontale
- **Support de grands graphes** : Optimisé pour afficher plusieurs milliers de nœuds
- **Hiérarchie des pipelines** : Visualise les relations parent/enfant entre pipelines, stages et steps
- **Collapse/Expand** : Possibilité de replier/déplier les sous-pipelines pour simplifier la vue
- **Code couleur** : Visualisation claire par type (pipeline, stage, step) et état (success, failed, running)
- **Panneau de détails** : Affiche les informations détaillées au clic sur un nœud
- **Filtres dynamiques** : Filtrer par pipeline, phase, module ou item
- **Chargement lazy** : Support du chargement progressif des sous-graphes pour améliorer les performances
- **Export HTML statique** : Génère un fichier HTML autonome sans besoin de serveur

## Architecture

Le module est composé de deux parties :

### 1. Module .NET (C#)

- **ReactFlowPipelineReportModule** : Module principal qui collecte les événements de pipeline
- **PipelineDataConverter** : Convertit les événements en structure JSON pour React
- **ReactFlowHtmlGenerator** : Génère le fichier HTML final avec les données injectées

### 2. Application React (TypeScript)

- **Graph Store (Zustand)** : Gestion centralisée de l'état (graphe, sélection, filtres)
- **Layout Service (ELK.js)** : Calcul automatique du layout hiérarchique
- **React Flow Components** : Composants pour pipelines, stages et steps
- **Pipeline Renderer** : Rendu principal du graphe
- **UI Controls** : Panneau de détails, filtres, contrôles de vue

## Installation

```csharp
services.AddReactFlowPipelineReportModule();
```

## Prerequisites

**For Development/Building:**
- Node.js 18+ (for building the React app)
- npm (comes with Node.js)

**At Runtime:**
- ✅ **No Node.js required!** The React app is pre-built and included in the NuGet package.

## Building

The React application is **automatically built** when you create a NuGet package:

```bash
dotnet pack --configuration Release
```

The build system will:
1. Check if `react-app/dist/` exists
2. If missing, automatically run `npm install && npm run build`
3. Include the pre-built app in the NuGet package

### Manual Build (Optional)

You can also manually build the React app:

```powershell
# Using the build script
.\build-react-app.ps1
```

Or with npm:

```bash
cd react-app
npm install
npm run build
```

See [BUILD-INSTRUCTIONS.md](BUILD-INSTRUCTIONS.md) for more details on the automatic build system.

## Utilisation

Le module s'exécute automatiquement à la fin du pipeline global et génère un fichier HTML dans le dossier de sortie :

- **pipeline-report-reactflow.html** : Vue interactive React Flow complète

## Structure des données

Le module convertit les événements de pipeline en une structure JSON optimisée :

```json
{
  "pipelines": [
	{
	  "id": "pipeline-1",
	  "name": "CompilePipeline",
	  "type": "global",
	  "parentId": null,
	  "stages": [
		{
		  "id": "stage-1",
		  "name": "Setup",
		  "steps": [
			{
			  "id": "step-1",
			  "name": "Initialize",
			  "moduleId": "module.init",
			  "itemId": null,
			  "status": "completed",
			  "duration": 150,
			  "startTime": "2024-01-01T10:00:00Z",
			  "endTime": "2024-01-01T10:00:00.150Z"
			}
		  ]
		}
	  ]
	}
  ],
  "edges": [
	{
	  "id": "edge-1",
	  "source": "step-1",
	  "target": "step-2",
	  "type": "sequential"
	}
  ]
}
```

## Fonctionnalités interactives

### Zoom & Pan

- **Molette de souris** : Zoom in/out
- **Click & drag** : Déplacer le graphe
- **Fit View** : Bouton pour ajuster automatiquement la vue

### Minimap

Affiche une vue d'ensemble du graphe avec indicateur de la zone visible.

### Sélection

Cliquer sur un nœud pour afficher ses détails dans le panneau latéral.

### Collapse/Expand

Les nœuds de pipeline avec sous-graphes peuvent être repliés pour simplifier la visualisation.

### Filtres

- **Pipeline** : Afficher uniquement un pipeline spécifique
- **Phase** : Se concentrer sur une phase particulière
- **Module** : Voir l'exécution d'un module
- **Item** : Tracer le parcours d'un item spécifique

## Performance

Le module est optimisé pour de grands graphes :

- **Memoization** : React.memo, useMemo, useCallback pour éviter les re-renders
- **Layout incrémental** : Recalcul du layout uniquement pour les parties modifiées
- **Virtualisation** : Les nœuds hors viewport ne sont pas rendus
- **Lazy loading** : Chargement progressif des sous-graphes au besoin

## Build et développement

### Builder l'application React

```bash
cd react-app
npm install
npm run build
```

### Mode développement

```bash
cd react-app
npm run dev
```

L'application sera accessible à `http://localhost:5173` avec hot reload.

## Dépendances React

- **React** 18+
- **React Flow** : Bibliothèque de graphes interactifs
- **ELK.js** : Algorithme de layout automatique
- **Zustand** : Gestion d'état légère
- **TypeScript** : Typage statique

## Troubleshooting

### Le fichier HTML n'est pas généré

Vérifier que Node.js est installé :
```bash
node --version
npm --version
```

### Le graphe ne s'affiche pas

Vérifier la console du navigateur pour les erreurs JavaScript.

### Performance dégradée avec de gros graphes

- Utiliser les filtres pour réduire le nombre de nœuds affichés
- Activer le mode "collapse" pour les sous-pipelines
- Vérifier que le navigateur n'est pas en mode de limitation de performances

## Comparaison avec le module Mermaid

| Fonctionnalité | Mermaid | React Flow |
|----------------|---------|------------|
| Interactivité | Limitée | Complète |
| Layout automatique | Basique | Avancé (ELK) |
| Performance grands graphes | Moyenne | Excellente |
| Collapse/Expand | Non | Oui |
| Chargement lazy | Non | Oui |
| Filtres | Basiques | Avancés |
| Prérequis | Aucun | Node.js |

## Licence

Voir LICENSE dans le repository principal.
