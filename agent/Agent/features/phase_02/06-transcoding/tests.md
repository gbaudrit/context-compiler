# Transcoding — Required Tests (Ultra)

## Unit tests
1. Transcoder selection is deterministic.
2. Tabular transcoding yields stable JSON for same input.
3. Fragmenting applied during transcoding yields stable locators.
4. Content normalization is stable across platforms.

## Integration tests
5. End-to-end: Excel extract → transcoding → IR fragments with EK/ER.
