# Améliorations de visualisation - Version condensée

## Deux améliorations majeures

### 1. Condensation des événements Started/Completed ✅

**Avant** :
```
FileReader Started
Module: file-reader
13:43:48

FileReader Completed
Module: file-reader
150ms
```

**Après** :
```
FileReader ✓
Module: file-reader
13:43:48 | 150ms
```

#### Avantages
- ✅ **50% moins de nœuds** : Le diagramme est plus compact
- ✅ **Lisibilité améliorée** : Toutes les infos d'une phase en un seul coup d'œil
- ✅ **Durée visible** : Le temps d'exécution est affiché à côté de l'heure de début
- ✅ **Statut visuel** : ✓ pour succès, ✗ pour échec

#### Détails techniques

**Algorithme de pairage** :
1. Pour chaque événement `PhaseStarted`
2. Chercher le `PhaseCompleted` ou `PhaseFailed` correspondant
   - Même `PhaseId`
   - Même `ModuleId`
   - Timestamp postérieur
3. Si trouvé : créer un nœud "condensé"
4. Si non trouvé : créer un nœud "orphelin" (Started sans fin)

**Gestion des cas spéciaux** :
- **Événements orphelins** : Affichés séparément (Started sans Completed)
- **Événements Failed** : Affichés avec ✗ et le message d'erreur
- **Durée** : Calculée depuis l'événement `PhaseCompleted`

**Format condensé** :
```
[PipelineId]  (si option cochée)
PhaseId ✓     (✓ ou ✗)
Module: xxx
HH:MM:SS | Xms  (ou message d'erreur si échec)
```

### 2. Liens précis vers les sous-pipelines ⭐

**Avant** :
```
GlobalPipeline ==>|sub-pipeline| InputIngestionPipeline
(lien générique entre pipelines)
```

**Après** :
```
DataPartsProcessor ✓ ==>|sub-pipeline| DataPartPipelineRunner (first event)
(lien depuis l'événement qui lance le sous-pipeline)
```

#### Avantages
- ✅ **Traçabilité précise** : On voit exactement quelle phase lance quel sous-pipeline
- ✅ **Contexte visible** : Le lien part de l'événement parent (ex: DataPartsProcessor)
- ✅ **Hiérarchie claire** : La relation parent→enfant est évidente visuellement

#### Détails techniques

**Algorithme de liaison** :
1. Pour chaque sous-pipeline détecté (événements avec `ParentPipelineId`)
2. Identifier le premier événement du sous-pipeline
3. Construire une clé basée sur :
   - `ParentPipelineId`
   - `PhaseId`
   - `ModuleId`
   - `ItemId`
4. Chercher le nœud parent correspondant dans `eventNodeMap`
5. Si trouvé : créer un lien `parentNode ==>|sub-pipeline| firstChildNode`
6. Si non trouvé : fallback sur le lien générique pipeline→pipeline

**eventNodeMap** :
Structure qui stocke la référence de chaque nœud d'événement :
```javascript
{
  "InputIngestionPipeline_DataPartsProcessor_datapart-runner_file.cs": "node_id_123",
  ...
}
```

**Format de clé** :
```
${PipelineId}_${PhaseId}_${ModuleId}_${ItemId}
```

## Exemple visuel complet

### Avant les améliorations

```
InputIngestionPipeline
├── file.cs
│   ├── Reading Started (13:43:48)
│   ├── Reading Completed (150ms)
│   ├── Processing Started (13:43:49)
│   ├── Processing Completed (50ms)
│   ├── DataPartsProcessor Started (13:43:50)
│   └── DataPartsProcessor Completed (200ms)

InputIngestionPipeline ==>|sub-pipeline| DataPartPipelineRunner

DataPartPipelineRunner
└── file.cs
    ├── Transform Started (13:43:50)
    ├── Transform Completed (100ms)
    ├── Validate Started (13:43:51)
    └── Validate Completed (50ms)
```

**Problèmes** :
- 10 nœuds pour 5 phases
- Lien générique ne montre pas que c'est DataPartsProcessor qui lance le sub-pipeline

### Après les améliorations

```
InputIngestionPipeline
└── file.cs
    ├── Reading ✓
    │   Module: file-reader
    │   13:43:48 | 150ms
    ├── Processing ✓
    │   Module: guard-module
    │   13:43:49 | 50ms
    └── DataPartsProcessor ✓ ==>|sub-pipeline|─┐
        Module: datapart-runner                 │
        13:43:50 | 200ms                         │
                                                 │
DataPartPipelineRunner                           │
└── file.cs                                      │
    ├──────────────────────────────────────────┘
    ├── Transform ✓
    │   Module: transformer
    │   13:43:50 | 100ms
    └── Validate ✓
        Module: validator
        13:43:51 | 50ms
```

**Améliorations** :
- ✅ 5 nœuds au lieu de 10 (50% de réduction)
- ✅ Lien précis depuis DataPartsProcessor
- ✅ Toutes les infos visibles en un coup d'œil

## Impact sur les performances

### Réduction de la taille du diagramme

**Scénario** : 100 fichiers, 5 phases par fichier
- **Avant** : 1000 nœuds (100 × 5 × 2)
- **Après** : 500 nœuds (100 × 5 × 1)
- **Gain** : 50% de nœuds en moins

### Amélioration de la lisibilité

**Densité d'information** :
- **Avant** : 1 phase = 2 nœuds avec infos séparées
- **Après** : 1 phase = 1 nœud avec toutes les infos

**Navigation** :
- **Avant** : Suivre 2 nœuds pour comprendre une phase
- **Après** : 1 seul nœud à regarder

### Traçabilité des sous-pipelines

**Avant** :
- "InputIngestionPipeline lance DataPartPipelineRunner"
- Mais quelle phase précisément ?

**Après** :
- "DataPartsProcessor lance DataPartPipelineRunner"
- Précision au niveau de l'événement !

## Configuration

### Événements orphelins

Si un événement `PhaseStarted` n'a pas de `PhaseCompleted` correspondant :
- Il est affiché comme un nœud séparé avec le style "Started" (bleu)
- Utile pour identifier les phases en cours ou qui ont échoué sans émettre `PhaseFailed`

### Fallback des liens

Si le nœud parent n'est pas trouvé dans `eventNodeMap` :
- Le système utilise le lien générique pipeline→pipeline
- Garantit que le diagramme est toujours généré même si les données sont incomplètes

## Limitations et cas particuliers

### Événements asynchrones

Si plusieurs phases avec le même nom s'exécutent en parallèle :
- Le pairage fonctionne sur le **premier** `Completed` trouvé après le `Started`
- L'ordre chronologique est respecté

### Sous-pipelines multiples

Si un événement lance plusieurs sous-pipelines :
- Chaque sous-pipeline reçoit son propre lien
- Les liens partent tous du même nœud parent

### Événements dupliqués

Si vous activez "Show Pipeline ID in labels" :
- Les événements du même nom mais de pipelines différents sont distingués
- Le pairage fonctionne correctement car il utilise `PipelineId` + `PhaseId` + `ModuleId`

## Conclusion

Ces deux améliorations rendent le diagramme :
- ✅ **50% plus compact** : Moins de nœuds
- ✅ **Plus lisible** : Infos consolidées
- ✅ **Plus précis** : Liens au niveau des événements
- ✅ **Plus informatif** : Toutes les infos en un coup d'œil
