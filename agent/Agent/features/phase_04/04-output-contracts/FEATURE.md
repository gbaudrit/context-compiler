# Feature: Output Contracts (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Global Pipeline stage 5+ (template rendering and artifact emission)

Output Contracts define the expected structure and semantics of produced artifacts
so that IDE agents and tooling can consume them reliably.

This is not just file format; it is the semantic contract:
- naming
- required sections
- required metadata
- stability guarantees

---

## 1. Why this feature exists
Without output contracts:
- consumers break when files change
- agents cannot reliably parse prompt context
- diffing and CI checks are fragile

Output Contracts turn artifacts into an API.

---

## 2. Baseline contracts (authoritative)

### 2.1 Required artifacts
- `prompt.context.md`
- `evidence.index.json`
- `reasoning.graph.json`
- `security.report.md`
- `context.health.json`

### 2.2 prompt.context.md contract (baseline)
Must contain (in stable order):
1. Title/header
2. Global Context (if enabled)
3. Personas (if any)
4. Views (one or more)
5. Evidence rules (EK/ER)
6. Output contract (if present)

### 2.3 evidence.index.json contract
Must provide:
- list of fragments with EK/ER/source/locator/tags
- deterministic ordering

### 2.4 security.report.md contract
Must provide:
- summary counts
- findings sorted deterministically
- explicit actions taken

---

## 3. Versioning
Artifacts should include a semantic contract version in JSON files:
- `contractVersion: "1.0"`

Markdown may include a small metadata header (no timestamps).

---

## 4. MUST / MUST NOT

### MUST
- Maintain backward compatibility or bump contractVersion.
- Document breaking changes.
- Keep filenames stable.

### MUST NOT
- Change meaning of an existing field without version bump.
- Embed timestamps in contract-critical outputs.
