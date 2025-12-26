# Context Compiler

A compiler pipeline for LLM context. This repository is a monorepo containing:
- Core engine & Reasoning IR
- Infrastructure (filesystem, NuGet plugin install, ALC plugin loading)
- Built-in plugins
- CLI Host
- MCP Host
- MSTest test suites (Moq + FluentAssertions)

## Quick start

```bash
dotnet build
dotnet test
```

## Repo layout
- `eng/` engineering standards (central packages, build props/targets, editorconfig)
- `src/` product code
- `tests/` test projects
- `samples/` sample repo + sample plugins
