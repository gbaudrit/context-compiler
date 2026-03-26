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

Defines the authoritative relationship between:
- the **Global Pipeline** (once per compilation)
- the **Documents** global stage
- the nested **Document Pipeline** (per document)

and the *invariant boundaries* between stages.

---

## 3. Pipeline Overview (Authoritative)

### 3.1 Global Pipeline (once)
Input: rootPath + config + loaded modules

Stages (fixed order):
1. Configuration
2. Documents
3. FileReader
4. EngineeringModule
5. Transcoder
6. FragmentProcessor
7. Guard
8. PromptComposer
9. View
10. Persona
11. Validation
12. Compression
13. GraphExporter
14. Output
15. OutputArtifactComposer
16. Template
17. OutputWriter
18. PromptRenderer

### 3.2 Document Pipeline (inside Global Pipeline.Documents)
Input: (rootPath, filePath, config)

Stages (fixed order):
1. StartProcess
2. Discovery
3. ReadScopeGuards
4. FileRead
5. DataRead
6. DataPart
7. Engineering
8. Fragment
9. ContentGuards
10. TranscodeFragment
11. EvidenceAssign
12. Preflight
13. EndProcess

Output: fragments + findings, then load into Reasoning IR from the Documents global stage

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
