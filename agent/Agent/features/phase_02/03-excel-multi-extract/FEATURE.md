# Feature: Excel Multi-Extract (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Document Pipeline stages `DataRead` and `DataPart` (Excel DataReader)

Excel Multi-Extract is a declarative, deterministic mechanism to extract multiple
logical datasets from a single `.xlsx` and emit them as `CompositeDataEnvelope` parts.

This is a **pre-LLM optimization**: reduce noise at the source.

---

## 1. Why this feature exists
Excel workbooks often contain:
- multiple sheets
- raw tables, pivot exports, helper sheets
- mixed data not relevant to the intended prompt

Blindly ingesting entire workbooks:
- explodes token budgets
- increases security surface (secrets in hidden sheets)
- reduces reasoning quality due to noise

Multi-extract provides a *reproducible* extraction profile.

---

## 2. Problem it solves
- Extract exactly what matters (tables/ranges/columns).
- Produce multiple parts per file (e.g., KPI FR + KPI EU).
- Ensure stable locators include extractId for traceability.

---

## 3. Alternatives rejected
- **Extract everything and filter later**: rejected; wasteful and unsafe.
- **One extract per file**: rejected; real workbooks contain multiple datasets.
- **LLM-guided extraction**: rejected; pre-LLM requirement.

---

## 4. Scope

### Does
- Read workbook bytes once.
- Apply config-defined extracts:
  - select sheet
  - select table OR range (XOR)
  - select/exclude columns
  - rename columns
  - where filters
  - deterministic fragmenting directives
- Produce `CompositeDataEnvelope` with ordered `DataPart`s.

### Does NOT
- Perform semantic summarization.
- Perform prompt framing.
- Embed LLM reasoning.

---

## 5. Configuration (Authoritative)

Config lives under:
- `excel.defaults`
- `excel.files[]`
- `excel.files[].match` (glob)
- `excel.files[].extracts[]`

Each extract:
- `id` (required, unique per matched file)
- `sheet` (required)
- source selector (exactly one):
  - `table` OR `range`
- `select` / `exclude` (optional)
- `rename` (optional)
- `where` (optional)
- `fragmenting` (optional)

See `schema.json` and `examples.json`.

---

## 6. Extraction algorithm (deterministic)

For a matched file:
1. Load workbook via ClosedXML from bytes (single pass).
2. Resolve extracts list and sort by `id` ordinal.
3. For each extract:
   1) Resolve sheet by exact name.
   2) Resolve table or range.
   3) Determine header:
      - table: use table header
      - range: if `headerRow` specified, use it; else use first row of range
   4) Normalize column names if configured (`header.normalize`).
   5) Apply `select` / `exclude` deterministically (preserve declared order in `select`).
   6) Apply `rename` mapping (then ensure uniqueness).
   7) Parse rows up to `maxRows`.
   8) Apply `where` in declared order.
   9) Produce tabular payload with:
      - `columns` (ordered)
      - `rows` (ordered)
   10) Attach `locatorPrefix` with extractId.

4. Return CompositeDataEnvelope(parts).

---

## 7. Locator scheme (Authoritative)

Locators MUST include extractId:

- Table:
  `extract:<id>/sheet:<sheet>/table:<table>`
- Range:
  `extract:<id>/sheet:<sheet>/range:<A1>`

Row-level locators (for downstream chunking):
- `/row:<n>` where n is 1-based within extracted rows
Chunk/group locators are added during transcoding/fragmenting (later stage).

---

## 8. Tabular payload (canonical)

```json
{
  "extractId": "kpi_fr",
  "sheet": "KPI",
  "source": { "table": "tbl_kpi" },
  "columns": ["Date","Region","rev","mrg"],
  "rows": [
    {"Date":"2025-01-01","Region":"FR","rev":123,"mrg":45},
    ...
  ]
}
```

Ordering:
- columns: declared select order else natural header order
- rows: original sheet order filtered deterministically

---

## 9. MUST / MUST NOT

### MUST
- Read workbook bytes once per compilation.
- Produce deterministic outputs.
- Fail clearly if sheet/table/range missing (unless policy says skip+warn).
- Enforce maxRows and column uniqueness.
- Include extractId in locators.

### MUST NOT
- Leak hidden sheets by default if not selected.
- Infer extracts automatically when config exists.
- Generate dynamic IDs.

---

## 10. Failure modes
- Missing sheet: error or warn+skip extract (policy).
- Missing table/range: error or warn+skip.
- Column not found in select: error (explicit configuration is authoritative).
- Rename creates duplicates: error.

---

## 11. Artifacts
Optional debug artifacts (recommended):
- `excel.extraction.report.json` per file:
  - extracts applied
  - rows/cols selected
  - filters stats
  - warnings/errors

---

## 12. Required tests
See `tests.md`.
