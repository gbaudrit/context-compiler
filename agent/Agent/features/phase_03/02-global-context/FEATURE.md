# Feature: Global Context (Named Schema) (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Global Pipeline framing composition, before `Persona` and `Template`

Global Context is a **static, declarative framing layer** containing general project-wide information.
It is not derived from files and is configured explicitly.

This is distinct from Personas:
- Global Context = facts about project + operating rules
- Personas = role/style overlays

---

## 1. Why this feature exists
Agents and LLMs perform better when they know:
- what the project is
- what the objectives are
- what constraints are non-negotiable
- what terminology means (glossary)

Embedding this information explicitly avoids:
- repeating it in every prompt manually
- relying on implicit knowledge

---

## 2. Problem it solves
- Provides a single authoritative place for project framing.
- Ensures deterministic, reusable global prompt context.
- Separates “system rules” from “data”.

---

## 3. Alternatives rejected
- “Block arrays with ids”: rejected (you requested named properties).
- “Multiple files for must/mustNot”: rejected for LLM comprehension; one section is clearer.
- “Derive from readme automatically”: rejected (implicit and unstable).

---

## 4. Configuration (authoritative)

`ctxc.config.json` includes:

- `context.enabled`
- `context.project`
- `context.objectives`
- `context.assumptions`
- `context.constraints.must`
- `context.constraints.mustNot`
- `context.glossary`
- `context.outputContract` (optional)

See `schema.json` and `examples.json`.

---

## 5. Rendering rules (fixed order)

1. Project
2. Objectives
3. Assumptions
4. Constraints
   - MUST
   - MUST NOT
5. Glossary (optional)
6. Output Contract (optional)

Missing sections are omitted without side effects.

---

## 6. MUST / MUST NOT

### MUST
- Render deterministically in fixed order.
- Never modify IR fragments.
- Be applied once per compilation.
- Be applied before Personas.

### MUST NOT
- Include dynamic values (dates/times).
- Pull information from input files implicitly.

---

## 7. Examples
See `examples.json`.

---

## 8. Required tests
See `tests.md`.
