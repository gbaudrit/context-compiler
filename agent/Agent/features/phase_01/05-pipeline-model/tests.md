# Pipeline Model — Required Tests (Ultra)

## Unit tests
1. Stage ordering is fixed and enforced.
2. A stage cannot be skipped unless explicitly configured (and still deterministic).

## Integration tests
3. Fixture folder produces expected artifact set.
4. When a per-file guard blocks, global pipeline does not proceed.
