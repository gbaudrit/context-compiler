# 0005 — Evidence IDs, Reasoning Graph, and Coverage

    * Status: Accepted
    * Date: 2025-12-26

    ## Context and Problem Statement
    We want traceability: identify atomic information, generate graphs, and measure usage coverage. Graph outputs must be pluggable, and evidence IDs must be stable across edits.

    ## Decision Drivers
    - Maintainability and testability
    - Deterministic, pre-LLM compilation
    - Extensibility via plugins
    - Enterprise-grade governance & security

    ## Considered Options
    - Option A: Implement as decided below
    - Option B: Simpler/monolithic variants (rejected)

    ## Decision Outcome
    Introduce Evidence IDs with stable EK (EvidenceKey) and versioned ER (EvidenceRevision). Use anchor/structural/fuzzy strategies to keep EK stable. Produce a canonical GraphModel and export through `IGraphExporterPlugin` (JSON/DOT/Mermaid). Optionally validate LLM citations and compute coverage when the answer is available.

    ### Consequences
    - Strong provenance and auditability.
- Enables visualization and confidence tooling.
- Requires an evidence index and stable locator strategies.

    ## Links
    - See `docs/CONTEXT.md`
