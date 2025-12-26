# Feature: Framing Templates (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Global Pipeline stage 5

Templates assemble:
- Views output
- Global Context
- Personas overlays
into the final `prompt.context.md` artifact.

Templates are the final “front-end emitter” of the compiler.

---

## 1. Why this feature exists
Even with clean IR and views, LLMs require a coherent framing structure:
- role and constraints must be explicit
- output contract must be explicit
- evidence should be organized and citeable

Templates provide stable assembly rules.

---

## 2. Problem it solves
- Consistent output structure across runs and environments
- Easy replacement/extension via Template plugins
- Allows multiple template styles without changing pipeline stages

---

## 3. Alternatives rejected
- “Hardcode prompt assembly”: rejected; templates must be plugins.
- “LLM assembles the prompt”: rejected; pre-LLM requirement.

---

## 4. Scope

### Does
- Choose a template plugin (default if none configured).
- Render sections in stable order.
- Write `prompt.context.md`.

### Does NOT
- Modify fragments.
- Choose views dynamically (views are produced earlier).
- Execute safety policy decisions (guards handle).

---

## 5. Authoritative output shape (baseline)

`prompt.context.md` should include (in this order):

1. Title / header
2. Global Context (if enabled)
3. Personas (rendered overlays)
4. Views (one or more)
5. Evidence usage rules (EK/ER expectations)
6. Output Contract (if provided by Global Context or persona params)

Templates may include additional sections but must remain deterministic.

---

## 6. View inclusion rules
Baseline:
- include `view.default.md` if present
- if multiple views exist, include them in stable order by viewId ordinal
- allow future config to select specific views

---

## 7. MUST / MUST NOT

### MUST
- Render deterministically with fixed ordering rules.
- Preserve evidence IDs exactly.
- Include guard-related warnings if provided as artifacts/sections.

### MUST NOT
- Reflow or rewrite evidence content unpredictably.
- Inject dynamic timestamps.

---

## 8. Examples

Example snippet:
```md
# Prompt Context

## Global Context
...

## Personas
### dev_architect
...

## Views
### View: default
...

## Evidence Rules
Use EvidenceKey (EK) when citing facts.
Do not invent new evidence.
```

---

## 9. Required tests
See `tests.md`.
