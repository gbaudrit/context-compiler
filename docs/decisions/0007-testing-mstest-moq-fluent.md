# 0007 — Testing strategy: MSTest + Moq + FluentAssertions

    * Status: Accepted
    * Date: 2025-12-26

    ## Context and Problem Statement
    We require testable and mockable architecture; prefer MSTest with Moq and FluentAssertions. We also want E2E snapshot tests for artifacts.

    ## Decision Drivers
    - Maintainability and testability
    - Deterministic, pre-LLM compilation
    - Extensibility via plugins
    - Enterprise-grade governance & security

    ## Considered Options
    - Option A: Implement as decided below
    - Option B: Simpler/monolithic variants (rejected)

    ## Decision Outcome
    Use MSTest for unit/integration tests, Moq for mocking, and FluentAssertions for assertions. Use `Verify.MSTest` for golden/snapshot tests of compilation artifacts.

    ### Consequences
    - Uniform testing stack.
- High confidence regression protection via snapshots.
- Encourages clean separations (ports/adapters) for mocking.

    ## Links
    - See `docs/CONTEXT.md`
