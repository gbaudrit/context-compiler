# Feature: Determinism (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26

Determinism is the defining property that makes Context Compiler a “compiler” rather than an “assistant tool”.

---

## 1. Why this feature exists

If outputs are not reproducible:
- diffs are meaningless
- evidence cannot be trusted
- guard reports cannot be audited
- IDE integrations become flaky
- tests become unreliable

---

## 2. Problem it solves

Prevents nondeterminism caused by:
- filesystem enumeration order
- unordered collections (Dictionary/HashSet)
- concurrency scheduling
- locale/timezone differences
- floating-point serialization differences

---

## 3. Alternatives rejected

### A) “Close enough” determinism
Rejected: subtle drifts destroy trust.

### B) “Determinism only in CI”
Rejected: developers and agents need determinism locally too.

---

## 4. Scope

Applies to:
- all pipelines
- all plugins
- all outputs
- all tests

---

## 5. Deterministic rules (mandatory)

### 5.1 Ordering rules
- Any time you iterate over:
  - files
  - directories
  - dictionary keys
  - plugin lists
  - fragments
  - view ids
  you must apply an explicit stable sort.

**Sorting requirement**
- Use ordinal string comparison for IDs and paths.
- Prefer workspace-relative normalized paths for ordering.

### 5.2 Hashing rules
- All hashing must be defined explicitly:
  - algorithm: SHA-256
  - normalization: UTF-8, \n line endings, trimmed trailing whitespace where specified
- Evidence IDs must be derived from stable inputs (see Evidence feature).

### 5.3 Serialization rules
For JSON artifacts:
- Use consistent serializer settings:
  - UTF-8
  - consistent indentation (or documented non-indented)
  - stable property naming
- Do not include timestamps in artifact content.

For Markdown artifacts:
- stable heading ordering
- stable bullet ordering
- consistent newline endings

### 5.4 Concurrency rules
- Concurrency is allowed internally *only if* outputs remain deterministic.
- If concurrency introduces nondeterministic ordering, the final merge step must sort results.

---

## 6. MUST / MUST NOT

### MUST
- Normalize all paths before comparison.
- Sort plugin lists by (Kind, Priority, Id).
- Sort fragments by (Source.Path, Source.Locator, EvidenceKey).
- Produce stable diff outputs.

### MUST NOT
- Depend on `Directory.EnumerateFiles` order.
- Rely on `Dictionary` enumeration order.
- Serialize with non-deterministic property ordering without enforcing stable shaping.

---

## 7. Failure modes

If determinism tests fail:
- treat as a build-breaking regression
- block release

---

## 8. Examples

### Example: sorting files
Input files must be enumerated and sorted:
- by normalized relative path (ordinal)

### Example: stable plugin order
Plugins loaded from assemblies or NuGet must be sorted before execution:
- Kind → Priority (asc) → Id (ordinal)
