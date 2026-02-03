# Evidence System (Agent-Ultra)

## 1) Goals
- Provide stable, citeable IDs
- Enable auditing and diffs
- Allow coverage metrics

## 2) EvidenceKey (EK)
Format: `E-<12 hex>` (example)
Derivation (Phase 1 baseline):
- EK = sha256(path + "|" + locator) => first 12 hex

Target (Phase 2+ improved stability):
- EK based on locator anchors that survive moves:
  - explicit anchors (heading IDs, named ranges, tables)
  - structural path (sheet/table/row/column)
  - fallback to path+locator

## 3) EvidenceRevision (ER)
Format: `R-<12 hex>`
Derivation:
- ER = sha256(path + "|" + locator + "|" + normalizedContent) => first 12 hex

## 4) Evidence index
`evidence.index.json` contains for each fragment:
- evidenceKey
- evidenceRevision
- source.path
- source.locator
- tags
- (option future) scores/sensitivity/trust

## 5) Agent consumption contract
- Evidence IDs must be preserved verbatim
- If LLM output includes citations, they must reference EK
- No invented EKs allowed
