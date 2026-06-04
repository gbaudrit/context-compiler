# Améliorations du Module Mermaid Pipeline Report

## Résumé des modifications

Le module de rapport Mermaid a été considérablement amélioré pour supporter l'affichage détaillé de l'exécution du pipeline, y compris au niveau des items individuels, avec une vue interactive permettant de filtrer et de visualiser les hiérarchies de pipelines.

## Nouvelles fonctionnalités

### 1. Vue Interactive avec Filtres (`pipeline-report-interactive.html`) ⭐ RECOMMANDÉE

La nouvelle vue interactive offre :

#### Filtres dynamiques
- **Filtre par Pipeline** : Sélectionner un pipeline spécifique
- **Filtre par Phase** : Se concentrer sur une phase particulière
- **Filtre par Module** : Analyser l'exécution d'un module
- **Filtre par Item** : Tracer l'exécution d'un item spécifique
- **Boutons Apply/Reset** : Appliquer ou réinitialiser les filtres

#### Modes de groupement ⭐ NOUVEAU
- **Group by Item** (par défaut) : Organise le diagramme par fichier/item
  - Montre le parcours complet de chaque fichier à travers toutes les phases
  - Visualise les sous-pipelines par item (ex: DataPartPipelineRunner pour chaque fichier)
  - Structure : Pipeline → Item → Phase → Événements
  - **Idéal pour** : Tracer "Que s'est-il passé avec ce fichier ?"

- **Group by Phase** : Organise le diagramme par phase
  - Regroupe tous les items dans chaque phase
  - Structure : Pipeline → Phase → Événements (avec ItemId)
  - **Idéal pour** : Analyser "Quels items ont été traités dans cette phase ?"

#### Hiérarchie des pipelines
- **Visualisation des liens parent/enfant** : Les sous-pipelines sont reliés à leur pipeline parent
- **Toggle activable/désactivable** : Afficher/masquer les liens de hiérarchie
- **Utilisation de `ISubPipelineRunContext`** : Détection automatique des relations parent/enfant
- **Flèches spéciales** : Liens parent→enfant affichés avec `==>|sub-pipeline|`
- **Support multi-niveaux** : CompilePipeline → InputIngestionPipeline → DataPartPipelineRunner

#### Diagramme généré dynamiquement
- Le diagramme Mermaid est **recalculé** en temps réel selon les filtres et le mode de groupement
- Mise à jour instantanée lors du changement de filtres ou de mode
- Pas de rechargement de page nécessaire

#### Résolution du problème de lisibilité
- **Solution au diagramme horizontal** : Les filtres permettent de réduire le nombre d'événements affichés
- **Mode Group by Item** : Montre clairement le parcours de chaque fichier avec ses sous-pipelines
- **Vue focalisée** : Sélectionner uniquement ce qui intéresse (ex: un item spécifique)
- **Performance** : Gère des milliers d'événements sans problème de rendu

### 2. Deux niveaux de détail (vues statiques)

Le module génère également **deux rapports HTML statiques** :

#### Vue Détaillée (`pipeline-report-detailed.html`)
- Affiche **chaque événement individuellement**
- Inclut le **ModuleId** pour chaque événement
- Inclut le **ItemId** pour les événements au niveau item (vide pour le pipeline global)
- Affiche le **timestamp précis** (HH:mm:ss.fff) pour les événements Started
- Affiche la **durée d'exécution** pour les événements Completed
- Affiche le **message d'erreur** (tronqué à 50 caractères) pour les événements Failed
- Organisation en **sous-graphes** : Pipeline > Phase > Événements
- Connexions entre événements consécutifs au sein d'une phase
- Connexions en pointillés entre phases

#### Vue Condensée (`pipeline-report-condensed.html`)
- Regroupe tous les événements d'une **même phase en un seul nœud**
- Affiche le **nombre de modules** exécutés
- Affiche le **nombre d'items** traités (hors ItemId vides)
- Affiche la **durée totale cumulée** par phase
- Affiche le **statut final** de la phase (Started/Completed/Failed)
- Vue compacte idéale pour une **analyse rapide**

### 3. Gestion améliorée des limites Mermaid

- **maxTextSize** augmenté de 50 000 à **200 000 caractères**
- **maxEdges** augmenté de 500 à **2 000 arêtes**
- Permet de gérer des pipelines très complexes

### 4. Nouvelle classe de configuration

`MermaidDiagramOptions` avec :
- `DetailLevel` : Choix entre Detailed et Condensed
- `MaxTextSize` : Configurable (défaut : 200 000)
- `MaxEdges` : Configurable (défaut : 2 000)
- `ShowModuleDetails` : Afficher les détails des modules
- `ShowDuration` : Afficher les durées
- `ShowItemIds` : Afficher les identifiants d'items

### 5. Amélioration de l'interface utilisateur

- **Vue interactive** avec panneau de filtres complet
- Boîte d'information affichant le **nombre total d'événements** et le **nombre d'événements filtrés**
- Checkbox pour activer/désactiver les **liens de hiérarchie des pipelines**
- Titres différenciés pour les trois vues (Interactive / Detailed / Condensed)
- Légende des couleurs conservée
- Style visuellement amélioré avec boîtes d'information

## Fichiers modifiés et créés

1. **InteractiveMermaidHtmlGenerator.cs** (nouveau) ⭐
   - Génère la vue interactive avec filtres dynamiques
   - Sérialise les événements en JSON pour JavaScript
   - Détecte et expose les relations parent/enfant des pipelines via `ISubPipelineRunContext`
   - Génère le diagramme Mermaid côté client en temps réel
   - Gère les filtres par Pipeline, Phase, Module et Item
   - Toggle pour afficher/masquer les liens de hiérarchie

2. **MermaidDiagramOptions.cs** (nouveau)
   - Classe de configuration
   - Enum `DiagramDetailLevel` (Condensed, Detailed)

3. **PipelineEventCollector.cs**
   - Méthode `GenerateMermaidDiagram()` accepte maintenant un paramètre `DiagramDetailLevel`
   - Nouvelle méthode `GenerateDetailedDiagram()` : génère la vue détaillée
   - Nouvelle méthode `GenerateCondensedDiagram()` : génère la vue condensée
   - `PhaseGroup` inclut maintenant `ItemIds` en plus de `ModuleIds`
   - Utilise `RunContext.Pipeline.Id` au lieu de `PipelineId`

4. **MermaidHtmlGenerator.cs**
   - Paramètre `maxTextSize: 200000` ajouté à la configuration Mermaid
   - Paramètre `maxEdges: 2000` ajouté à la configuration Mermaid
   - Paramètre `eventCount` ajouté pour afficher le nombre d'événements
   - Boîte d'information stylisée pour afficher les statistiques

5. **MermaidPipelineReportModule.cs**
   - Génère maintenant **trois artifacts** : interactive, detailed et condensed
   - Appels distincts pour chaque vue
   - Noms de fichiers différenciés :
     - `pipeline-report-interactive.html` ⭐ (recommandé)
     - `pipeline-report-detailed.html`
     - `pipeline-report-condensed.html`

6. **README.md**
   - Documentation complète des trois vues
   - Exemples de diagrammes pour chaque vue
   - Section "Résolution des problèmes" enrichie
   - Guide d'utilisation des rapports avec focus sur la vue interactive

## Utilisation de la hiérarchie des pipelines

### Détection automatique via `ISubPipelineRunContext`
- Le module détecte automatiquement si un événement provient d'un sous-pipeline
- Si `RunContext is ISubPipelineRunContext`, le `ParentPipelineId` est extrait via `subContext.Parent.Pipeline.Id`
- Les liens parent→enfant sont affichés avec une flèche épaisse `==>|sub-pipeline|`

### Toggle dans la vue interactive
- Une checkbox permet d'afficher/masquer les liens de hiérarchie
- Activée par défaut pour voir la structure complète
- Peut être désactivée pour simplifier le diagramme

### Exemple de hiérarchie
```
CompilePipeline ==>|sub-pipeline| InputIngestionPipeline
```

## Utilisation des informations ModuleId et ItemId

### ModuleId
- **Vue interactive** : Filtrable et affiché sur chaque nœud
- **Vue détaillée** : Affiché sur chaque nœud d'événement
- **Vue condensée** : Comptabilisé et affiché comme "X modules"
- Permet d'identifier quel module a généré chaque événement

### ItemId
- **Vue interactive** : Filtrable et affiché sur chaque nœud (si non vide)
- **Vue détaillée** : Affiché sur chaque nœud d'événement (si non vide)
- **Vue condensée** : Comptabilisé et affiché comme "X items"
- Permet de tracer l'exécution au niveau item
- Les ItemId vides (pipeline global) sont gérés sans affichage superflu

## Avantages

### Pour l'exploration interactive ⭐ NOUVEAU
- La **vue interactive** permet de :
  - **Filtrer dynamiquement** les événements par pipeline, phase, module ou item
  - **Résoudre le problème de lisibilité** : se concentrer sur une partie du pipeline
  - **Voir les hiérarchies** : comprendre les relations entre pipelines
  - **Analyser un item spécifique** : suivre son parcours complet
  - **Débugger efficacement** : isoler les événements problématiques
  - Mise à jour instantanée du diagramme sans rechargement

### Pour le debugging
- La **vue détaillée** permet de voir exactement :
  - Quel module a traité quel item
  - À quelle heure précise (timestamp)
  - Combien de temps cela a pris
  - Quelle erreur s'est produite (si échec)

### Pour la vue d'ensemble
- La **vue condensée** permet de :
  - Voir rapidement le flux global du pipeline
  - Identifier les phases les plus longues (durée totale)
  - Voir combien de modules et d'items ont été traités par phase
  - Avoir une vue non surchargée du pipeline

### Pour les gros pipelines
- La génération de **trois vues** offre le meilleur des deux mondes
- La **vue interactive** résout définitivement le problème de lisibilité
  - Filtre les milliers d'événements pour n'afficher que ce qui intéresse
  - Performance excellente même avec des pipelines complexes
- La vue condensée reste utilisable même avec des milliers d'événements
- La vue détaillée permet un debugging approfondi sur des sections spécifiques

## Solution au problème de lisibilité ✅

### Problème initial
Les diagrammes détaillés avec de nombreux événements s'affichaient sur une seule ligne horizontale, devenant illisibles.

### Solution : Vue Interactive avec Filtres
1. **Utiliser `pipeline-report-interactive.html`** (recommandé)
2. **Filtrer par item** : Sélectionner un item spécifique pour voir uniquement son parcours
3. **Filtrer par phase** : Se concentrer sur une phase problématique
4. **Filtrer par module** : Analyser l'exécution d'un module particulier
5. **Combiner les filtres** : Par exemple, voir un item spécifique dans une phase donnée

### Exemple d'utilisation
```
1. Ouvrir pipeline-report-interactive.html
2. Sélectionner un Item dans le filtre "Item"
3. Cliquer sur "Apply Filters"
4. Le diagramme n'affiche plus que les événements de cet item
5. Le graphe est maintenant lisible et vertical !
```
- La vue détaillée permet un debugging approfondi sur des sections spécifiques

## Compatibilité

- ✅ Compatible avec l'interface `IPipelineEvent` mise à jour
- ✅ Gère les `ItemId` vides (pipeline global)
- ✅ Gère les `ModuleId` vides (cas exceptionnel)
- ✅ Thread-safe (utilisation de `lock`)
- ✅ Build réussi sans erreurs ni avertissements

## Exemple de sortie

Après l'exécution du pipeline, vous trouverez dans le dossier `.ctxc/compiled` :

```
.ctxc/
└── compiled/
    ├── pipeline-report-detailed.html    ← Vue complète avec tous les événements
    └── pipeline-report-condensed.html   ← Vue résumée par phase
```

## Recommandations d'utilisation

1. **Développement et debugging** : Utiliser `pipeline-report-detailed.html`
2. **Monitoring et revue** : Utiliser `pipeline-report-condensed.html`
3. **Présentation** : Utiliser `pipeline-report-condensed.html`
4. **Analyse d'erreurs** : Utiliser `pipeline-report-detailed.html`
