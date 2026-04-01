# Global Instructions
## Commands
{{~ for item in commands ~}}
  {{~ if item.key != null && item.key != "" ~}}
### {{ item.key }}
  {{~ end ~}}
  {{~ for c in item.value ~}}
- {{ c.name }}: {{ c.description }}
  {{~ end ~}}
{{~ end ~}}

## Objectives
{{~ for m in objectives ~}}
- {{ m.name }}: {{ m.description }}
{{~ end ~}}

## Project
- Name: {{ name }}
- Summary: {{ summary }}

### Audiences
{{~ for a in audiences ~}}
- {{ a.name }}: {{ a.description }}
{{~ end ~}}

### Inputs
{{~ for i in artifacts ~}}
  {{~ if i.description != null && i.description != "" ~}}
- {{ i.filename }}: {{ i.description }}
  {{~ end ~}}
{{~ end ~}}

### Assumptions
{{~ for a in assumptions ~}}
- {{ a.name }}: {{ a.description }}
{{~ end ~}}

### MUST
{{~ for m in must ~}}
- {{ m.text }}
{{~ end ~}}

### MUST NOT
{{~ for m in mustNot ~}}
- {{ m.text }}
{{~ end ~}}

### Glossary
- **Evidence Key (EK)**: A unique identifier for a specific piece of evidence (different between two identical document, related to filepath).
- **Evidence Revision (ER)**: A version identifier for the evidence, indicating changes or updates (different between two identical document, related to filepath).
- **Relative Evidence Key (REK)**: A unique identifier for evidence that is related to another piece of evidence (related to position in document, not related to filepath, can be use for compare to document).
- **Relative Evidence Revision (RER)**: A version identifier for the related evidence, indicating changes or updates (related to position in document, not related to filepath, can be use for compare to document).
{{~ for g in glossary ~}}
- {{ g.term }}: {{ g.definition }}
{{~ end ~}}

# Personas (roles)
{{~ for p in personas ~}}
## {{ p.title }} ({{ p.id }})

- Role: {{ p.role }}

{{~ if p.Metadata && p.Metadata.size > 0 ~}}
### Metadata
{{~ for kv in p.Metadata ~}}
- **{{ kv.key }}**: {{ kv.value }}
{{~ end ~}}
{{~ end ~}}

{{~ if p.must && p.must.size > 0 ~}}
### Must
{{~ for m in p.must ~}}
- {{ m.text }}
{{~ end ~}}
{{~ end ~}}

{{~ if p.mustNot && p.mustNot.size > 0 ~}}
### Must Not
{{~ for mn in p.mustNot ~}}
- {{ mn.text }}
{{~ end ~}}
{{~ end ~}}

{{~ end ~}}

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

{{~ if blueprint.mustNotConstraints && blueprint.mustNotConstraints.size > 0 ~}}
### MUST NOT
{{~ for mn in blueprint.mustNotConstraints ~}}
- {{ mn.id }}: {{ mn.text }}
{{~ end ~}}
{{~ end ~}}

{{~ if blueprint.assumptions && blueprint.assumptions.size > 0 ~}}
### Assumptions
{{~ for a in blueprint.assumptions ~}}
- {{ a.name }}: {{ a.description }}
{{~ end ~}}
{{~ end ~}}

{{~ if blueprint.glossary && blueprint.glossary.size > 0 ~}}
### Glossary
{{~ for g in blueprint.glossary ~}}
- **{{ g.term }}**: {{ g.definition }}
{{~ end ~}}
{{~ end ~}}

{{~ if blueprint.commands && blueprint.commands.size > 0 ~}}
### Commands
{{~ for c in blueprint.commands ~}}
- {{ c.name }}: {{ c.description }}
{{~ end ~}}
{{~ end ~}}

{{~ if blueprint.steps && blueprint.steps.size > 0 ~}}
### Steps
{{~ for step in blueprint.steps ~}}

#### Étape {{ for.index + 1 }} : {{ step.content }}

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
{{~ end ~}}
{{~ end ~}}
