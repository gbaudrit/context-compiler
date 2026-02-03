# Plugin System — Loading (Phase 1 + Phase 2 design) (Ultra)

## Phase 1: Built-in assembly discovery
- Use DI to register built-in plugin implementations.
- Registry is constructed at startup.
- Ensure deterministic ordering and uniqueness checks.

## Phase 2: NuGet runtime loading (validated design)
### Directory layout
- `.ctxboost/plugins/`
  - `<packageId>/<version>/lib/<tfm>/*.dll`
- `plugins.lock.json` stores resolved versions and hashes

### Safety
- Validate strong-name/signature if required
- Restrict plugin API surface to Abstractions package
- Load with dedicated AssemblyLoadContext
- Prevent dependency conflicts by isolation

### Determinism
- Lock file governs resolution; no floating versions.
- Ordering uses Kind/Priority/Id after load.
