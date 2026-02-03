# Guards — Required Tests (Ultra)

## Unit tests
1. Guard ordering is deterministic.
2. Finding ordering is deterministic.
3. Redaction preserves EK and changes ER.
4. Skip prevents fragment emission but records finding.
5. Critical+Block stops pipeline with exit code 2.

## Integration tests
6. Fixture containing a secret triggers expected action and report.
7. Preflight guard catches disallowed output even if earlier stages missed it.
