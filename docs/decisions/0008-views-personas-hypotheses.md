# 0008 — Views, Personas, and Hypotheses

    * Status: Accepted
    * Date: 2025-12-26

    ## Context and Problem Statement
    The compiler must support multiple perspectives (views) and role-specific overlays (personas), and allow comparing different compilation configurations (hypotheses).

    ## Decision Drivers
    - Maintainability and testability
    - Deterministic, pre-LLM compilation
    - Extensibility via plugins
    - Enterprise-grade governance & security

    ## Considered Options
    - Option A: Implement as decided below
    - Option B: Simpler/monolithic variants (rejected)

    ## Decision Outcome
    Implement Views as plugin-defined projections of Reasoning IR. Implement Personas as overlays applied during rendering/assembly. Implement Hypothesis Mode to fork build outputs for A/B comparison.

    ### Consequences
    - Enables targeted context for different tasks/audiences.
- Supports experimentation and reproducible comparisons.
- Requires stable configuration layering and output folder conventions.

    ## Links
    - See `docs/CONTEXT.md`
