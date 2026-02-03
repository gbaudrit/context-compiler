# Agent Codegen Guide — System.CommandLine (Agent-Ultra)

This document is designed to let an AI agent generate the full CLI implementation
using `System.CommandLine` with confidence.

## 1) Ground rules
- CLI behavior must match `CLI.md` exactly.
- All commands must be implemented as stubs at minimum, wired to Core Engine services.
- Parsing must be deterministic and validated.
- Exit codes:
  - 0 success
  - 1 internal error
  - 2 blocked by critical guard

## 2) Project structure expectation
- `ContextCompiler.Host.Cli` hosts System.CommandLine.
- A `CliCommandFactory` can be used to keep Program.cs clean.
- All business logic calls `ICompilerEngine` (never does work in Program.cs).

## 3) Codegen checklist per command
For each command:
- define Command + description
- define Options/Arguments (required/optional)
- validate paths
- call engine/service layer
- format output deterministically (JSON for machine, text for human)
- return correct exit codes

## 4) Output conventions
- Default: human-readable
- Optional `--json` switch for machine output (recommended)
- Never print secrets from reports by default (guards already flag them)

## 5) Testing
- Unit tests should invoke command handlers with mocks:
  - Moq ICompilerEngine / IFileSystem
- Verify:
  - parsing
  - required args
  - exit codes
  - handler invocation
