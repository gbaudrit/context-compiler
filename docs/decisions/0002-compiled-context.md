# 0002 — Canonical internal model: Compiled Context

    * Status: Accepted
    * Date: 2025-12-26

    ## Context and Problem Statement
    The system requires a single canonical representation to support multiple passes (guards, views, compression, validation) and multiple output artifacts.

    ## Decision Drivers
    - Maintainability and testability
    - Deterministic, pre-LLM compilation
    - Extensibility via plugins
    - Enterprise-grade governance & security

    ## Considered Options
    - Option A: Implement as decided below
    - Option B: Simpler/monolithic variants (rejected)

    ## Decision Outcome
    Adopt **Compiled Context** (Intermediate Representation) as the internal canonical model. All compilation passes operate on Compiled Context; rendering/export is derived from it.

    ### Consequences
    - Simplifies extension and testing.
- Enables deterministic compilation and incremental rebuild.
- Provides a stable base for evidence indexing and graph exports.

    ## Links
    - See `docs/CONTEXT.md`

