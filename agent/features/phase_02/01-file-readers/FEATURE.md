# Feature: File Readers (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Document Pipeline stage `FileRead`

---

## 1. Why this feature exists
The compiler must support heterogeneous file formats. The first boundary is **bytes acquisition**.
FileReader plugins ensure:
- uniform ingestion of bytes
- strict separation from parsing
- deterministic metadata capture (size, hash if needed)

Without this boundary, parsing logic leaks into IO, becomes untestable, and violates pipeline separation.

---

## 2. Problem it solves
- Provides a consistent way to read file bytes regardless of format.
- Enables testability by mocking the file system / file reader.
- Prevents format-specific behaviors from creeping into core.

---

## 3. Alternatives rejected
- **Parsing in FileReader**: rejected; violates stage boundaries and determinism auditing.
- **Single built-in reader only**: rejected; plugins must allow future special IO (archives, virtual fs).

---

## 4. Scope

### Does
- Read bytes from a file path.
- Produce `FileContent` (bytes + metadata).
- Normalize path for downstream stages.

### Does NOT
- Parse structured content (no CSV/Excel/JSON parsing).
- Interpret file semantics.
- Call any external service.

---

## 5. Contracts

### Input
- `rootPath`
- `relativePath`
- `ReadOptions` (maxBytes, allowBinary, etc. if configured)

### Output
- `FileContent`:
  - `Path` (normalized relative)
  - `Bytes`
  - `Size`
  - `MediaType` (optional hint; detection can be a separate plugin)
  - `ContentHash` (optional; if computed, must be deterministic)

---

## 6. Deterministic rules
- File discovery order is deterministic (Phase 1 determinism).
- FileReader must not depend on filesystem enumeration order.
- If computing a content hash, it must be SHA-256 and documented.

---

## 7. MUST / MUST NOT

### MUST
- Read bytes once per file per compilation.
- Preserve the exact bytes (no newline normalization here).
- Respect configured max file size; if exceeded, raise a deterministic failure or emit a guard finding (depending on policy).

### MUST NOT
- Attempt to “clean” content.
- Apply encoding decisions.
- Read the same file multiple times unless explicitly allowed for streaming (future).

---

## 8. Failure modes
- Missing file: error with stable message.
- Permission error: error with stable message.
- Oversize file: guard finding + skip or hard error depending on configuration.

---

## 9. Artifacts
FileReader itself emits no artifacts; diagnostics may include per-file read stats in `context.health.json`.

---

## 10. Examples

### Example: basic read
Input: `docs/spec.md`  
Output: `FileContent(Path="docs/spec.md", Bytes=[...], Size=12345)`

---

## 11. Required tests
See `tests.md`.
