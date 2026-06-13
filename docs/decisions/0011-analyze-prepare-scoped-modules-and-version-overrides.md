# 0011 - Analyze pipeline, scoped modules config, and version overrides

## Status

Accepted

## Context

Context Compiler needs to discover project characteristics before running technology-specific preparation modules.
For example, a .NET project should recommend and restore a .NET prepare module only when files such as `.csproj`, `.sln`, `global.json`, `Directory.Build.props`, or `Directory.Packages.props` are present.

The previous module configuration direction described executable modules as a single package set. That is not enough once modules are restored at different moments of the workflow:

- prepare modules must be available before `Prepare`;
- compile modules must be available before `Compile`;
- `Analyze` must stay core and lightweight, producing recommendations without doing deep technology-specific analysis.

The NuGet restore path also needs deterministic handling for floating versions such as `*` and workspace-specific overrides for development or CI.

## Decision

Introduce a first-class `Analyze` pipeline before `Prepare`.

The normal autopilot execution chain is:

```text
Analyze -> modules restore --scope prepare -> Prepare -> modules restore --scope compile -> Compile
```

`Analyze` produces audit artifacts under `.ctxc/prepare`:

- `inventory.json`
- `classification.json`
- `analyze.plan.json`

`Analyze` also updates `ctxc.modules.config.json` with recommended prepare packages.

Executable modules use modules config schema v1:

```json
{
  "schemaVersion": 1,
  "modules": {
    "installRoot": "modules",
    "lockFile": "ctxc.modules.lock.json",
    "versionOverridesFile": "ctxc.modules.versions.json",
    "runModulesFile": "ctxc.modules.run.json",
    "sources": [],
    "trust": {},
    "prepare": {
      "packages": {}
    },
    "compile": {
      "packages": {}
    }
  }
}
```

Module restore supports explicit scopes:

```text
ctxc modules restore --scope prepare
ctxc modules restore --scope compile
ctxc modules restore --scope all
```

Package ids may specify a source using:

```text
<package-id>@<source-id>
```

The canonical local source id is `local`. The legacy spelling `locale` is not supported.

Version values in config and catalogs describe requested intent. Floating requests such as `*`, `latest`, `1.2.*`, or `0.1.0-alpha.*` are resolved to an exact NuGet version before download. The lock file stores the resolved exact version so later runs remain deterministic.

Workspace-specific version overrides may be provided in `ctxc.modules.versions.json` relative to `StoreKeys.Root`:

```json
{
  "schemaVersion": 1,
  "overrides": {
    "ContextCompiler.Prepare.Modules.*": "0.1.0-alpha.*",
    "ContextCompiler.Prepare.Modules.DotNet": "0.1.0-alpha.3",
    "ContextCompiler.*@local": "*"
  }
}
```

The most specific matching wildcard wins. Overrides are applied before version resolution and before restore.
The overrides file is loaded by the modules loader configuration using the same `AddJsonFile` pattern as module and skill config: `.ctxc/ctxc.modules.versions.json` first, then `ctxc.modules.versions.json` at the workspace root as the higher-priority override. Inside `ctxc.modules.config.json`, path values such as `installRoot`, `lockFile`, `runModulesFile`, and `versionOverridesFile` are logical paths relative to `StoreKeys.Root`; they must not hard-code `.ctxc`.

This decision supersedes the executable-module config part of `0009-skill-providers-and-modules-config-v2.md`. Skill configuration remains separate and is not described by this modules schema.

## Consequences

- `Analyze` is the only core phase that detects project shape and recommends prepare modules.
- Technology-specific deep analysis belongs in restored prepare modules, not in core Analyze.
- Prepare and compile modules are restored independently and can be audited by scope.
- Autopilot can run end-to-end while preserving all intermediate artifacts.
- Floating versions are allowed in user intent, but restore and load use exact locked versions.
- Local development should use `@local` and a configured `local` NuGet source.
- Configurations using `@locale` fail clearly instead of being silently rewritten.
