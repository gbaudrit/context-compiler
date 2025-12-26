# Feature: Security Guards (Secrets / Injection / PII) (Ultra)

**Status:** Authoritative  
**Date:** 2025-12-26  
**Builds on:** Guards feature  
**Purpose:** Provide concrete guard implementations and policies for security-related risks.

---

## 1. Why this feature exists
The most immediate real-world risk is leaking secrets through compiled context
and feeding prompt injections into an agent.

Security Guards detect:
- secrets (API keys, tokens, private keys)
- prompt injection phrases / tool hijacking
- PII patterns (optional baseline)

---

## 2. Problem it solves
- Prevents accidental secret leakage into `prompt.context.md`
- Reduces risk when IDE agents share context with remote models
- Provides structured reporting

---

## 3. Detection strategies (deterministic baseline)

### 3.1 Secrets detection
- Regex-based detectors (deterministic)
- Entropy heuristics are allowed only if thresholds are fixed and documented
- Known formats:
  - AWS keys
  - GitHub tokens
  - JWT-like tokens (pattern-based)
  - Private key blocks

### 3.2 Prompt injection detection
Detect patterns such as:
- "ignore previous instructions"
- "system prompt"
- "do not follow"
- "exfiltrate"
- "tool call"

Must be deterministic pattern matching, not ML inference.

### 3.3 PII detection (optional baseline)
- Email addresses
- Phone numbers
- Credit card patterns (Luhn optional but deterministic)
Policy may default to Warn.

---

## 4. Actions (policy baseline)

Recommended baseline:
- Secrets: **Redact** (or **Block** if configured as strict)
- Private key blocks: **Block** by default
- Injection patterns: **Quarantine** or **Block** depending on severity
- PII: **Warn** (unless strict mode)

Policy must be configurable (future); baseline behavior must be documented.

---

## 5. Output (artifacts)

- `security.report.md` (human)
- `security.report.json` (machine)
- optional: `quarantine/` folder with quarantined fragments (encrypted optional future)

Reports must include:
- finding id
- guard id
- severity
- action
- source path + locator
- EK if known

---

## 6. MUST / MUST NOT

### MUST
- Never emit raw secrets to prompt output.
- Preserve evidence traceability even when redacted.
- Provide deterministic match results.

### MUST NOT
- Use network calls to classify content.
- Use non-deterministic entropy scoring without fixed thresholds.
