# 0004 — Security guards: retained CtxGuards set

    * Status: Accepted
    * Date: 2025-12-26

    ## Context and Problem Statement
    We want strong pre-LLM governance. Guards must detect and mitigate risks in input context without relying on LLM post-processing.

    ## Decision Drivers
    - Maintainability and testability
    - Deterministic, pre-LLM compilation
    - Extensibility via plugins
    - Enterprise-grade governance & security

    ## Considered Options
    - Option A: Implement as decided below
    - Option B: Simpler/monolithic variants (rejected)

    ## Decision Outcome
    Retain the following pre-LLM guards: Prompt Injection, Data Sensitivity, Context Scope, Policy Compliance, Model Capability, Output Safety Preflight, Guard Explainability. Guards produce structured findings and explicit actions (skip/redact/quarantine/block).

    ### Consequences
    - Enterprise-ready safety posture.
- Findings are auditable and can be rendered in reports.
- Requires consistent stages/hook points and a common finding model.

    ## Links
    - See `docs/CONTEXT.md`
