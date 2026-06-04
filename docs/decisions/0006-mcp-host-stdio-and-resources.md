# 0006 - MCP host (stdio) exposing compile + artifacts as resources

- Status: accepted
- Date: 2025-12-26

## Context

Phase 1 requires VS Code / Copilot consumption without building a custom UX.
MCP is the standard integration path. We need:

- A tool to compile a workspace folder into Context Compiler artifacts.
- A way for the host to fetch the produced artifacts (prompt, evidence index, graph, views).

## Decision

Implement an MCP server host (`ContextCompiler.Cli.Mcp`) using the official MCP C# SDK:

- Transport: stdio
- Tools:
  - `compile_context(inputPath, outputPath, maxChars?)`
  - `list_artifacts()`
  - `read_artifact(name)`
  - `list_views()`
- Resources:
  - `ctxc://artifact/<name>` => reads file content from last compilation output
  - `ctxc://view/<id>` => reads `view.<id>.md` content

## Consequences

- VS Code can connect to the server via `mcp.json` without an extension.
- Copilot chat/agent can call tools and read resources.
- The server maintains an in-memory `WorkspaceState` refreshed after compilation.
