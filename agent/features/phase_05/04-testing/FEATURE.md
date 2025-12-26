# Feature: Testing Strategy (MSTest + Moq + FluentAssertions) (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Goal:** Enforce determinism, safety, and contract stability through tests.

---

## 1. Why this feature exists
This system is a compiler-like tool: regressions must be caught early.
Testing is required to preserve:
- deterministic outputs
- correct pipeline ordering
- guard enforcement
- stable artifacts

---

## 2. Stack (validated)
- MSTest for test runner
- Moq for mocking
- FluentAssertions for assertions

---

## 3. Test layers (authoritative)

### Unit tests
- pure logic: ordering, hashing, parsing, transforms
- plugin selection logic
- guard action semantics

### Integration tests
- compile fixture folder end-to-end
- golden artifact comparisons
- cross-run determinism

### Contract tests
- output contracts (Phase 4)
- schema validation
- exit codes

---

## 4. Golden tests (mandatory baseline)
Use fixture folders under `tests/fixtures/` and compare:
- directory tree
- file bytes

Golden tests must be platform-stable:
- normalize line endings where contract requires
- do not include timestamps in artifacts

---

## 5. MUST / MUST NOT

### MUST
- Run determinism tests in CI.
- Treat determinism regression as build failure.
- Include tests for Critical+Block behavior.

### MUST NOT
- Use flaky tests depending on machine locale/time.
