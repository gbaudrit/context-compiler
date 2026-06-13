# Glossary (Agent-Ultra)

- **Context**: information given to the LLM before answering.
- **Compile**: deterministic transformation from folder → artifacts.
- **Analyze**: lightweight core phase that inventories/classifies a project and recommends modules to restore.
- **Prepare**: phase executed after prepare modules are restored; it creates compile configuration and prepare artifacts.
- **Autopilot**: CLI mode that runs Analyze, restore prepare, Prepare, restore compile, and Compile in order.
- **Module**: atomic capability that does one thing and can be plugged into a pipeline.
- **Module scope**: restore group for executable modules; currently `prepare`, `compile`, or `all`.
- **Local module source**: NuGet source addressed with `@local`.
- **Version override**: workspace policy in `.ctxc/ctxc.modules.versions.json` that can replace requested module versions using wildcard package patterns.
- **Pack**: coherent group of modules distributed as a ready-to-use unit.
- **Pipeline**: ordered execution flow where the output of one stage becomes the input of the next.
- **Blueprint**: use-case-oriented solution that combines modules, packs, and a pipeline into a final outcome.
- **Fragment**: atomic unit in the Compiled Context.
- **Compiled Context**: canonical intermediate representation.
- **EvidenceKey (EK)**: stable citeable identifier.
- **EvidenceRevision (ER)**: content revision identifier.
- **View**: projection of the Compiled Context (select/order/render).
- **Template**: global framing wrapper.
- **Guard**: safety/policy checks pre-LLM.
- **Artifact**: output file.
- **MCP**: Model Context Protocol.


