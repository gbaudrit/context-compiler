# Feature: Context Views (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Global Pipeline stage 2 (after IR assembly)

A **Context View** is a deterministic projection of the Reasoning IR, designed to present the same evidence
from different “angles” (perspectives) without mutating the underlying IR.

Views are intended to:
- highlight subsets or reorganizations of evidence
- apply stable scoring/ordering rules
- support multiple simultaneous “dimensions” of context

Views are NOT “prompt contexts” themselves; the final prompt is assembled later by templates.

---

## 1. Why this feature exists
A single linear dump of all fragments is suboptimal:
- the LLM’s attention is limited
- different tasks need different evidence emphasis
- ordering matters for model behavior

Views provide **structured emphasis** while preserving traceability.

---

## 2. Problem it solves
- Produce multiple projections (e.g., summary-first, risk-first, spec-first)
- Provide stable ordering and selection within each projection
- Allow IDE/agents to choose or display a specific view artifact

---

## 3. Alternatives rejected
- “Only one view”: rejected; it forces one-size-fits-all.
- “LLM chooses view”: rejected (pre-LLM compiler).
- “Views mutate IR”: rejected; breaks audit and determinism.

---

## 4. Scope

### Does
- Read IR fragments and associated findings/metadata.
- Apply deterministic scoring/ordering/selection rules.
- Emit one or more view artifacts (`view.<id>.md` and/or `.json`).

### Does NOT
- Modify fragment content or evidence IDs.
- Perform persona/framing overlays.
- Apply compression budgets unless explicitly part of a view definition (future).

---

## 5. View specification (authoritative)

A view is defined by:
- `ViewId` (string)
- `Title` (string)
- `Selector` (filters)
- `Ordering` (stable sort keys)
- `Formatter` (markdown/json)

Conceptual output:
- `ViewDocument`:
  - `ViewId`
  - `Sections[]` each containing ordered fragment references (EK/ER + optional snippet)

Views should reference fragments by EK (and ER optionally) rather than duplicating raw content in JSON.
Markdown views may embed content; if so, citations must remain stable.

---

## 6. Deterministic scoring & ordering (authoritative baseline)

Because you want “multiple dimensions” rather than “libraries”, define:
- **View Lenses** (aka “dimensions”): named scoring + ordering rule sets.

Examples:
- `lens:recency` (stable timestamp ordering if timestamps exist in content; otherwise fallback)
- `lens:safety` (guard severity tags first)
- `lens:relevance` (config-defined keyword weights; deterministic)

Baseline rule:
- If a scoring function cannot be computed deterministically from IR, it MUST NOT exist in Phase 3.

Ordering keys must be explicit:
- `(score desc, source.path, source.locator, EK)`

---

## 7. MUST / MUST NOT

### MUST
- Treat IR as immutable input.
- Preserve evidence IDs in view output.
- Produce stable, reproducible ordering.
- Emit view artifacts with deterministic filenames.

### MUST NOT
- Recompute evidence IDs.
- Include non-deterministic derived data (timestamps, random ranks).
- Hide fragments without explicit selector rules.

---

## 8. Examples

### Example view IDs
- `default`
- `spec`
- `risk`
- `changes`

### Example markdown view header
```md
# View: risk
Purpose: prioritize security-relevant evidence.
Ordering: guard severity desc, then source order.

## Evidence
- [E-1a2b3c...] ...content...
```

---

## 9. Required tests
See `tests.md`.
