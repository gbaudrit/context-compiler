# Testing Strategy — Concrete Checklist (Ultra)

## Determinism
- compile twice -> identical output folder (byte compare)
- touch timestamps -> identical outputs

## Guards
- secret -> redact or block (expected)
- injection -> quarantine or block
- preflight catches final prompt policy issues

## Plugins
- duplicate id rejected
- ordering stable
- runtime loading lock enforced

## Config
- schema validation passes
- invalid config fails with exit code 1
