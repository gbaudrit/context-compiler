# Pipelines (Agent-Ultra)

## A) Global Pipeline

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

## B) Input Ingestion Pipeline (per input item, inside Global Pipeline.InputIngestion)

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

## C) Determinism notes

- Any unordered collection must be sorted (string ordinal)
- Hashing uses stable normalization
- JSON uses consistent serialization options (WriteIndented true, stable property ordering when possible)

