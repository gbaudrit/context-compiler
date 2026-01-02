# Pipeline Examples (Ultra)

## Example: Excel file with multi-extract
1. FileReader reads bytes once.
2. Excel DataReader loads workbook and produces CompositeDataEnvelope with parts:
   - extract:kpi_fr ...
   - extract:kpi_eu ...
3. Engineering modules run per part (if applicable).
4. Guards inspect part content; may redact.
5. Transcoder produces fragments with locators including extractId.
6. Evidence IDs assigned from (path|locator) and (path|locator|content).

## Example: Global prompt build
- Views computed from IR (no mutation).
- Global Context (project/objectives/constraints) inserted.
- Personas overlay appended/prepended according to config.
- Template wraps into prompt.context.md.
