# CLI — Required Tests (Ultra)

## Unit tests
1. Argument parsing validates required options.
2. Default config path resolution is correct.
3. Exit code mapping correct for:
   - success
   - invariant/config error
   - guard block
4. Deterministic stdout for list commands (views/plugins).

## Integration tests
5. compile produces required artifacts for fixture folder.
6. diff output deterministic across runs.
