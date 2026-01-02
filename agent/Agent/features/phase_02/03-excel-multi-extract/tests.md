# Excel Multi-Extract — Required Tests (Ultra)

## Unit tests (in-memory workbook)
1. Table extract returns correct columns and rows.
2. Range extract with headerRow returns correct header.
3. Select preserves declared column order.
4. Exclude removes columns deterministically.
5. Rename mapping applies and enforces uniqueness.
6. Where eq/in/contains/gt/lt/gte/lte work deterministically.
7. Extract ordering is by id ordinal.
8. LocatorPrefix includes extractId and structural selector.

## Failure tests
9. Missing sheet -> deterministic error (or warn+skip if configured).
10. Missing table/range -> deterministic error.
11. Select column missing -> deterministic error.
12. Rename duplicates -> deterministic error.

## Integration tests
13. Workbook read once (instrumentation/mocks).
14. CompositeDataEnvelope parts stable across runs.
