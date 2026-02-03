# Data Readers — Required Tests (Ultra)

## Unit tests
1. Deterministic parse for same bytes.
2. Shape is correctly assigned.
3. Unsupported file produces deterministic selection failure.
4. Composite envelopes preserve part ordering by PartId.

## Integration tests
5. End-to-end: FileReader+DataReader produce expected envelope shapes for fixtures.
