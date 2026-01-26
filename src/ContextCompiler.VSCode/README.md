# CtxC VS Code Extension (Phase 1)

Minimal VS Code integration for **Context-Compiler (ctxc)**.

## What you get (Phase 1)
- Run `ctxc compile` on the current workspace or a selected folder
- Browse generated **Views** in a TreeView
- Select an active View
- Copy **View + minimal framing** to clipboard (prompt-ready)
- Open compiled outputs in the OS file explorer

## Prerequisites
- `ctxc` CLI available in PATH, or set `ctxc.path` in VS Code settings.
- A `ctxc.config.json` at workspace root (or set `ctxc.configPath`).

## Outputs expected
After compilation:
- `.ctxc/out/compiled.context.md`
- `.ctxc/out/views/*.md`
- `.ctxc/out/evidence.index.json`

## Commands
- **CtxC: Compile Context (Workspace)**
- **CtxC: Compile Context (Folder…)**
- **CtxC: Select View**
- **CtxC: Open Compiled Output**
- **CtxC: Copy View + Framing to Clipboard**
- **CtxC: Re-Compile (Last Run)**

## Settings
- `ctxc.path` (default: `ctxc`)
- `ctxc.configPath` (default: `ctxc.config.json`)
- `ctxc.outputDir` (default: `.ctxc/out`)

## Dev
- `npm i`
- `npm run build`
- Press `F5` to launch Extension Development Host.
