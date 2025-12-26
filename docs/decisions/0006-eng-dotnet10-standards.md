# 0006 — Engineering standards: eng/ folder, .NET 10, central packages

    * Status: Accepted
    * Date: 2025-12-26

    ## Context and Problem Statement
    The repo is a monorepo with multiple hosts/libs/plugins. We need consistent build rules, analyzers, and package versions.

    ## Decision Drivers
    - Maintainability and testability
    - Deterministic, pre-LLM compilation
    - Extensibility via plugins
    - Enterprise-grade governance & security

    ## Considered Options
    - Option A: Implement as decided below
    - Option B: Simpler/monolithic variants (rejected)

    ## Decision Outcome
    Adopt `eng/` as the single place for engineering standards and use **.NET 10** across projects. Enable Central Package Management, nullable, analyzers, and deterministic builds.

    ### Consequences
    - Consistent engineering baseline.
- Easier upgrades and governance.
- Scales with plugins and multiple hosts.

    ## Links
    - See `docs/CONTEXT.md`
