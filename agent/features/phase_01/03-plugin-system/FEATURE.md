# Feature: Plugin System (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26

The system is **100% plugin-modular**. All behaviors beyond the minimal orchestration belong in plugins.

---

## 1. Why this feature exists

Without plugins:
- the core becomes monolithic and hard to test
- support for new formats requires core changes
- teams cannot extend functionality independently
- IDE agent integrations become brittle

---

## 2. Problem it solves

Enables:
- format extensibility (FileReaders/DataReaders)
- data normalization passes (Engineering Modules)
- safety enforcement (Guards)
- context projection (Views)
- framing overlays (Personas)
- output conversions (Graph exporters)

---

## 3. Alternatives rejected

### A) “One giant module”
Rejected: untestable and not evolvable.

### B) “Reflection everywhere without contracts”
Rejected: unsafe, brittle, not mockable.

### C) “LLM chooses plugins”
Rejected: pre-LLM requirement.

---

## 4. Scope

### Plugin kinds (validated)
- FileReader plugin
- DataReader plugin
- EngineeringModule plugin
- Transcoder plugin
- Guard plugin
- View plugin
- Template plugin
- Persona plugin
- Exporter plugin (graph/coverage)

---

## 5. Contracts (high-level)

All plugins:
- have an Id (string)
- have a Kind
- have a Priority (int) used for deterministic ordering
- are stateless (no global mutable state)
- must be safe to instantiate multiple times

---

## 6. Discovery & Loading

### Phase 1 (baseline)
- Discover plugins from referenced assemblies (built-in set).
- Register in a PluginRegistry.

### Phase 2 (validated design, not required immediately)
- Load plugin packages via NuGet into a dedicated folder (e.g., `.ctxboost/plugins`)
- Use AssemblyLoadContext isolation
- Maintain `plugins.lock.json`

---

## 7. MUST / MUST NOT

### MUST
- Sort plugins deterministically before execution.
- Fail with a clear error if no plugin can handle a required file type.
- Keep plugin interfaces minimal and stable.

### MUST NOT
- Allow plugins to call LLMs.
- Allow plugin ordering to depend on discovery order.
- Let plugins depend on each other directly (no plugin-to-plugin compile-time coupling).

---

## 8. Examples

### Example: selecting a FileReader
- By extension/magic bytes/media type.
- If multiple candidates, choose highest priority, then id.

### Example: Engineering pipeline
- Modules applied in ascending priority.
- Each produces a new DataEnvelope.
