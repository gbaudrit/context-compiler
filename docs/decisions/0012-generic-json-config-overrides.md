# 0012 - Generic JSON config overrides

## Status

Accepted

## Context

Context Compiler has several JSON configuration files:

- `ctxc.config.json`
- `ctxc.modules.config.json`
- `ctxc.modules.versions.json`
- `ctxc.skills.config.json`

Some settings need to vary by workspace, developer machine, CI environment, or local module feed without rewriting generated base config files.

Dedicated override mechanisms for each file would duplicate configuration logic and make precedence rules hard to remember.

The CLI also has two configuration concerns:

- tool/runtime configuration such as hosting, logging, and diagnostic settings;
- request configuration used by Context Compiler to process a workspace (`context`, `files`, `views`, `modules`, `moduleVersions`, `skills`, etc.).

These concerns must remain distinguishable, but they must not require separate manually-built `IConfigurationRoot` instances because environment variables and command-line overrides need one predictable precedence chain.

## Decision

The CLI host owns configuration loading through `HostApplicationBuilder.Configuration`.

Every JSON configuration file may have a sibling override file named by inserting `.overrides` before `.json`.

Examples:

```text
ctxc.config.json                  -> ctxc.config.overrides.json
ctxc.modules.config.json          -> ctxc.modules.config.overrides.json
ctxc.modules.versions.json        -> ctxc.modules.versions.overrides.json
ctxc.skills.config.json           -> ctxc.skills.config.overrides.json
```

Workspace request files are loaded in this order:

```text
.ctxc/<file>.json
.ctxc/<file>.overrides.json
<file>.json
<file>.overrides.json
```

This applies to:

```text
ctxc.config.json
ctxc.modules.config.json
ctxc.modules.versions.json
ctxc.skills.config.json
```

Later files override earlier files. The resulting configuration is bound into the existing JSON configuration and options models from the host `IConfiguration`.

Precedence follows `Microsoft.Extensions.Configuration`: later providers override earlier providers by configuration key. The CLI loads, in order:

```text
appsettings.json
workspace JSON files and sibling overrides
CTXC_ environment variables
configuration command-line overrides
```

Command-line configuration overrides use standard configuration keys with `:` separators and inline values, for example:

```text
ctxc compile --input . --modules:installRoot=custom-modules
```

Plain CLI grammar remains handled by `System.CommandLine`; only `--key:value=...` style arguments are forwarded to the configuration provider.

## Consequences

- Generated config can remain stable while local or CI overrides stay separate.
- The same naming convention applies to modules, module version policy, skills, and root context config.
- Overrides must be explicit JSON files and are auditable.
- Tool/runtime config and request config are separated by file and section, but share a single host configuration pipeline so environment and command-line overrides work consistently.
- Feature code should consume `IConfiguration`/`IOptions<T>` from DI; it must not create a separate `IConfigurationRoot` for Context Compiler JSON files.
- Array/list overrides follow `Microsoft.Extensions.Configuration` index-key semantics; users should restate the desired list when they need predictable list replacement.
