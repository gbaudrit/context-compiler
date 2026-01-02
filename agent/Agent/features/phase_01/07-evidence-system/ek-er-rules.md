# Evidence EK/ER — Normalization Rules (Ultra)

## Path normalization
- Workspace-relative
- Forward slashes
- Case handling: preserve original case for display, but use a consistent normalization for hashing (recommend ordinal exact to avoid cross-platform drift; document choice).

## Content normalization for ER
- UTF-8
- `\n` line endings
- Trim trailing whitespace on each line
- Collapse consecutive blank lines only if explicitly configured (default: do not)

## Locator normalization
- ASCII-only where possible
- Escape `|` if needed
- Avoid including dynamic values (timestamps)
