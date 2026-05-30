# 0009 - Skill providers and modules config v2

## Status

Accepted

## Context

Context Compiler loads executable modules from NuGet-backed sources using a `ctxc.modules.config.json` file. The root-level configuration previously described module restore directly (`sources`, `trust`, `packages`, `installRoot`, `lockFile`).

The platform also needs to install and compile declarative skills from multiple ecosystems, for example Anthropic agent skills or Awesome Copilot catalogs. These sources use different discovery and packaging rules, so the core must not encode provider-specific GitHub, catalog, or registry details.

## Decision

`ctxc.modules.config.json` uses `schemaVersion: 2` and namespaces module restore under `modules`.

Skills are introduced as declarative assets under `skills`. Skills are not executable modules. Executable skill providers are installed as normal runtime modules through `modules.packages`; those providers resolve and fetch skill content through the `ISkillProvider` contract.

Skill references use the canonical form:

```text
<skill-id>@<provider-id>[:<version-or-channel>]
```

Configured skills are declared in `skills.items`. Modules may declare skill requirements through `ISkillRequirementsProvider`, but those declarations do not mutate configuration. They are aggregated into a deterministic install plan and governed by `skills.declarations` and `skills.trust`.

Fetched/raw provider content belongs under `skills.cacheRoot`. Compile-time materialization will validate cached skills and expose accepted skills under `skills.compiledRoot`, which defaults to `.ctxc/compiled/.agents/skills`. Skills must be direct child folders of that compiled root once materialized.

## Consequences

- The old root-level modules config format is not supported.
- `modules.packages` remains the source of executable runtime modules.
- `skills.items` describes declarative skills resolved by provider modules.
- The core depends on stable skill abstractions, not on Anthropic, Awesome Copilot, GitHub, or other provider details.
- Installed skills use a separate `ctxc.skills.lock.json` model from module package locks.
- Module-declared skill requirements are auditable inputs to planning, not hidden side effects.
