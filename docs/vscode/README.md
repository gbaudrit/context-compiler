# VS Code + MCP (Phase 1)

This repo ships an MCP server host (`ContextCompiler.Cli.Mcp`) compatible with **stdio** transport.

## Configure VS Code

Create `.vscode/mcp.json` (workspace) or add a server in user settings.

Example:

```json
{
  "servers": {
    "context-compiler": {
      "type": "stdio",
      "command": "dotnet",
      "args": [
        "run",
        "--project",
        "src/Core/ContextCompiler.Cli.Mcp/ContextCompiler.Cli.Mcp.csproj"
      ]
    }
  }
}
```

## What Copilot can call

Tools:

- `compile_context(inputPath, outputPath, maxChars?)`
- `list_artifacts()`
- `read_artifact(name)`
- `list_views()`

Resources (preferred for large payloads):

- `ctxc://artifact/<artifactName>` (e.g. `ctxc://artifact/prompt.context.md`)
- `ctxc://view/<viewId>` (e.g. `ctxc://view/default`)

Typical flow:

1. Call `compile_context` on your workspace folder into an `out/` folder.
2. Read `prompt.context.md` or specific resources for chat/agent context.
