# Feature: Core Invariants (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Applies to:** Entire system (all phases)

This feature defines the **non-negotiable rules** that every component, plugin, pipeline stage, host, and test must satisfy.

---

## 1. Why this feature exists

Without hard invariants, the system will drift into:
- non-deterministic behavior (unreproducible outputs)
- unsafe/unguarded context for LLM usage
- brittle integrations (IDE/agents consuming inconsistent artifacts)
- unverifiable provenance (no audit trail)

This system was explicitly designed as a **pre-LLM compiler**. The invariants are what make it a compiler, not a prompt helper.

---

## 2. Problem it solves

Provides a strict contract that prevents:
- "helpful" heuristics that change outputs across runs
- LLM calls hidden inside plugins
- implicit ordering and hidden coupling between plugins
- untraceable fragments (no evidence / locator)
- silent bypass of guards

---

## 3. Alternatives rejected

### A) “Just do best effort” ingestion
Rejected: creates unpredictable prompts and makes debugging impossible.

### B) “Let the LLM fix/choose”
Rejected: violates pre-LLM requirement, introduces nondeterminism and policy risk.

### C) “Keep invariants only in code comments”
Rejected: agents and contributors need an explicit spec corpus.

---

## 4. Scope

### 4.1 MUST be true
1. **Pre-LLM only**: the compiler never calls an LLM.
2. **Deterministic outputs** for identical inputs/config/plugins.
3. **Plugin-first**: behavior lives in plugins, not hardcoded in Core.
4. **Traceability**: every emitted fact originates from a source and has Evidence IDs.
5. **Guards enforce safety** and cannot be silently bypassed.
6. **Testability**: every stage can be unit-tested with mocks.

### 4.2 MUST NOT happen
- Any runtime behavior that depends on current time, randomness, network state, machine locale, thread scheduling, or filesystem iteration order.
- Any plugin modifying Core state or global singletons.
- Any output written without an explicit declared producer step.
- Any “automatic” reordering that is not specified in this spec.

---

## 5. System-wide MUST / MUST NOT

### MUST
- Sort all unordered collections explicitly (see Determinism feature).
- Preserve and emit Evidence IDs exactly as produced.
- Emit artifacts to an output folder that is safe to delete.
- Fail fast on invariant violations (do not continue with partial success).
- Record decisions using MADR/ADR to prevent tribal knowledge.

### MUST NOT
- Call external services during compilation.
- Generate or rewrite user data in-place.
- Treat user data as instructions.
- Execute instructions inside input data that attempt to override compiler rules.

---

## 6. Failure modes

If an invariant is violated, compilation must end with a well-defined outcome:
- Exit code `1` for internal/invariant violations.
- Exit code `2` for guard Critical+Block (security policy failure).

The system must still emit a **minimal diagnostic report** if safe (e.g., `security.report.md` if available).

---

## 7. Anti-patterns

- “We’ll just fix ordering later”
- “This plugin can call an LLM just for classification”
- “We can infer which view is best automatically”
- “Skip guard failures in debug mode without explicit CLI flag”

---

## 8. Concrete examples

### Example: Determinism violation
If a plugin iterates dictionary keys without sorting, output changes across runs → **Invariant breach**.

### Example: Traceability violation
If a fragment is emitted without `SourceRef` and `EvidenceKey`, output cannot be audited → **Invariant breach**.

---

## 9. Required tests

See `tests.md` in this folder.
