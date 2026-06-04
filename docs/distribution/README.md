# ContextCompiler Distribution Pack

Pack complet de distribution pour [ContextCompiler](https://contextcompiler.io).

> 🌐 Site officiel : <https://contextcompiler.io>
> 📦 Code source : <https://github.com/gbaudrit/context-compiler>

## Cibles couvertes

| Public | Canal |
|---|---|
| Non-tech | Inno Setup `.exe` |
| Windows dev | Chocolatey / WinGet |
| Agentic / CI | ZIP portable |
| Infra | Docker Hub (`contextcompiler/contextcompiler`) |
| GitHub CI | GitHub Action réutilisable |
| Script install | Bash / PowerShell |

## Release

```bash
git tag v0.1.0
git push origin v0.1.0
```

Le workflow publie :

- `ctxc-win-x64.zip`
- `ctxc-linux-x64.tar.gz`
- `ctxc-osx-x64.tar.gz`
- `ctxc-osx-arm64.tar.gz`
- `ContextCompiler-Setup-<version>.exe`
- `checksums.txt`
- image Docker Hub `contextcompiler/contextcompiler:<tag>`

## Secrets GitHub requis

| Secret | Usage | Obligatoire ? |
|---|---|---|
| `GITHUB_TOKEN` | Release + GHCR (auto) | Auto |
| `DOCKERHUB_USERNAME` | Login Docker Hub | Oui (workflow `container`) |
| `DOCKERHUB_TOKEN` | Login Docker Hub | Oui (workflow `container`) |
| `SIGNING_CERTIFICATE_BASE64` | Signature `.exe` | Optionnel |
| `SIGNING_CERTIFICATE_PASSWORD` | Signature `.exe` | Optionnel |
| `CHOCO_API_KEY` | Push Chocolatey | Optionnel (commenté) |
