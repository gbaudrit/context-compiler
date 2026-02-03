# Configuration System — Required Tests (Ultra)

## Unit tests
1. Missing config file -> defaults applied, no crash.
2. Invalid JSON -> exit code 1 with clear error.
3. Schema invalid -> exit code 1 with clear error.
4. CLI --config overrides default location.

## Integration tests
5. Fixture repo with config -> compile produces expected artifacts (golden tests).
