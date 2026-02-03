# CLI Commands — Detailed Specs (Ultra)

This file exists so an agent can generate System.CommandLine code reliably.

## Root command
Name: `ctxc`
Description: Context Compiler CLI

Global options:
- `--verbose` (bool)
- `--no-color` (bool)
- `--version` (bool)

All command outputs MUST be deterministic.

---

## compile
Command: `compile`
Options:
- `--input` (string, required)
- `--output` (string, required)
- `--config` (string, optional)
- `--views` (string, optional; comma-separated list)
- `--template` (string, optional)
- `--personas` (string, optional; comma-separated list; overrides config)
- `--strict` (bool)
- `--format` (enum: md|json; optional)

Behavior:
1. Resolve config path:
   - if --config specified: use it
   - else: `<input>/ctxc.config.json` if exists
   - else: defaults
2. Run full pipeline (Phase 1–4).
3. Write artifacts to output.
4. Return exit codes per contract.

---

## views
Command: `views`
Options:
- `--output` (string, required)
- `--list` (bool, default true)
- `--render` (string, optional)
- `--format` (enum: md|json; optional)

Behavior:
- Read view artifacts from output folder.
- List view IDs deterministically.
- Render prints exact artifact bytes to stdout.

---

## evidence
Command: `evidence`
Options:
- `--output` (string, required)
- `--find-ek` (string, optional)
- `--find-path` (string, optional)
- `--json` (bool)

Behavior:
- Load evidence.index.json
- Apply deterministic filters
- Output sorted results

---

## guards
Command: `guards`
Options:
- `--output` (string, required)
- `--json` (bool)

Behavior:
- Print summary + findings ordering rules.

---

## diff
Command: `diff`
Options:
- `--left` (string, required)
- `--right` (string, required)
- `--format` (enum: md|json)

Behavior:
- Compare evidence deltas (added/removed/changed ER).
- Compare prompt.context.md (line diff).
- Compare guard severity counts.
- Output deterministic diff report.

---

## plugins
Command: `plugins`
Options:
- `--kind` (string, optional)
- `--json` (bool)

Behavior:
- Print discovered plugins sorted by (kind, priority, id).

---

## graph
Command: `graph`
Options:
- `--output` (string, required)
- `--coverage` (string, optional; json file with used EK list)
- `--format` (enum: md|json)

Behavior:
- Print graph stats.
- If coverage provided, compute coverage and emit coverage artifacts.

---

## health
Command: `health`
Options:
- `--output` (string, required)
- `--json` (bool)

Behavior:
- Print health metrics from context.health.json.
