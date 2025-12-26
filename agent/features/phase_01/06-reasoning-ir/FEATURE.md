# Feature: Reasoning IR (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26

Reasoning IR is the canonical intermediate representation (IR) of all compiled information.
All views, templates, graphs, and reports are derived from it.

---

## 1. Why this feature exists
Without IR:
- each consumer must parse raw documents differently
- views become coupled to file formats
- auditing is impossible

IR is the “compiler middle-end”.

---

## 2. Canonical types (Authoritative)

### Fragment
- `EvidenceKey` (EK)
- `EvidenceRevision` (ER)
- `SourceRef` (path + locator)
- `Content` (string, normalized)
- `Tags` (optional key/value)

### SourceRef
- `Path` (workspace-relative normalized path)
- `Locator` (stable anchor within the file; MUST be deterministic)

---

## 3. Invariants

### MUST
- Every fragment has EK, ER, SourceRef, Content (non-empty unless explicitly redacted placeholder).
- No duplicate EK in a single build.
- Fragment ordering is stable:
  - (Source.Path, Source.Locator, EvidenceKey)
- Tags must not affect determinism (ordering independent of tag insertion order).

### MUST NOT
- Store raw binary blobs in IR.
- Embed executable instructions in IR metadata.
- Allow mutable fragments after assembly (treat IR as immutable once built).

---

## 4. Examples

### Example fragment (JSON-ish)
```json
{
  "key": "E-1a2b3c4d5e6f",
  "rev": "R-9f8e7d6c5b4a",
  "source": { "path": "Reporting/kpi.xlsx", "locator": "extract:kpi_fr/sheet:KPI/table:tbl_kpi/chunk:1" },
  "content": "{...tabular json...}",
  "tags": { "shape":"tabular", "extractId":"kpi_fr" }
}
```
