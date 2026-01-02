# Determinism — Required Tests (Ultra)

## Unit tests
1. Sorting: unordered input collections produce identical ordered outputs.
2. Hashing: same content produces same digest across platforms.
3. Serialization: JSON outputs for same object are byte-identical.

## Integration tests
4. Compile the same fixture folder twice → identical output folder.
5. Compile after a no-op file touch (timestamp changed) → identical outputs.

## Regression checks
6. Add an extra plugin with no effect → output remains deterministic (except plugin listing artifacts if any).
