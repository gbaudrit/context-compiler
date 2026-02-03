# Pipelines (Agent-Ultra)

## A) Document Pipeline (per-file)

### Input
- rootPath
- filePath

### Stages (ordonnées)
1. **Discovery**
   - enumerate candidates
   - ignore patterns (.git, .ctxboost, bin/obj)
2. **Read scope guards**
   - action: Skip/Block si violation
3. **FileReader selection**
   - by extension/mime/signature
   - output: DocumentContent (bytes + optional text + metadata)
4. **DataReader selection**
   - by content/media/heuristics
   - output: DataEnvelope (shape + payload)
5. **Engineering modules**
   - deterministic list ordered by priority
   - output: transformed DataEnvelope
6. **Fragment guards**
   - injection, sensitivity, policy checks
   - action can Redact/Quarantine/Block
7. **Transcoding**
   - DataEnvelope → TranscodedFragments (locator+content+tags)
8. **Evidence assignment**
   - EK: stable key from (sourcePath|locator)
   - ER: content revision from (sourcePath|locator|contentHash)

### Output
- list of Fragments
- list of GuardFindings

---

## B) Global Pipeline (once)

### Input
- Reasoning IR (all fragments)
- Findings aggregated
- CompileOptions (budget, etc.)

### Stages (ordonnées)
1. **IR assembly**
   - enforce invariants
   - stable ordering
2. **Views build**
   - for each IViewPlugin
   - output: ViewResult (markdown)
3. **Template application**
   - apply single chosen template (priority)
4. **Compression**
   - enforce budget (max-chars) deterministically
5. **Graph build**
   - nodes: evidence, sources (option: views)
6. **Reports**
   - security.report.md
   - context.health.json
7. **Preflight guards**
   - validate final prompt for agent usage
8. **Artifacts emission**
   - write all outputs to output folder

---

## C) Determinism notes

- Any unordered collection must be sorted (string ordinal)
- Hashing uses stable normalization
- JSON uses consistent serialization options (WriteIndented true, stable property ordering when possible)
