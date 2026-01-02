# Feature: Performance Constraints (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Goal:** Ensure the compiler is fast, predictable, and bounded in memory.

---

## 1. Why this feature exists
Context compilation may run on large repos. It must:
- avoid O(N^2) behaviors
- avoid loading the world into memory unnecessarily
- remain predictable for IDE use

---

## 2. Constraints (authoritative baseline)
- One-pass file reading whenever possible.
- Excel workbook read once per file.
- Bounded memory: streaming where possible, chunking for large data.
- No background processes.

---

## 3. Deterministic performance
Performance optimizations must not introduce nondeterministic outputs.
Parallelization is allowed only if merge is sorted deterministically.

---

## 4. Metrics
Emit basic metrics in `context.health.json`:
- files processed
- bytes read
- fragments produced
- time per stage (optional, but if included must not affect determinism of other outputs)

Note: timing metrics should not be used for golden tests.

---

## 5. MUST / MUST NOT

### MUST
- Avoid reading files more than once.
- Provide sensible maximums (max file size, max rows).
- Fail gracefully with clear error on resource limits.

### MUST NOT
- Use unbounded recursion on hierarchical data.
- Produce artifacts whose content depends on timing.
