# MCP Integration (Agent-Ultra)

## 1) Goal
Expose Context Compiler as a tool provider for IDE agents (VS Code / Copilot).

## 2) MCP server contract (stdio)
Tools:
- `compile_context(inputPath, outputPath, maxChars?)`
- `list_artifacts()`
- `read_artifact(name)`
- `list_views()`

Resources:
- `ctxc://artifact/<name>`
- `ctxc://view/<id>`

## 3) Intended Copilot flow
1. Copilot calls `compile_context` on workspace folder
2. Copilot reads `ctxc://artifact/prompt.context.md`
3. Copilot uses its own prompting UX

## 4) Why MCP (phase 1)
- No custom extension required
- Standardized tool interface
- Agents can retrieve artifacts reliably
