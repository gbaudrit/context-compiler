# Global Context — Required Tests (Ultra)

## Unit tests
1. Fixed rendering order is respected.
2. Missing optional sections -> omitted deterministically.
3. Does not mutate IR.
4. Disabled -> no global context section emitted.

## Integration tests
5. With config example -> prompt.context.md includes Global Context section.
