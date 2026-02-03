# Reasoning IR (Agent-Ultra)

## 1) Canonical types

### Fragment
- `EvidenceKey Key`
- `EvidenceRevision Revision`
- `string Content`
- `SourceRef Source` (path + locator)
- `Dictionary<string,string>? Tags`

### SourceRef
- `Path` (absolute or workspace-relative, but consistent)
- `Locator` (anchor to sub-part)

## 2) Invariants
- Each fragment must have a valid EK and ER
- `Content` must be non-empty after normalization (unless explicit placeholder)
- No duplicate EK in a compilation
- Ordering is stable: by source path then locator then EK

## 3) Rationale
IR decouples ingestion from projection:
- many file types → same IR
- many views → same IR
- graphs/reports → derived from IR

## 4) Extension points
Future:
- scores (salience, recency)
- relationships (edges between fragments)
- sensitivity levels
