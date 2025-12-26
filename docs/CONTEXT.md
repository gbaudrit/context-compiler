# Context Compiler — Project Context (Source of Truth)

**Context Compiler** is a .NET 10 toolchain that **compiles raw information into a governed reasoning artifact for LLMs**.

## What it is
- A **compiler-style pipeline** (passes) with a canonical **Reasoning IR** (Intermediate Representation).
- Produces artifacts such as `prompt.context.md`, `evidence.index.json`, `reasoning.graph.json`, `security.report.md`.

## What it is not
- Not an agent runtime.
- Not a RAG/embedding store by default.
- Not a prompt UI (Copilot/IDE handles UX; we provide compiled context + MCP tools).

## Core concepts
- **Reasoning IR**: internal canonical representation (fragments, metadata, relations, scores, findings).
- **Evidence IDs**: stable **EK** (identity) + versioned **ER** (revision). Resilient to edits.
- **Reasoning Graph**: graph projection of IR; exporters are plugins.
- **Views**: plugin-defined projections/perspectives of the corpus.
- **Hypotheses**: build variants (A/B of context compilation).
- **CtxGuards**: pre-LLM security guard set producing structured findings and explicit actions.

## Pipelines
### Document pipeline (per file)
Discovery → Scope Guard → FileReader/DataReader → Engineering Modules → Injection Guard → Transcoding → Evidence indexing

### Global pipeline (once)
IR → Feature Flags → Views → Anchors → Compression → Ambiguity → Contradictions → Validation → Health → Templates → Personas
→ Hypotheses → ModelFit Guard → Preflight Guard → Assembly → Diff/Explain

## Security (retained guards)
- Prompt Injection Guard
- Data Sensitivity Guard
- Context Scope Guard
- Policy Compliance Guard
- Model Capability Guard
- Output Safety Preflight
- Guard Explainability

## Repository standards
- `eng/` contains engineering standards and Central Package Management.
- Tests use **MSTest + Moq + FluentAssertions**.
- Plugins can be installed via **NuGet** and loaded at runtime using **AssemblyLoadContext**.

See `docs/decisions/` for the full decision log and `docs/specs/` for detailed specs.

_Last updated: 2025-12-26_
