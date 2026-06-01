# Feature: Evidence Graph & Coverage (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Global Pipeline module kind `GraphExporter`, consumer stage (coverage)

This feature provides a deterministic graph representation connecting:
- evidence fragments (EK nodes)
- derived view sections
- prompt sections
- (optional) LLM usage references captured externally

Primary goals:
- visualize provenance
- enable coverage reporting (what evidence was used)
- support future tooling integrations

---

## 1. Why this feature exists
For serious context engineering:
- you need to know what the model used
- you need to audit omissions
- you need to debug reasoning

A graph provides structure beyond linear markdown.

---

## 2. Problem it solves
- Deterministic representation of relationships:
  - fragment belongs to file
  - fragment appears in view
  - view appears in prompt
- Enables “coverage” metrics if the consumer/agent returns used EK ids.

---

## 3. Stable ID strategy (authoritative)

Nodes use stable ids:
- Fragment node id = `EK` (already stable)
- Source node id = `S-<hash(path)>`
- View node id = `V-<viewId>`
- Prompt section node id = `P-<sectionName>`

Edges are stable tuples:
- `(fromId, toId, type)` sorted deterministically

No random GUIDs.

---

## 4. Graph artifact format (baseline)

Emit `reasoning.graph.json` with:

```json
{
  "nodes":[
    {"id":"V-default","type":"view","label":"default"},
    {"id":"E-1a2b...","type":"evidence","label":"Reporting/kpi.xlsx#extract:kpi_fr/..."}
  ],
  "edges":[
    {"from":"E-1a2b...","to":"V-default","type":"included_in"}
  ]
}
```

Ordering:
- nodes sorted by `(type, id)`
- edges sorted by `(type, from, to)`

---

## 5. Coverage reporting (baseline)

If an external agent returns a list of used EKs:
- compute coverage = usedEK / totalEK
- emit `coverage.report.json` + `coverage.report.md`

This requires the agent to preserve EK ids (validated requirement).

---

## 6. MUST / MUST NOT

### MUST
- Use stable ids only.
- Preserve evidence traceability.
- Produce deterministic ordering.

### MUST NOT
- Use timestamps in graph files.
- Store raw sensitive content in graph nodes (only labels/locators).
