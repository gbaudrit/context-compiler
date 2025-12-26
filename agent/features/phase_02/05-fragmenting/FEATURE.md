# Feature: Fragmenting (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Document Pipeline stage 7/Transcoding output shaping

Fragmenting controls the **granularity** of emitted IR fragments to:
- fit token budgets
- improve retrieval and citation
- enable stable coverage tracking

Fragmenting rules may be specified by:
- DataReader output hints (e.g., Excel extract fragmenting)
- Global defaults (future config)
- Transcoder-specific defaults

---

## 1. Why this feature exists
Without fragmentation:
- large documents create huge single fragments (token blow-up)
- citations are imprecise
- coverage graphs become useless

With too fine fragmentation:
- overhead and prompt size increases
- context loses coherence

Fragmenting is the controlled middle ground.

---

## 2. Modes (authoritative)
- `single`: one fragment for the entire envelope/part
- `chunks`: split by max rows/lines
- `groupBy`: split by key(s) (tabular/hierarchical)
- `rowWise`: one fragment per row/item (use sparingly)

---

## 3. Deterministic rules
- Chunk boundaries are deterministic and based on stable ordering.
- Chunk IDs are 1..N in order.
- Group keys are stringified deterministically:
  - keys sorted
  - values normalized

---

## 4. Locator additions
Fragmenting appends to the DataReader locator prefix:
- `/chunk:<n>`
- `/group:<k>=<v>`
- `/row:<n>`

---

## 5. MUST / MUST NOT

### MUST
- Never lose traceability (all fragments inherit base locator prefix).
- Produce stable fragment order.
- Avoid non-deterministic grouping.

### MUST NOT
- Use random chunk sizes.
- Group by non-stable computed values (timestamps).

---

## 6. Examples

### Excel chunks
Base: `extract:kpi_fr/sheet:KPI/table:tbl_kpi`
Fragments:
- `.../chunk:1`
- `.../chunk:2`

### groupBy Region
- `.../group:Region=FR`
- `.../group:Region=EU`

---

## 7. Required tests
See `tests.md`.
