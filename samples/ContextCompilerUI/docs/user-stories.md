# User Stories — Context-Compiler Prompting Interface

## Épic : Parcourir le catalogue Context Compiler

---

### US-01 — Parcourir les modules disponibles

**En tant que** développeur / AI Engineer utilisant Context Compiler,  
**Je veux** parcourir la liste des modules disponibles avec leur description et leur rôle dans le pipeline,  
**Afin de** découvrir les capacités atomiques que je peux combiner.

#### Critères d'acceptation

```gherkin
Given  l'utilisateur ouvre la page "Modules"
When   la page est chargée
Then   la liste de tous les modules est affichée avec : nom, description, catégorie (Readers / Prompt / Views / Personas / Engineering)

Given  l'utilisateur saisit un texte dans la barre de recherche
When   il tape au moins 2 caractères
Then   la liste est filtrée en temps réel sans rechargement

Given  l'utilisateur clique sur un module
When   le panneau de détail s'ouvre
Then   les informations complètes sont affichées : nom, ID NuGet, description, rôle pipeline
```

#### Validation INVEST
| Critère | OK | Commentaire |
|---|---|---|
| Independent | ✅ | Pas de dépendance aux autres US |
| Negotiable | ✅ | Filtres/catégories ajustables |
| Valuable | ✅ | Découverte = prerequis de tout usage |
| Estimable | ✅ | 2–3 SP |
| Small | ✅ | Périmètre clair |
| Testable | ✅ | Critères Given/When/Then définis |

**Estimation** : 3 SP | **Priorité** : Must Have

#### Definition of Ready
- [ ] API `/api/modules` documentée et disponible
- [ ] Maquette de la page validée
- [ ] Données de test disponibles (au moins 5 modules)

#### Definition of Done
- [ ] Page rendue en < 1 s (réseau local)
- [ ] Recherche filtrante fonctionnelle
- [ ] Tests unitaires du composant list
- [ ] Responsive mobile/desktop

---

### US-02 — Parcourir les packs disponibles

**En tant que** développeur / AI Engineer,  
**Je veux** parcourir les packs disponibles et voir leur composition (quels modules ils regroupent),  
**Afin de** choisir rapidement un preset de modules adapté à mon besoin sans configurer manuellement chaque module.

#### Critères d'acceptation

```gherkin
Given  l'utilisateur ouvre la page "Packs"
When   la page est chargée
Then   chaque pack liste ses modules membres avec une icône et une description courte

Given  l'utilisateur survole un pack
When   le tooltip apparaît
Then   le nombre de modules inclus et la liste sont visibles

Given  l'utilisateur clique sur "Ajouter au contexte"
When   il confirme
Then   le pack est ajouté à sa configuration en cours avec tous ses modules
```

#### Validation INVEST
| Critère | OK | Commentaire |
|---|---|---|
| Independent | ✅ | |
| Negotiable | ✅ | |
| Valuable | ✅ | Simplifie l'adoption |
| Estimable | ✅ | 2 SP |
| Small | ✅ | |
| Testable | ✅ | |

**Estimation** : 2 SP | **Priorité** : Must Have

#### Definition of Ready
- [ ] API `/api/packs` documentée
- [ ] Relation pack → modules exposée par l'API

#### Definition of Done
- [ ] Composition pack visible dans la UI
- [ ] Action "Ajouter au contexte" persistée en state
- [ ] Tests d'intégration page Packs

---

### US-03 — Parcourir les blueprints disponibles

**En tant que** développeur / AI Engineer,  
**Je veux** parcourir les blueprints disponibles avec leur description, leurs étapes et leurs commandes,  
**Afin de** sélectionner un scénario prêt à l'emploi correspondant à mon cas d'usage.

#### Critères d'acceptation

```gherkin
Given  l'utilisateur ouvre la page "Blueprints"
When   la page est chargée
Then   chaque blueprint affiche : nom, description, nombre d'étapes, commandes disponibles

Given  l'utilisateur sélectionne un blueprint
When   il clique sur "Voir les étapes"
Then   le détail séquentiel des étapes s'affiche dans un panneau latéral

Given  l'utilisateur clique sur "Utiliser ce blueprint"
When   il confirme la sélection
Then   le blueprint est ajouté à sa session de composition active
```

#### Validation INVEST
| Critère | OK | Commentaire |
|---|---|---|
| Independent | ✅ | |
| Negotiable | ✅ | Détail des étapes peut être simplifié |
| Valuable | ✅ | Guidance = core value proposition |
| Estimable | ✅ | 3 SP |
| Small | ✅ | |
| Testable | ✅ | |

**Estimation** : 3 SP | **Priorité** : Must Have

#### Definition of Ready
- [ ] API `/api/blueprints` avec steps et commandes
- [ ] Au moins 3 blueprints disponibles en données de test

#### Definition of Done
- [ ] Détail étapes rendu en accordéon
- [ ] Commandes copiables (bouton copy)
- [ ] Tests composant BlueprintCard

---

## Épic : Composer un contexte de prompt

---

### US-04 — Composer un contexte en sélectionnant modules/packs/blueprints

**En tant que** développeur / AI Engineer,  
**Je veux** sélectionner et combiner des modules, des packs et des blueprints dans une interface de composition,  
**Afin de** construire un contexte de prompt personnalisé sans manipuler de fichiers JSON à la main.

#### Critères d'acceptation

```gherkin
Given  l'utilisateur est sur la page "Composer"
When   il ajoute des modules, packs ou blueprints depuis le catalogue
Then   un récapitulatif à droite liste les éléments sélectionnés en temps réel

Given  l'utilisateur a sélectionné au moins un blueprint
When   il clique sur un élément de la liste de composition
Then   il peut le retirer ou le réordonner (drag-and-drop)

Given  l'utilisateur tente d'ajouter un second blueprint incompatible
When   une incompatibilité est détectée
Then   une alerte lui indique la contrainte et lui propose des alternatives

Given  l'utilisateur a finalisé sa sélection
When   il clique sur "Compiler le contexte"
Then   la composition est envoyée à l'API et le résultat est retourné
```

#### Validation INVEST
| Critère | OK | Commentaire |
|---|---|---|
| Independent | ⚠️ | Dépend de US-01/02/03 (catalogue) |
| Negotiable | ✅ | Drag-and-drop négociable en v1 |
| Valuable | ✅ | Fonctionnalité centrale |
| Estimable | ✅ | 5 SP |
| Small | ⚠️ | Peut être splitté en US-04a/04b |
| Testable | ✅ | |

**Estimation** : 5 SP | **Priorité** : Must Have

#### Definition of Ready
- [ ] US-01, US-02, US-03 complétées
- [ ] API `/api/compile` spécifiée (contrat entrée/sortie)
- [ ] Règles d'incompatibilité documentées

#### Definition of Done
- [ ] Composition persistée en session (localStorage)
- [ ] Compilation retourne un prompt.context.md lisible
- [ ] Gestion des erreurs API affichée en UI

---

### US-05 — Prévisualiser et copier le prompt compilé

**En tant que** développeur / AI Engineer,  
**Je veux** voir le texte du prompt context compilé avec coloration syntaxique et pouvoir le copier en un clic,  
**Afin de** l'utiliser immédiatement dans mon outil AI (VS Code Copilot, ChatGPT, etc.).

#### Critères d'acceptation

```gherkin
Given  la compilation est terminée avec succès
When   la page "Prévisualisation" s'affiche
Then   le contenu Markdown du prompt.context.md est rendu en syntaxe colorée

Given  l'utilisateur clique sur "Copier le prompt"
When   la copie est effectuée
Then   le contenu brut (non rendu) est dans le presse-papier et une notification "Copié !" apparaît 3 s

Given  l'utilisateur clique sur "Télécharger"
When   il confirme
Then   un fichier prompt.context.md est téléchargé localement
```

**Estimation** : 2 SP | **Priorité** : Must Have

#### Definition of Ready
- [ ] US-04 complétée
- [ ] Composant de rendu Markdown choisi (react-markdown ou équivalent)

#### Definition of Done
- [ ] Rendu Markdown fidèle au template Scriban
- [ ] Clipboard API sécurisée (HTTPS ou localhost)
- [ ] Tests snapshot du composant PreviewPage

---

### US-06 — Consulter l'index des artefacts produits

**En tant que** développeur / AI Engineer,  
**Je veux** consulter l'index des artefacts produits (artifacts.index.json) après une compilation,  
**Afin de** comprendre quels fichiers ont été générés et par quel module.

#### Critères d'acceptation

```gherkin
Given  une compilation réussie a produit un artifacts.index.json
When   l'utilisateur ouvre l'onglet "Artefacts"
Then   chaque artefact est listé avec : filename, description, mimeType, size, generatedBy

Given  l'utilisateur clique sur un artefact
When   le panneau s'ouvre
Then   le contenu brut de l'artefact est affiché si le mimeType le permet
```

**Estimation** : 2 SP | **Priorité** : Should Have

---

## Récapitulatif du backlog initial

| ID | User Story | SP | Priorité |
|---|---|---|---|
| US-01 | Parcourir les modules | 3 | Must Have |
| US-02 | Parcourir les packs | 2 | Must Have |
| US-03 | Parcourir les blueprints | 3 | Must Have |
| US-04 | Composer un contexte | 5 | Must Have |
| US-05 | Prévisualiser le prompt compilé | 2 | Must Have |
| US-06 | Consulter l'index artefacts | 2 | Should Have |
| **Total Sprint 1** | | **17 SP** | |

---

*Généré via le blueprint `agile.userstory` — Context-Compiler Prompting Interface*
