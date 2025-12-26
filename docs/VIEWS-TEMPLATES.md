# Views & Templates (Agent-Ultra)

## 1) View definition
A **view** is a named projection of the Reasoning IR.

A view decides:
- which fragments are included
- how they are ordered
- how they are rendered (markdown)

Views are **global** (not per-file), but can group by file.

### ViewResult contract
- ViewId
- Title
- RenderedMarkdown
- Metadata (optional)

## 2) Template definition
A **template** wraps the compiled views with global framing.

It defines:
- MUST / MUST NOT lists
- citation policy (use EK)
- output format constraints (if any)

Templates are applied AFTER views.

## 3) Why views matter for Copilot
Copilot can contextualize files; views provide a **composed context** across many files,
including framing. Copilot uses its own UX, but reads the compiled view(s) or prompt file.

## 4) Future ideas (not mandatory now)
- persona overlays
- hypothesis builds
- per-model template variants
