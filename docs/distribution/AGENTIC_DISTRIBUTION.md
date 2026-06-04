# Agentic-first Distribution

> 🌐 <https://contextcompiler.io>

Pour les agents, pipelines et environnements non-GUI, le setup graphique ne doit pas être le canal principal.

```text
Agent / CI / scripts   → ZIP / TAR portable
Infra                  → Docker Hub
GitHub CI              → GitHub Action
Windows automation     → install.ps1
Linux/macOS automation → install.sh
```

## Portable

Windows :

```powershell
irm https://raw.githubusercontent.com/gbaudrit/context-compiler/main/scripts/install.ps1 | iex
```

Linux/macOS :

```bash
curl -fsSL https://raw.githubusercontent.com/gbaudrit/context-compiler/main/scripts/install.sh | bash
```

## Docker

```bash
docker run --rm -v "$PWD:/workspace" contextcompiler/contextcompiler:latest compile /workspace
```

## GitHub Action

```yaml
- uses: gbaudrit/context-compiler/action@v1
  with:
	args: compile ./context
```
