# 0003 — Plugin system: NuGet distribution + runtime loading (ALC)

    * Status: Accepted
    * Date: 2025-12-26

    ## Context and Problem Statement
    We need a plugin-first architecture: readers, guards, views, exporters, etc. must be installable independently and loaded at runtime.

    ## Decision Drivers
    - Maintainability and testability
    - Deterministic, pre-LLM compilation
    - Extensibility via plugins
    - Enterprise-grade governance & security

    ## Considered Options
    - Option A: Implement as decided below
    - Option B: Simpler/monolithic variants (rejected)

    ## Decision Outcome
    Distribute plugins as NuGet packages and load them at runtime using `AssemblyLoadContext` + `AssemblyDependencyResolver`. Keep stable contracts in `ContextCompiler.Abstractions` and load plugins into an isolated load context.

    ### Consequences
    - Enables third-party plugin ecosystem.
- Avoids recompiling hosts for new plugins.
- Requires careful versioning of Abstractions (Plugin API version) and a plugin lockfile.

    ## Links
    - See `docs/CONTEXT.md`
