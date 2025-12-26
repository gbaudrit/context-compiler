# Feature: CLI (ctxc) (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Tech:** System.CommandLine  
**Goal:** Provide a deterministic, scriptable interface for humans and agents.

---

## 1. Why this feature exists
A compiler must be usable:
- locally by developers
- in CI
- by IDE agents via command invocation

CLI is the stable “front door” of the system.

---

## 2. Problem it solves
- Deterministic compilation invocation
- Artifact inspection (views, reports, evidence)
- Health diagnostics
- Diffing between runs

---

## 3. Commands (authoritative baseline)

### 3.1 `ctxc compile`
Compiles a context folder.

**Args**
- `--input <path>` (required)
- `--output <path>` (required)
- `--config <path>` (optional; default: `<input>/ctxc.config.json`)
- `--views <ids>` (optional; comma-separated)
- `--template <id>` (optional)
- `--personas <ids>` (optional; overrides config)
- `--strict` (optional; treat warnings as errors)
- `--format <md|json>` (optional; affects some artifacts)

**Exit codes**
- `0` success
- `1` config/invariant/internal failure
- `2` guard Critical+Block (security/policy)

**Artifacts**
Writes output contract set (Phase 4).

---

### 3.2 `ctxc views`
Lists and/or renders views.

**Args**
- `--output <path>` (required) (points to prior compile output)
- `--list` (default)
- `--render <viewId>` (optional; prints view to stdout)
- `--format <md|json>` (optional)

---

### 3.3 `ctxc evidence`
Inspect evidence index.

**Args**
- `--output <path>` (required)
- `--find-ek <EK>` (optional)
- `--find-path <glob>` (optional)
- `--json` (optional)

---

### 3.4 `ctxc guards`
Inspect guard report.

**Args**
- `--output <path>` (required)
- `--json` (optional)

---

### 3.5 `ctxc diff`
Diff two outputs deterministically.

**Args**
- `--left <outputPath>`
- `--right <outputPath>`
- `--format <md|json>`

Diff must compare:
- evidence.index.json (EK/ER deltas)
- prompt.context.md (text diff)
- security report summary

---

### 3.6 `ctxc plugins`
List discovered plugins.

**Args**
- `--kind <kind>` (optional)
- `--json` (optional)

---

### 3.7 `ctxc graph`
Inspect graph and optionally compute coverage.

**Args**
- `--output <path>`
- `--coverage <usedEkFile.json>` (optional)
- `--format <md|json>`

---

### 3.8 `ctxc health`
Show health metrics.

**Args**
- `--output <path>`
- `--json` (optional)

---

## 4. Determinism rules
- CLI output is deterministic (sorted lists).
- Printing uses stable ordering and consistent newline endings.
- No timestamps in stdout unless behind a `--verbose` and not used for diffing.

---

## 5. MUST / MUST NOT

### MUST
- Provide stable exit codes.
- Provide stable error messages for same failure types.
- Never mutate input folder.

### MUST NOT
- Hide failures behind success exit codes.
- Auto-detect config with ambiguous rules beyond documented default.

---

## 6. Required tests
See `tests.md`.
