# Context Views — Required Tests (Ultra)

## Unit tests
1. Views do not mutate IR (IR hash remains same).
2. Selector filtering is deterministic.
3. Ordering uses stable keys and produces identical order across runs.
4. View output includes EK for every referenced fragment.

## Integration tests
5. Compile fixture -> emits expected view artifacts (golden).
