# Guards (Agent-Ultra)

## 1) Purpose
Guards protect downstream LLM usage by preventing:
- prompt injection
- data exfiltration
- policy violations
- unsafe scope expansion

Guards run deterministically and produce structured findings.

## 2) Guard stages
- Discovery: repo-level checks
- Read: file-level checks (scope, allow/deny)
- Fragment: content-level checks (injection/sensitivity)
- Preflight: final prompt-level checks

## 3) Finding model
- GuardId
- Severity: Info/Warning/Error/Critical
- Action: Warn/Skip/Redact/Quarantine/Block
- Message
- SourceRef

## 4) Enforcement rules
- If any Critical+Block finding exists → compilation exit code 2
- Findings are always emitted to `security.report.md`
- Preflight findings may emit `preflight.report.md`

## 5) Built-in baseline guards
- Scope guard (exclude .git/.ctxboost/bin/obj)
- Prompt injection guard (heuristics/regex)
- Sensitivity guard (emails, tokens)
