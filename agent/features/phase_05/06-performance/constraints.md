# Performance — Implementation Notes (Ultra)

## Bounded memory recommendations
- Stream large text files line-by-line into fragment builder.
- For tabular data, chunk rows early using fragmenting rules.
- Avoid retaining entire raw workbook representations if not needed after extraction.

## Complexity targets
- File enumeration: O(N log N) due to sorting
- Per-file pipeline: O(size of file)
- View generation: O(#fragments log #fragments)
