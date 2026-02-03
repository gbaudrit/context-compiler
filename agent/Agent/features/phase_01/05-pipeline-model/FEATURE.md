# Feature: Pipeline Model (Document + Global) (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26

This feature defines the *compiler pipeline* model. It is foundational: every other feature must locate itself in this pipeline.

---

## 1. Why this feature exists

Without an explicit pipeline model:
- responsibilities blur (e.g., Excel extraction vs transcoding)
- safety checks are applied inconsistently
- artifact generation becomes ad-hoc
- agents cannot generate correct code

---

## 2. Problem it solves

Defines two pipelines:
- **Document Pipeline** (per file)
- **Global Pipeline** (once per compilation)

and the *invariant boundaries* between stages.

---

## 3. Pipeline Overview (Authoritative)

### 3.1 Document Pipeline (per file)
Input: (rootPath, filePath, config)

Stages (fixed order):
1. Discovery / enumeration (sorted)
2. Read-scope guards (path allow/deny)
3. FileReader (bytes)
4. DataReader (typed envelope)
5. Engineering Modules (envelope transforms)
6. Fragment Guards (content safety; can redact/quarantine/block)
7. Transcoding (envelope → IR fragments)
8. Evidence assignment (EK/ER + stable locators)
Output: fragments + findings

### 3.2 Global Pipeline (once)
Input: all fragments + findings + config

Stages (fixed order):
1. IR assembly & invariant validation
2. Views generation
3. Global Context injection (named schema)
4. Personas application
5. Template/framing assembly
6. Budgeting / compression (deterministic)
7. Graph build
8. Reports (security/health)
9. Preflight guards (final prompt checks)
10. Artifact emission

Output: artifact set in output folder

---

## 4. Stage Contracts

### FileReader
- Input: file path
- Output: bytes + basic metadata
- MUST NOT parse structure

### DataReader
- Input: bytes + metadata + config
- Output: typed DataEnvelope (or Composite for multi-part)
- SHOULD avoid producing huge raw dumps if config exists

### Engineering Modules
- Input: DataEnvelope
- Output: DataEnvelope
- MUST be deterministic and ordered

### Transcoding
- Input: (envelope, source locators)
- Output: IR fragments
- MUST preserve traceability

### Global Context / Personas / Templates
- Operate on global framing only
- MUST NOT mutate fragments

### Guards
- Operate at defined stages
- Actions: Warn/Skip/Redact/Quarantine/Block
- Critical+Block => stop

---

## 5. MUST / MUST NOT

### MUST
- Keep stage boundaries strict.
- Keep ordering fixed.
- Always run critical guards even if debug.

### MUST NOT
- Move logic across boundaries (e.g., transcoding inside DataReader).
- Allow “optional ordering”.
