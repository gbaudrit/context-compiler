# ContextCompiler.Skills.Modules.Providers.Anthropic

`ContextCompiler.Skills.Modules.Providers.Anthropic` resolves skills from the public `anthropics/skills` repository.

Provider id:

```text
anthropic-agent-skills
```

Example skill reference:

```text
skill-creator@anthropic-agent-skills:main
```

The provider fetches raw content into `skills.cacheRoot`. A later compile-time materialization step can guard and copy cache content into `skills.compiledRoot`.
