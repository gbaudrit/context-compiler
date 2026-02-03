# Feature: Evidence System (EK/ER) (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26

Evidence IDs provide traceability and auditability.

- **EvidenceKey (EK)** identifies “what” a fragment is.
- **EvidenceRevision (ER)** identifies “which version” of the fragment content.

---

## 1. Why this feature exists
Without EK/ER:
- agents cannot cite sources reliably
- diffs across runs are meaningless
- coverage cannot be computed
- audits cannot be performed

---

## 2. EvidenceKey (EK)

### EK definition (Phase 1 baseline)
EK = SHA-256( normalizedPath + "|" + stableLocator ) → first 12 hex
Format: `E-<12hex>`

### Stability requirements
- Locator must be stable under formatting changes when possible.
- For Excel, locator includes extractId and structural coordinates.

---

## 3. EvidenceRevision (ER)

ER = SHA-256( normalizedPath + "|" + stableLocator + "|" + normalizedContent ) → first 12 hex  
Format: `R-<12hex>`

ER changes when:
- content changes after engineering/guards/transcoding normalization.

ER does NOT change when:
- file timestamps change
- unrelated file content changes

---

## 4. Evidence index artifact

`evidence.index.json` MUST include for each fragment:
- EK
- ER
- source path
- locator
- tags
- (optional) sensitivity flags

---

## 5. MUST / MUST NOT

### MUST
- Preserve EK across the pipeline; never regenerate with different inputs.
- Use stable normalization for content hashing.
- Emit evidence index deterministically.

### MUST NOT
- Use random IDs.
- Base EK on row numbers if a better stable locator exists (future improvements allowed, but baseline is defined).

---

## 6. Examples

Given:
- path: `Reporting/kpi.xlsx`
- locator: `extract:kpi_fr/sheet:KPI/table:tbl_kpi/chunk:1`

EK example: `E-1a2b3c4d5e6f`

---

## 7. Required tests
See `tests.md`.
