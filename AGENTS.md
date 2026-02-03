# Agent Guide (Copilot / IDE agents)

This repository contains the **Context Compiler** platform. When using an IDE agent (Copilot Chat/Agent),
treat the documents in `docs/` as the **source of truth** for architecture and decisions.

## Where to look first
1. `docs/CONTEXT.md` (one-page project summary and invariants)
2. `docs/decisions/` (MADR decision records; numbered)
3. `docs/specs/` (detailed specs)
4. `docs/glossary.md` (terminology)

## Non-negotiable engineering rules
- **Core has no direct I/O**. All filesystem/network/serialization live in Infrastructure via abstractions.
- **Plugins are first-class** and loaded at runtime (NuGet + AssemblyLoadContext).
- **Security guards are pre-LLM** only, produce structured findings, and never modify silently.
- **Evidence IDs are stable** (EK) and versioned (ER); graphs/exporters are plugin-based.
- Repo uses **.NET 10**, **Central Package Management**, and engineering standards in `eng/`.

## How to answer architecture questions
When asked "why" or "where is X decided", cite the relevant MADR file (e.g. `docs/decisions/0004-guards-selected.md`)
and summarize its context, decision, and consequences.

## Making changes
- If a change alters an architectural choice, add a new MADR and link from `docs/CONTEXT.md`.
- Keep terminology consistent with `docs/glossary.md`.

_Last updated: 2025-12-26_
