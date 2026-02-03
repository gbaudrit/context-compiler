# Feature: Documentation & MADR (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Goal:** Record decisions so agents and humans share the same source of truth.

---

## 1. Why this feature exists
In a highly modular system:
- decisions must be recorded
- drift must be prevented
- new contributors must not re-litigate architecture

MADR ensures decisions are explicit and versioned.

---

## 2. What must be recorded
- pipeline model decisions
- evidence id strategy
- determinism rules
- plugin boundaries
- security policy defaults
- output contracts

---

## 3. Format
- Use Markdown Architecture Decision Records:
  - `docs/adr/0001-...md`
- Each ADR includes:
  - context
  - decision
  - consequences
  - alternatives

---

## 4. MUST / MUST NOT

### MUST
- Add ADR when changing contracts or invariants.
- Keep ADRs immutable once accepted (append new ADRs).

### MUST NOT
- Change behavior without recording decision.
