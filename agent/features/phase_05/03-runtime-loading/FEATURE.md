# Feature: Runtime Plugin Loading (NuGet) (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Builds on:** Plugin System (Phase 1)  
**Goal:** Load plugins at runtime via NuGet packages in an isolated, deterministic way.

---

## 1. Why this feature exists
Organizations will want to add:
- proprietary readers
- custom guards
- custom views/templates

without modifying the core repo.

Runtime loading makes extension operationally feasible.

---

## 2. Problem it solves
- Plugin delivery via NuGet
- Version pinning via lock file
- Isolation via AssemblyLoadContext
- Deterministic resolution

---

## 3. Layout (authoritative baseline)

Workspace:
- `.ctxboost/plugins/`
- `plugins.lock.json`

`plugins.lock.json` contains:
- packageId
- version
- hash
- entry assembly path
- apiCompatibilityVersion

---

## 4. Resolution rules (deterministic)
- No floating versions
- No “latest”
- Only resolve exact versions declared
- Verify hash matches lock

---

## 5. Isolation rules
- Each plugin package loaded in a dedicated AssemblyLoadContext.
- Plugin dependencies resolved within the package folder first.
- Shared Abstractions assembly must be unified (single identity).

---

## 6. MUST / MUST NOT

### MUST
- Refuse plugin if API compatibility mismatch.
- Refuse plugin if hash mismatch.
- Produce deterministic plugin registry ordering after load.

### MUST NOT
- Load arbitrary assemblies outside plugin folder.
- Allow plugin to override core dependencies.

---

## 7. Required tests
See `tests.md`.
