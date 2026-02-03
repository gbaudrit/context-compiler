# Feature: MCP Server (IDE Tooling) (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Goal:** Expose Context Compiler capabilities to IDE agents (VS Code) via MCP.

This phase targets “Phase 1 integration” you validated:
- ctxc + MCP + VS Code
- Copilot Chat provides UX/prompting
- ctxc provides compiled context artifacts

---

## 1. Why this feature exists
IDE agents need tools. MCP provides a standardized interface for tools over stdio.

MCP allows:
- compile a folder into artifacts
- list artifacts and views
- read artifacts for injection into chat

---

## 2. Problem it solves
- Standard tool protocol for VS Code integrations
- Avoids building a custom IDE extension in Phase 1
- Enables Copilot Chat to consume compiled context indirectly

---

## 3. Tools (authoritative baseline)

### 3.1 `compile_context`
Input:
- `inputPath`
- `outputPath`
- `configPath` (optional)

Output:
- success flag
- exit code
- artifacts list (paths)

### 3.2 `list_artifacts`
Input:
- `outputPath`
Output:
- artifacts list (stable order)

### 3.3 `read_artifact`
Input:
- `outputPath`
- `artifactPath`
Output:
- file content (string) + mime type

### 3.4 `list_views`
Input:
- `outputPath`
Output:
- list of view IDs

### 3.5 `read_view`
Input:
- `outputPath`
- `viewId`
Output:
- view content (md)

---

## 4. Transport & determinism
- MCP server runs over stdio.
- All returned lists sorted deterministically.
- No timestamps.

---

## 5. MUST / MUST NOT

### MUST
- Never execute LLM calls.
- Only operate on filesystem paths provided.
- Validate paths and prevent traversal outside workspace if configured.

### MUST NOT
- Write outside output folder.
- Leak quarantined artifacts unless explicitly requested and safe.

---

## 6. Required tests
See `tests.md`.
