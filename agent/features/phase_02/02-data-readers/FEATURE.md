# Feature: Data Readers (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Document Pipeline stage `DataRead`

DataReader plugins transform raw `FileContent` (bytes) into a typed `DataEnvelope`
(or a `CompositeDataEnvelope` for multi-part sources like Excel multi-extract).

---

## 1. Why this feature exists
Different file formats must be parsed in a consistent, testable way.
DataReaders:
- encapsulate parsing (MD/JSON/XML/Excel)
- produce canonical shapes (linear, key-based, hierarchical, tabular)
- enable downstream engineering and transcoding to be format-agnostic

---

## 2. Problem it solves
- Prevents transcoding from needing to understand every input format.
- Supports multi-part extraction (Excel) cleanly.
- Enables deterministic parsing settings and strict error handling.

---

## 3. Alternatives rejected
- **One parser in core**: rejected; format evolution would require core changes.
- **Parse directly into prompt text**: rejected; loses structure and traceability.

---

## 4. Scope

### Does
- Parse bytes into typed structures.
- Attach stable `SourceRef` locators for substructures when possible.
- Produce `DataEnvelope` with `Shape` and `Payload`.

### Does NOT
- Apply global framing (that’s global pipeline).
- Perform compression/token budgeting (later).
- Call LLMs.

---

## 5. Canonical data shapes (validated)
These are conceptual. The exact envelope types can be objects with a `Shape` string.

- **Linear**: free text, logs, plain markdown paragraphs.
- **KeyBased**: key-value maps (INI-like, JSON objects with shallow keys).
- **Hierarchical**: trees (JSON, XML).
- **Tabular**: rows/columns (CSV, Excel extracts).

---

## 6. Deterministic rules
- Parsing must use explicit settings (encoding fallback, culture-invariant numbers, etc.).
- Output ordering must be stable:
  - JSON properties sorted if converted to maps (or represented as ordered list)
  - Tabular columns and rows ordered deterministically
- Composite parts ordered by `PartId` (ordinal).

---

## 7. MUST / MUST NOT

### MUST
- Produce a DataEnvelope for every handled file (unless skipped by guards).
- Use `CompositeDataEnvelope` when a single file yields multiple extracts.
- Fail deterministically on malformed formats (unless configured to warn+skip).
- Preserve enough metadata to enable stable locators downstream.

### MUST NOT
- Perform business-specific transformations (engineering modules handle that).
- Emit prompt-ready text directly (transcoding handles prompt fragments).

---

## 8. Failure modes
- Unsupported file: pipeline selection error (no DataReader found).
- Malformed file: error or warn+skip based on guard/config policy.
- Partial parse: must be explicit; no silent drops.

---

## 9. Examples

### Example: Markdown file
Shape: `linear`  
Payload: list of paragraphs with locators.

### Example: JSON file
Shape: `hierarchical`  
Payload: JSON tree representation.

### Example: Excel file (multi-extract)
Shape: `composite`  
Parts: `kpi_fr`, `raw_products` etc.

---

## 10. Required tests
See `tests.md`.
