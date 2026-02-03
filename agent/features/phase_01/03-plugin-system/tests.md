# Plugin System — Required Tests (Ultra)

## Unit tests
1. Registry rejects duplicate plugin IDs within a kind.
2. Ordering is stable by (Kind, Priority, Id).
3. Selection chooses highest priority, then Id.
4. Missing handler produces a deterministic error.

## Integration tests
5. Built-in plugin set loads and runs end-to-end for fixtures.

## (Phase 2 future) runtime load tests
6. Given a lockfile, loader resolves exact versions and loads plugins.
7. Loader refuses plugins with incompatible API version.
