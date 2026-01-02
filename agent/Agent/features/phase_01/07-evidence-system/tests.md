# Evidence System — Required Tests (Ultra)

## Unit tests
1. EK stable for same (path, locator) regardless of content.
2. ER changes when content changes.
3. ER stable when content unchanged.
4. Evidence index JSON is deterministic (byte-identical).

## Integration tests
5. Compile fixture folder -> evidence.index.json contains all fragments.
6. Diff between two runs detects only changed ER when content changes.
