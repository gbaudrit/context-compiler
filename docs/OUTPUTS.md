# Outputs (Agent-Ultra)

## 1) Core artifacts (always emitted)
- `prompt.context.md` : framing + compiled views
- `evidence.index.json` : evidence mapping
- `reasoning.graph.json` : graph model
- `security.report.md` : guard findings
- `context.health.json` : health metrics

## 2) Conditional artifacts
- `preflight.report.md` : preflight findings exist
- `view.<id>.md` : per-view markdown output
- `reasoning.graph.dot` : exporter plugin enabled
- `diff.context.md` : produced by `ctxc diff`
- `context.explain.md` : produced by `ctxc explain`

## 3) Output folder layout recommendation
`<output>/` contains only generated files (safe to delete).
No inputs are modified.
