# Feature: Personas (Persona Plugins) (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Global Pipeline module kind `Persona`

A Persona is a **plugin-produced framing overlay** that guides role/style/output expectations.
Personas are applied globally and do not modify data fragments.

Personas are a core mechanism to make “context engineering” explicit and reusable.

---

## 1. Why this feature exists
Different consumers need different behavior from the same evidence set:
- an architect persona expects strict code standards
- a security persona expects threat-model focus
- a product persona expects concise explanations

Hardcoding these in templates is brittle. Personas provide modular overlays.

---

## 2. Problem it solves
- Reusable role/style overlays
- Configurable selection and ordering
- Clear audit of which personas were applied

---

## 3. Alternatives rejected
- “Just write different templates”: rejected; personas should be composable overlays.
- “Make persona per file”: rejected; you validated persona is global, not per-file.
- “LLM-generated persona”: rejected; pre-LLM requirement.

---

## 4. Contracts (authoritative)

### Plugin interface concept
- `PersonaId`
- `Build(ctx) -> PersonaResult`

`PersonaResult` contains:
- `PersonaId`
- `Title`
- `FramingMarkdown` (the injected overlay)
- optional metadata

Personas are discovered via plugin registry.

---

## 5. Configuration (authoritative)

`ctxc.config.json` section `personas`:

- `active`: ordered list of personaIds
- `mode`: `append | prepend | replace`
- `params`: per-persona arbitrary objects

Rules:
- execution order = config order
- if persona not found: warn + skip (deterministic)
- CLI may override active list (future)

See `schema.json` and `examples.json`.

---

## 6. Application rules (authoritative)

Personas are applied to framing as follows:

- `append`: base framing + persona overlays (in active order)
- `prepend`: persona overlays + base framing
- `replace`: persona overlays only

Personas must be applied **after Global Context**.

---

## 7. MUST / MUST NOT

### MUST
- Be deterministic.
- Never modify fragments or evidence IDs.
- Emit `personas.active.json` artifact (recommended) listing applied personas.
- Preserve ordering from config.

### MUST NOT
- Execute LLM calls.
- Infer active personas automatically.
- Add dynamic values (time).

---

## 8. Built-in personas (validated)

### `dev_architect`
- code quality focus (DI, SOLID, testability, standard patterns)
- output: structured markdown sections

### `security_reviewer`
- security focus (secrets, injection, unsafe actions)
- output: checklist + mitigations

---

## 9. Examples

See `examples.json`.

---

## 10. Required tests
See `tests.md`.
