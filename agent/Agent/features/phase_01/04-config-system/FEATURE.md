# Feature: Configuration System (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26

Configuration is centralized in `ctxc.config.json` and validated using JSON Schema.
Configuration must be optional: absence of config must not break compilation.

---

## 1. Why this feature exists

Without explicit configuration:
- Excel extraction becomes noisy and huge
- framing becomes implicit and inconsistent
- agents cannot reproduce behavior
- features cannot be safely toggled

---

## 2. Problem it solves

- Declarative control of extraction (Excel)
- Declarative control of framing (Global Context / Personas)
- Central place for future knobs (guards, views selection, budgets)

---

## 3. Alternatives rejected

### A) Many scattered config files
Rejected: fragmentation, confusion, no single source of truth.

### B) Only CLI flags
Rejected: non-reproducible; agents need repo-stored config.

### C) LLM-generated config
Rejected: pre-LLM requirement.

---

## 4. Scope

- Single config file: `ctxc.config.json` (workspace root by default)
- Optional override path via CLI `--config`
- Validation via schema: `ctxc.config.schema.json`

---

## 5. Config sections validated so far (authoritative)
- `context` (global context, named properties, no block ids)
- `personas`
- `excel`

---

## 6. MUST / MUST NOT

### MUST
- Provide safe defaults when config is missing.
- Validate config and fail fast on invalid schema (exit code 1).
- Never infer missing required fields beyond documented defaults.
- Keep config stable and backwards-compatible.

### MUST NOT
- Treat config as “optional but maybe partially applied” without warnings.
- Allow ambiguous interpretation of config fields.

---

## 7. Examples
See `examples.json`.

---

## 8. Required tests
See `tests.md`.
