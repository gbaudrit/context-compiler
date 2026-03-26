# Feature: Transcoding (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Document Pipeline stage `TranscodeFragment`

Transcoding converts `DataEnvelope`(s) into Reasoning IR fragments with stable content normalization.

It is responsible for:
- producing the final text payload per fragment
- applying fragmenting modes
- attaching tags for later views/templates/guards

---

## 1. Why this feature exists
Data shapes need different renderings to become usable by LLMs.
Transcoding provides consistent, controlled conversions:
- hierarchical → compact JSON
- tabular → canonical table JSON/MD
- linear → normalized text blocks

---

## 2. Problem it solves
- Prevents templates from needing to understand data formats.
- Enables stable EvidenceRevision hashing by normalizing content.
- Ensures fragment size control.

---

## 3. Alternatives rejected
- “Just dump raw text”: rejected; loses structure and increases hallucination risk.
- “LLM summarizes”: rejected; pre-LLM requirement.

---

## 4. Scope

### Does
- Select a transcoder plugin for a given envelope shape.
- Apply fragmenting.
- Produce fragments with:
  - SourceRef (path + locator with fragment suffix)
  - Content (normalized)
  - Tags

### Does NOT
- Apply global framing.
- Perform security policy decisions (guards do).
- Modify the underlying envelope.

---

## 5. Canonical outputs (examples)

### Tabular canonical JSON
- stable column order
- stable row order
- numeric values serialized culture-invariant

### Hierarchical canonical JSON
- stable property ordering (sorted keys) if represented as maps
- or stable traversal order if represented as tree nodes

### Linear text
- trim trailing whitespace per line
- normalize newlines to \n

---

## 6. MUST / MUST NOT

### MUST
- Choose transcoder deterministically.
- Normalize output deterministically.
- Preserve locator lineage.
- Attach shape tags.

### MUST NOT
- Inject framing instructions.
- Include timestamps or environment-specific metadata in content.

---

## 7. Failure modes
- No transcoder found: deterministic error.
- Serialization failure: deterministic error, include plugin id and shape.

---

## 8. Required tests
See `tests.md`.
