# Feature: Artifacts (Output Contract Baseline) (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26

Artifacts are the compiler outputs consumed by humans and agents.

---

## 1. Why this feature exists

Artifacts ensure:
- reproducible consumption (IDE agents read stable files)
- auditable provenance (reports + evidence index)
- diffing across versions
- safe deletion / regeneration

---

## 2. Core artifacts (Phase 1 baseline)

The compiler must emit at least:

1. `prompt.context.md`
   - final assembled prompt context (views + framing layers)
2. `evidence.index.json`
   - EK/ER mapping and traceability
3. `reasoning.graph.json`
   - graph representation for later visualization/coverage
4. `security.report.md`
   - guard findings summary
5. `context.health.json`
   - health metrics summary

Optional (when applicable):
- `view.<id>.md`
- `persona.framing.md`
- `personas.active.json`
- `preflight.report.md`

---

## 3. Output folder rules

### MUST
- Output folder contains only generated files.
- Output folder is safe to delete.
- Input folder is never modified.
- Artifact naming is stable.

### MUST NOT
- Write artifacts next to inputs (unless output == input explicitly and strongly discouraged).
- Include timestamps in filenames by default.

---

## 4. Artifact determinism
- Stable ordering of sections in markdown
- Stable JSON serialization settings

---

## 5. Examples
A typical output tree:
```
out/
  prompt.context.md
  evidence.index.json
  reasoning.graph.json
  security.report.md
  context.health.json
  view.default.md
```
