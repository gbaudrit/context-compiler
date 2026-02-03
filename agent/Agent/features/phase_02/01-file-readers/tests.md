# File Readers — Required Tests (Ultra)

## Unit tests
1. Reads bytes exactly and preserves length.
2. Returns normalized relative path.
3. MaxBytes enforcement is deterministic.
4. Errors are deterministic (same message for same condition).

## Integration tests
5. Fixture folder with mixed files produces one FileContent per file, read once.
