# Distribution Strategy

> 🌐 <https://contextcompiler.io>

## Non-tech

Installer Inno Setup :

```text
ContextCompiler-Setup.exe
```

## Windows dev

```powershell
choco install contextcompiler
winget install ContextCompiler.ContextCompiler
```

## Agentic / CI

```bash
curl -L https://github.com/gbaudrit/context-compiler/releases/latest/download/ctxc-linux-x64.tar.gz | tar xz
./ctxc compile
```

## Infra

```bash
docker run --rm contextcompiler/contextcompiler:latest --version
```
