# Template Scriban - Structure du Prompt

## Vue d'ensemble

Le template `prompt.context.md` génère un prompt structuré en Markdown à partir des données du contexte compilé.

## Sections du template

### 1. Global Instructions

#### Commands
Liste des commandes disponibles, groupées par persona (si applicable).

```scriban
{{~ for item in commands ~}}
  {{~ if item.key != null && item.key != "" ~}}
### {{ item.key }}
  {{~ end ~}}
  {{~ for c in item.value ~}}
- {{ c.name }}: {{ c.description }}
  {{~ end ~}}
{{~ end ~}}
```

#### Objectives
Liste des objectifs du projet.

```scriban
{{~ for m in objectives ~}}
- {{ m.name }}: {{ m.description }}
{{~ end ~}}
```

### 2. Project

Informations générales sur le projet :
- Name
- Summary
- Audiences (public cible)
- Inputs (artéfacts d'entrée)

### 3. Assumptions

Hypothèses sur lesquelles le projet repose.

```scriban
{{~ for a in assumptions ~}}
- {{ a.name }}: {{ a.description }}
{{~ end ~}}
```

### 4. Constraints (MUST / MUST NOT)

#### MUST
Contraintes obligatoires à respecter.

```scriban
{{~ for m in must ~}}
- {{ m.text }}
{{~ end ~}}
```

#### MUST NOT
Contraintes à éviter.

```scriban
{{~ for m in mustNot ~}}
- {{ m.text }}
{{~ end ~}}
```

### 5. Glossary

Dictionnaire de termes avec leurs définitions.

```scriban
{{~ for g in glossary ~}}
- {{ g.term }}: {{ g.definition }}
{{~ end ~}}
```

### 6. Personas

Liste des personas (rôles) avec leurs spécificités.

Chaque persona contient :
- Title et ID
- Role
- Metadata (optionnel)
- Must constraints (optionnel)
- Must Not constraints (optionnel)

```scriban
{{~ for p in personas ~}}
## {{ p.title }} ({{ p.id }})

- Role: {{ p.role }}

{{~ if p.Metadata && p.Metadata.size > 0 ~}}
### Metadata
{{~ for kv in p.Metadata ~}}
- **{{ kv.key }}**: {{ kv.value }}
{{~ end ~}}
{{~ end ~}}
{{~ end ~}}
```

### 7. Blueprints (Nouveau !)

Section ajoutée pour afficher les blueprints activés.

Chaque blueprint contient :
- Name et ID
- Description
- Objectives (optionnel)
- MUST constraints (optionnel)
- MUST NOT constraints (optionnel)
- Assumptions (optionnel)
- Glossary (optionnel)
- Commands (optionnel)
- Steps (optionnel)

#### Steps

Les steps sont des étapes séquentielles avec leurs propres contraintes :

```scriban
{{~ if blueprint.steps && blueprint.steps.size > 0 ~}}
### Steps
{{~ for step in blueprint.steps ~}}

{{ step.content }}

{{~ if step.mustConstraints && step.mustConstraints.size > 0 ~}}
**MUST:**
{{~ for m in step.mustConstraints ~}}
- {{ m.id }}: {{ m.text }}
{{~ end ~}}
{{~ end ~}}

{{~ if step.mustNotConstraints && step.mustNotConstraints.size > 0 ~}}
**MUST NOT:**
{{~ for mn in step.mustNotConstraints ~}}
- {{ mn.id }}: {{ mn.text }}
{{~ end ~}}
{{~ end ~}}

{{~ end ~}}
{{~ end ~}}
```

```scriban
{{~ if blueprints && blueprints.size > 0 ~}}
# Blueprints

{{~ for blueprint in blueprints ~}}
## {{ blueprint.name }} ({{ blueprint.id }})

{{ blueprint.description }}

{{~ if blueprint.objectives && blueprint.objectives.size > 0 ~}}
### Objectives
{{~ for obj in blueprint.objectives ~}}
- {{ obj.name }}: {{ obj.description }}
{{~ end ~}}
{{~ end ~}}

{{~ if blueprint.mustConstraints && blueprint.mustConstraints.size > 0 ~}}
### MUST
{{~ for m in blueprint.mustConstraints ~}}
- {{ m.id }}: {{ m.text }}
{{~ end ~}}
{{~ end ~}}

... (autres sections optionnelles)

{{~ end ~}}
{{~ end ~}}
```

## Modèle de données

Le template reçoit un objet avec la structure suivante :

```javascript
{
    name: string,
    summary: string,
    domain: string,
    audiences: [ { name, description } ],
    objectives: [ { name, description } ],
    assumptions: [ { name, description } ],
    personas: [ { id, title, role, framingMarkdown, metadata, must, mustNot } ],
    must: [ { id, text } ],
    mustNot: [ { id, text } ],
    glossary: [ { term, definition } ],
    commands: { persona_id: [ { name, description } ] },
    artifacts: [ { filename, description } ],
    blueprints: [ { 
        id, 
        name, 
        description, 
        mustConstraints, 
        mustNotConstraints, 
        objectives, 
        assumptions, 
        glossary, 
        commands 
    } ]
}
```

## Extensions de modèle

Les extensions suivantes sont disponibles dans `ModelsExtensions.cs` :

- `ToRenderable(IPrompt)` : Convertit le prompt en modèle de template
- `ToTemplateModel(IPersona)` : Convertit un persona
- `ToTemplateModel(IBlueprint)` : Convertit un blueprint
- `ToTemplateModel(IBlueprintStep)` : Convertit une étape de blueprint
- `ToTemplateModel(IObjective)` : Convertit un objectif
- `ToTemplateModel(IAssumption)` : Convertit une hypothèse
- `ToTemplateModel(IMustConstraint)` : Convertit une contrainte MUST
- `ToTemplateModel(IMustNotConstraint)` : Convertit une contrainte MUST NOT
- `ToTemplateModel(IGlossaryTerm)` : Convertit un terme du glossaire
- `ToTemplateModel(ICommand)` : Convertit une commande
- `ToTemplateModel(IOutputArtifact)` : Convertit un artéfact de sortie

## Utilisation

Le template est automatiquement utilisé par le module `ScribanPromptTemplateModule` pour générer le prompt final en Markdown.

Les blueprints sont automatiquement inclus dans le prompt généré s'ils sont présents dans le prompt (via `BlueprintsPromptComposerModule`).
