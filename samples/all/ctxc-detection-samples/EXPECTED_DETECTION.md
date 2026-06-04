# Expected detection summary

- dotnet-webapi: .NET / C# via `.sln`, `.csproj`, `.cs`, `Directory.Build.props`
- node-typescript: Node.js / TypeScript via `package.json`, `tsconfig.json`, `.ts`
- python-fastapi: Python / FastAPI via `pyproject.toml`, `requirements.txt`, `.py`
- java-maven: Java / Maven via `pom.xml`, `.java`
- go-service: Go via `go.mod`, `.go`
- rust-cli: Rust via `Cargo.toml`, `.rs`
- php-composer: PHP / Composer via `composer.json`, `.php`
- infra-docker: Docker / GitHub Actions via `Dockerfile`, `docker-compose.yml`, `.github/workflows/*.yml`
- docs-site: MkDocs / Markdown via `mkdocs.yml`, `docs/*.md`

Suggested default excludes:

- **/bin/**
- **/obj/**
- **/node_modules/**
- **/.venv/**
- **/target/**
- **/.git/**
