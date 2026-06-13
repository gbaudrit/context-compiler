# Pipelines (Agent-Ultra)

## A) Orchestration CLI

Context Compiler separe les phases qui determinent quoi restaurer de celles qui executent les modules restaures.

### Commandes principales

- `ctxc analyze`
- `ctxc modules restore --scope prepare`
- `ctxc prepare`
- `ctxc modules restore --scope compile`
- `ctxc compile`
- `ctxc autopilot`

### Autopilot

`ctxc autopilot` execute la chaine complete :

```text
Analyze -> restore prepare -> Prepare -> restore compile -> Compile
```

Tous les artefacts intermediaires sont conserves pour audit.

---

## B) Analyze Pipeline

`Analyze` est core et leger. Il ne fait pas d'analyse specialisee profonde ; il detecte la forme du projet et recommande les modules a restaurer.

### Stages (ordonnees)

1. **ProjectInventory**
2. **ProjectClassification**
3. **PrepareModulePlanning**
4. **AnalyzeReport**

### Output

- `.ctxc/prepare/inventory.json`
- `.ctxc/prepare/classification.json`
- `.ctxc/prepare/analyze.plan.json`
- `.ctxc/ctxc.modules.config.json` avec `modules.prepare.packages`

---

## C) Prepare Pipeline

`Prepare` s'execute apres `ctxc modules restore --scope prepare`.
Les modules prepare restaures peuvent produire des analyses specialisees, par exemple `prepare.dotnet.analysis`.

### Output

- `.ctxc/prepare/prepare.plan.json`
- `.ctxc/ctxc.modules.config.json` complete avec `modules.compile.packages`

---

## D) Modules Restore Scopes

`ctxc.modules.config.json` utilise `schemaVersion: 1` et separe les packages executables :

- `modules.prepare.packages` : modules requis avant `Prepare`
- `modules.compile.packages` : modules requis avant `Compile`

`ctxc modules restore --scope prepare` restaure uniquement `prepare`.
`ctxc modules restore --scope compile` restaure uniquement `compile`.
`ctxc modules restore --scope all` restaure les deux scopes.

Les packages peuvent cibler une source avec `<package-id>@<source-id>`. La source locale canonique est `@local`.

Les chemins de `ctxc.modules.config.json` sont relatifs a `StoreKeys.Root`; ils ne doivent pas encoder `.ctxc` en dur. Par exemple `versionOverridesFile: "ctxc.modules.versions.json"` pointe physiquement vers `.ctxc/ctxc.modules.versions.json` avec le store filesystem courant.

Les versions flottantes (`*`, `latest`, `1.2.*`, `0.1.0-alpha.*`) sont resolues vers une version exacte avant telechargement. Les overrides optionnels se trouvent dans `ctxc.modules.versions.json` relatif au root store, avec aussi un override possible a la racine workspace; ils sont charges via la configuration du loader.

---

## E) Compile Pipeline

Le **pipeline global** est la cinématique de référence.  
Il exécute les modules par groupe de `Kind`, ordonnés selon `CompilePipelineModuleKinds`, puis par `Priority` à l’intérieur d’un même groupe.

### Stages (ordonnées)
1. **Configuration**
2. **Input Ingestion**
   - lance le **Input Ingestion Pipeline** pour chaque input item
   - collecte les findings
   - alimente le Compiled Context avec les fragments produits
3. **FileReader**
4. **EngineeringModule**
5. **Transcoder**
6. **FragmentProcessor**
7. **Guard**
8. **PromptComposer**
9. **View**
10. **Persona**
11. **Validation**
12. **Compression**
13. **GraphExporter**
14. **Output**
15. **OutputArtifactComposer**
16. **Template**
17. **OutputWriter**
18. **PromptRenderer**

---

## F) Input Ingestion Pipeline (per input item, inside Global Pipeline.InputIngestion)

### Input
- rootPath
- filePath

### Stages (ordonnées)
1. **StartProcess**
2. **Discovery**
3. **ReadScopeGuards**
4. **FileRead**
5. **DataRead**
6. **DataPart**
7. **Engineering**
8. **Fragment**
9. **ContentGuards**
10. **TranscodeFragment**
11. **EvidenceAssign**
12. **Preflight**
13. **EndProcess**

### Output
- list of Fragments
- list of GuardFindings

---

## G) Determinism notes

- Any unordered collection must be sorted (string ordinal)
- Hashing uses stable normalization
- JSON uses consistent serialization options (WriteIndented true, stable property ordering when possible)
- Floating module versions must be written to the lock file as exact resolved versions before load
