# Context Compiler — Compiled Context

# Global Instructions
## Project
- Name: {{ name }}
- Summary: {{ summary }}

### Audiences
{{~ for a in audiences ~}}
- {{ a.name }}: {{ a.description }}
{{~ end ~}}

### Objectives
{{~ for m in objectives ~}}
- {{ m.name }}: {{ m.description }}
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
