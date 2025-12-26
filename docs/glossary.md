# Glossary

- **Context Compiler**: The product/toolchain. Compiles raw information into governed reasoning artifacts for LLMs.
- **Reasoning IR**: Intermediate Representation used internally by the compiler (canonical data model).
- **Fragment**: Atomic unit of information in the IR (text/table/assertion).
- **EvidenceKey (EK)**: Stable identity of an evidence fragment across edits (best-effort stable).
- **EvidenceRevision (ER)**: Version identifier of a specific evidence content revision.
- **Evidence Index**: Mapping of EK/ER to source locators and metadata.
- **Reasoning Graph**: Graph projection of IR (nodes: evidence; edges: relationships/usage/order).
- **Views**: Plugin-defined projections (perspectives) over the IR.
- **Personas**: Overlays that adapt views/framing to a role or audience.
- **Hypotheses**: Build variants of compilation outputs to compare alternatives.
- **CtxGuards**: Pre-LLM guard suite producing structured findings (security & safety).
- **Guard Finding**: Structured output of a guard (severity, action, message, source, data).
- **Anchors**: Stable navigation identifiers inserted into rendered views to reference sections.
- **Coverage**: Measurement of which evidence IDs were used/cited by an answer (when available).
- **MADR**: Markdown Architectural Decision Records used to capture decisions.
