# ContextCompiler.Skills.Modules.Artifacts.Enrichment

`ContextCompiler.Skills.Modules.Artifacts.Enrichment` exposes restored skills as output artifacts.

The module runs during `PrerequisitesEnrichment`, reads skill files from provider restore caches through `ISkillProvider`, and registers them as `ArtifactCategory.Skill` artifacts before artifact validation and persistence.
