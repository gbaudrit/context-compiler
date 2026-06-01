# 0010 - Skills artifact enrichment module location

## Status

Accepted

## Context

`SkillsArtifactEnrichmentModule` was initially hosted in the Anthropic skills provider module.
The module does not contain Anthropic-specific behavior: it reads configured skills, resolves the matching `ISkillProvider` by provider id, and registers restored skill files as `ArtifactCategory.Skill` output artifacts.

Keeping it in a provider package couples every skill artifact materialization workflow to Anthropic even when skills come from other providers.

## Decision

Move `SkillsArtifactEnrichmentModule` to a provider-neutral module:

```text
src/Features/Skills/Modules/ContextCompiler.Skills.Modules.Artifacts.Enrichment
```

The Anthropic module remains responsible only for the `AnthropicSkillProvider` keyed `ISkillProvider` registration.

## Consequences

- Skill artifact enrichment can be installed independently from any specific provider.
- Additional providers can reuse the same artifact materialization module.
- The output writer and artifact security guard remain generic and provider-neutral.
- Configurations that need skill artifact materialization must include `ContextCompiler.Skills.Modules.Artifacts.Enrichment` in addition to the required provider modules.
