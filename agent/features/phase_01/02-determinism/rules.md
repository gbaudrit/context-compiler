# Determinism — Practical Rules (Ultra)

## Path normalization
- Convert to workspace-relative if possible.
- Replace backslashes with forward slashes in artifacts.
- Remove redundant segments (./, ../) if resolved safely.

## Stable sorts (recommended keys)
- Files: `relativePath` (ordinal)
- Plugins: `(kind, priority, id)` (ordinal for strings)
- Fragments: `(source.path, source.locator, evidenceKey)`
- Views: `(viewId)`
- Guard findings: `(severity desc, guardId, source.path, source.locator)`

## Stable chunking
If chunking rows/fragments:
- define chunk size deterministically
- define chunk id numbering from 1..N in stable order
