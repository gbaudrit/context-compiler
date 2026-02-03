# Feature: Guards (Multi-Stage Safety) (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Pipeline:** Document Pipeline stages 2 & 6, Global Pipeline stage 9 (preflight)

Guards are deterministic safety checks that protect downstream LLM usage and protect the compiler itself
from unsafe, irrelevant, or policy-violating data.

Guards can:
- warn
- skip
- redact
- quarantine
- block (hard stop)

Guards are plugin-driven and must be executed at defined stages.

---

## 1. Why this feature exists
Input data can contain:
- secrets
- prompt injection instructions
- huge irrelevant dumps
- disallowed content (policy)
- malformed / ambiguous structures

Without guards:
- the compiled prompt can become unsafe
- traceability is compromised by hidden data
- IDE agents may expose secrets

Guards are the compiler’s “safety gates”.

---

## 2. Problem it solves
- Detect and handle unsafe or policy-violating content deterministically.
- Enforce MUST / MUST NOT constraints at ingestion time.
- Provide auditable reports of decisions (what was redacted/skipped and why).

---

## 3. Alternatives rejected
- “Rely on the LLM safety system only”: rejected; you want pre-LLM safety.
- “Only one final scan”: rejected; per-file early blocking reduces risk surface.
- “Heuristic and best-effort”: rejected; must be deterministic and auditable.

---

## 4. Guard model (authoritative)

### 4.1 Stages
Guards run at specific stages:

**Document pipeline**
1. **ReadScopeGuard** (stage 2)
   - based on path allow/deny patterns, file size, extension allowlist.
2. **ContentGuard** (stage 6)
   - inspects DataEnvelope content (after engineering modules).
   - can redact/quarantine/block.

**Global pipeline**
3. **PreflightGuard** (stage 9)
   - inspects assembled prompt output & artifacts for policy issues (final check).

### 4.2 Finding + Action
Each guard produces findings:

- `Severity`: Info | Warning | Critical
- `Action`: Allow | Warn | Skip | Redact | Quarantine | Block
- `Message`: deterministic string
- `EvidenceRef`: optional (path + locator + EK if available)

**Hard rule:** `Critical + Block` stops the compilation.

---

## 5. Action semantics (authoritative)

- **Warn**: include finding in report, continue.
- **Skip**: do not emit fragments for that file/part; record evidence placeholder if needed.
- **Redact**: replace sensitive content with deterministic placeholder; preserve EK; ER changes.
- **Quarantine**: write quarantined content to a secure artifact folder (optional) and exclude from prompt; preserve evidence index with sensitivity flag.
- **Block**: stop compilation immediately with exit code 2.

---

## 6. Determinism rules
- Guard execution order: by `(priority asc, guardId ordinal)`
- Findings order: by `(severity desc, guardId, source.path, source.locator)`
- Redaction placeholder must be stable, e.g.:
  `"[REDACTED: <reasonCode>]"`

No timestamps in reports.

---

## 7. MUST / MUST NOT

### MUST
- Execute guards at defined stages.
- Provide deterministic findings and stable ordering.
- Emit `security.report.md` (and optionally `security.report.json`).
- Never bypass Critical+Block.

### MUST NOT
- Use probabilistic detection without deterministic thresholds.
- Call external services or LLMs.
- Allow a debug flag to ignore Critical+Block unless explicitly and safely documented (discouraged).

---

## 8. Examples

### Example: secret found
- Finding: Critical
- Action: Redact (if allowed) or Block (if policy)
- Output fragment content becomes: `[REDACTED: SECRET]`
- EvidenceKey preserved.

### Example: prompt injection pattern
- Finding: Warning or Critical depending on policy.
- Action: Quarantine or Block.

---

## 9. Required tests
See `tests.md`.
