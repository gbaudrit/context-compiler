# Feature: Engineering Modules (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Document Pipeline stage 5

Engineering Modules are ordered, deterministic transformations applied to DataEnvelopes
to improve structure, consistency, and usefulness before transcoding.

This is the “data shaping” layer: **not** extraction, **not** framing.

---

## 1. Why this feature exists
Raw parsed data is often inconsistent:
- mixed casing, whitespace noise
- duplicated sections
- inconsistent key naming
- mixed structures

Engineering Modules enable repeatable normalization without coupling to formats.

---

## 2. Problem it solves
- Produce cleaner, more uniform envelopes.
- Enable downstream transcoders to remain simple.
- Provide modular opt-in transformations per data shape.

---

## 3. Alternatives rejected
- “Do everything in DataReader”: rejected; extraction/parsing must stay separate.
- “Let the LLM clean it”: rejected; pre-LLM requirement.

---

## 4. Scope

### Does
- Take DataEnvelope (or each Composite part envelope).
- Produce a new DataEnvelope (immutable style).
- Add metadata tags (deterministic).

### Does NOT
- Read files.
- Select Excel parts (already done).
- Produce prompt text (transcoding does).
- Execute unsafe heuristics.

---

## 5. Execution model

- Modules are discovered as plugins.
- Ordered by `(priority asc, id ordinal)`.
- Applied sequentially.
- Each module must declare applicable shapes.

---

## 6. Example modules (validated)
- NormalizeWhitespaceModule (linear/tabular string cells)
- NormalizeKeysModule (key-based/hierarchical)
- DeduplicateLinesModule (linear)
- CanonicalizeDatesModule (tabular/hierarchical; culture-invariant)
- StripBoilerplateModule (linear; configured patterns)

Modules are optional; config may control activation in later phases.

---

## 7. MUST / MUST NOT

### MUST
- Be deterministic.
- Not lose information unless explicitly configured (redaction excepted).
- Preserve SourceRef locators (do not invalidate locators silently).

### MUST NOT
- Introduce new facts.
- Reorder records unless explicitly specified (and then must be deterministic).
- Depend on environment locale for formatting.

---

## 8. Failure modes
- If a module fails, compilation fails with exit code 1 (unless explicitly configured to skip modules).
- Failures must be reported with module id and stage context.

---

## 9. Artifacts
Optional: include module trace in `context.health.json` (modules executed, timings).

---

## 10. Required tests
See `tests.md`.
