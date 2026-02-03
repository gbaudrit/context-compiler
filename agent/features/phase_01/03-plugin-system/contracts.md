# Plugin System — Contracts (Ultra)

## Common plugin metadata
- `Id: string` (unique)
- `Kind: string` (one of validated kinds)
- `Priority: int` (lower runs earlier unless documented otherwise)
- `Version: string` (semantic)

## Registry responsibilities
- Discover plugins
- Validate uniqueness (no duplicated Id within same kind)
- Provide filtered lists by kind
- Provide deterministic ordering

## Selection logic
Whenever a single plugin must be selected (e.g., FileReader/DataReader/Transcoder):
1. Filter by `CanHandle(...) == true`
2. Order by:
   - priority (asc)
   - id (ordinal)
3. Choose first
4. If none -> error (unless explicitly optional)

## Multi-run logic
Whenever multiple plugins run (e.g., Engineering Modules, Guards):
- run all in deterministic order
- aggregate results in stable order
