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
- **Analyze runs before Prepare**. Analyze inventories/classifies the project and recommends prepare modules; deep technology analysis belongs in restored prepare modules.
- **Executable modules are scoped**. Use `modules.prepare.packages` for modules restored before Prepare and `modules.compile.packages` for modules restored before Compile.
- **Local module source is `@local` only**. Do not use or reintroduce `@locale`.
- **Floating module versions are intent, not lock state**. Resolve `*`/wildcards to exact versions before download and write exact versions to the module lock file.
- **Configuration is host-owned**. Load `ctxc*.json`, sibling `*.overrides.json`, environment variables, and CLI configuration overrides through `HostApplicationBuilder.Configuration`; do not create a separate `IConfigurationRoot` for request config.
- **JSON config overrides are generic**. Use sibling `*.overrides.json` files, e.g. `ctxc.config.overrides.json`, instead of adding per-feature override files.
- **Security guards are pre-LLM** only, produce structured findings, and never modify silently.
- **Evidence IDs are stable** (EK) and versioned (ER); graphs/exporters are plugin-based.
- Repo uses **.NET 10**, **Central Package Management**, and engineering standards in `eng/`.

## How to answer architecture questions
When asked "why" or "where is X decided", cite the relevant MADR file (e.g. `docs/decisions/0004-guards-selected.md`)
and summarize its context, decision, and consequences.

For Analyze/Prepare ordering, module scopes, `@local`, and module version overrides, cite
`docs/decisions/0011-analyze-prepare-scoped-modules-and-version-overrides.md`.
For generic JSON config overrides, cite `docs/decisions/0012-generic-json-config-overrides.md`.

## Making changes
- If a change alters an architectural choice, add a new MADR and link from `docs/CONTEXT.md`.
- Keep terminology consistent with `docs/glossary.md`.

_Last updated: 2026-06-10_
