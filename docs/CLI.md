# Context Compiler CLI — `ctxc` (Agent-Ultra)

This file is a **specification** for the CLI.  
An AI agent may generate the full `System.CommandLine` implementation from this spec.

---

## 0) Global conventions

### 0.1 Determinism
- Commands must not depend on time, locale, or machine-specific ordering.
- Sort lists lexicographically (OrdinalIgnoreCase where relevant).

### 0.2 Default exit codes
- `0` success
- `1` internal error / invalid state
- `2` blocked by critical guard (policy/security)

### 0.3 Common options (recommended)
These options may exist on multiple commands:

- `--json` : output machine-readable JSON to stdout
- `--verbose` : extra logs
- `--quiet` : minimal output

---

## 1) `ctxc compile`

Compile un dossier en artefacts.

### Syntax
```bash
ctxc compile --input <folder> --output <folder> [options]
```

### Options
- `--input <folder>` (required) : root path (workspace)
- `--output <folder>` (required) : output folder
- `--max-chars <int>` (optional, default 120000) : budget for `prompt.context.md`
- `--views <id1,id2,...>` (optional) : render only selected views (future hook)
- `--no-guards` (optional) : disables non-critical guards (debug only; must still run critical guards)
- `--config <file>` (optional) : config file path (future)
- `--json` (optional) : emit summary JSON

### Output
On success:
- prints summary (human or JSON)
- creates artifacts in output folder

### Summary JSON shape (recommended)
```json
{
  "exitCode": 0,
  "inputPath": "...",
  "outputPath": "...",
  "artifacts": ["prompt.context.md", "..."],
  "views": ["default"]
}
```

---

## 2) `ctxc diff`

Compare two output folders.

### Syntax
```bash
ctxc diff --left <outputA> --right <outputB> [options]
```

### Options
- `--left <folder>` (required)
- `--right <folder>` (required)
- `--format <md|json>` (optional, default md)
- `--out <file>` (optional) : write diff to file (default: `diff.context.md` in current dir)

### Behavior
- load evidence indexes (if present) from both sides
- compare:
  - added EK
  - removed EK
  - changed ER for same EK
- produce:
  - markdown diff report OR JSON diff payload

---

## 3) `ctxc explain`

Explain compilation outputs.

### Syntax
```bash
ctxc explain --input <outputFolder> [options]
```

### Options
- `--input <folder>` (required)
- `--out <file>` (optional) default: `context.explain.md` under input folder
- `--format <md|json>` (optional, default md)

### Behavior
- read available artifacts
- produce an explanation:
  - number of fragments
  - number of views
  - list of artifacts
  - summary of findings from security.report (if exists)

---

## 4) `ctxc health`

Compute or display health metrics.

### Syntax
```bash
ctxc health --input <outputFolder> [options]
```

### Options
- `--input <folder>` (required)
- `--format <text|json>` (optional, default text)
- `--fail-below <int>` (optional) : if score below => exit code 1

### Behavior
- read `context.health.json` if present; else compute:
  - fragments count
  - findings count
  - score = max(0, 100 - findings*5) (baseline)

---

## 5) `ctxc views`

### 5.1 `ctxc views list`

List available views.

```bash
ctxc views list --input <outputFolder> [--json]
```

Options:
- `--input <folder>` required
- `--json` optional

Behavior:
- list `view.<id>.md` files
- extract ids and print sorted

### 5.2 `ctxc views render`

Render a view explicitly (future: re-render from IR or just print stored output).

```bash
ctxc views render --id <viewId> --input <outputFolder> [--out <file>]
```

Options:
- `--id <id>` required
- `--input <folder>` required
- `--out <file>` optional (default: stdout)

Behavior:
- read `view.<id>.md` and print it (phase 1)
- phase 2: allow re-render from IR

---

## 6) `ctxc guards`

### 6.1 `ctxc guards report`

```bash
ctxc guards report --input <outputFolder> [--format md|json] [--out <file>]
```

Options:
- `--input <folder>` required
- `--format <md|json>` default md
- `--out <file>` optional

Behavior:
- read `security.report.md` if present
- JSON format should parse structured findings if a JSON report exists (future)
- phase 1: output markdown content

---

## 7) `ctxc plugins`

Phase 2+ commands (stubs allowed in phase 1).

### 7.1 `ctxc plugins list`

```bash
ctxc plugins list [--json]
```

Behavior:
- list loaded plugin metadata (id, kind, version, priority)

### 7.2 `ctxc plugins add`

```bash
ctxc plugins add <packageId> [--version <ver>] [--source <url>]
```

Behavior:
- install plugin NuGet package into `.ctxboost/plugins/...`
- update `plugins.lock.json`

### 7.3 `ctxc plugins remove`

```bash
ctxc plugins remove <packageId>
```

Behavior:
- uninstall package folder
- update lock file

---

## 8) `ctxc graph`

### 8.1 `ctxc graph export`

```bash
ctxc graph export --input <outputFolder> --format <json|dot|mermaid> [--out <file>]
```

Behavior:
- read `reasoning.graph.json`
- if format == json => print as is
- if dot/mermaid => use exporter plugin OR simple converter (baseline)

---

## 9) Recommended System.CommandLine mapping

An agent generating code should create:
- root command `ctxc`
- subcommands: compile, diff, explain, health
- command group: views (list, render)
- command group: guards (report)
- command group: plugins (list, add, remove)
- command group: graph (export)

Each command should be implemented with handler methods calling services from DI.
