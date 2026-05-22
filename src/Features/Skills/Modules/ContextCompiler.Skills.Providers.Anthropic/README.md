# ContextCompiler.Skills.Providers.Anthropic

`ContextCompiler.Skills.Providers.Anthropic` resolves skills from the public `anthropics/skills` repository.

Provider id:

```text
anthropic-agent-skills
```

Example skill reference:

```text
skill-creator@anthropic-agent-skills:main
```

The provider fetches raw content into `skills.cacheRoot` and writes agent-visible skill folders directly under `skills.compiledRoot`.
