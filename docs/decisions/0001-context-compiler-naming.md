# 0001 — Product naming: Context Compiler

    * Status: Accepted
    * Date: 2025-12-26

    ## Context and Problem Statement
    We need a product name that is technically honest and matches a compiler-style pipeline (passes, IR, reports). Earlier names like 'Context Booster' under-sold the scope (governance, security, evidence, coverage).

    ## Decision Drivers
    - Maintainability and testability
    - Deterministic, pre-LLM compilation
    - Extensibility via plugins
    - Enterprise-grade governance & security

    ## Considered Options
    - Option A: Implement as decided below
    - Option B: Simpler/monolithic variants (rejected)

    ## Decision Outcome
    We name the product **Context Compiler** and describe it as compiling raw information into governed reasoning artifacts for LLMs. We keep the user-facing verb 'compile the context' as canonical terminology.

    ### Consequences
    - Clear and durable mental model (compiler pipeline).
- Aligns with IR, passes, static analysis (guards), and artifacts.
- Enables consistent CLI naming (ctxc compile/diff/explain/health).

    ## Links
    - See `docs/CONTEXT.md`
