# Architecture (Agent-Ultra)

## 1) Modele compilateur

Entree (dossier)
-> (A) Analyze Pipeline
-> (B) restore modules prepare
-> (C) Prepare Pipeline
-> (D) restore modules compile
-> (E) Compile / Global Pipeline
-> (F) Input Ingestion Pipeline (par input item)
-> (G) Compiled Context (canonique)
-> Artefacts

## 1.1) Building blocks

- **Module** = une capacite atomique branchee dans un pipeline
- **Module scope** = ensemble de packages executables restaures a un moment donne (`prepare`, `compile`, `all`)
- **Pack** = un regroupement coherent de modules prets a l'emploi
- **Pipeline** = la cinematique d'execution et de transformation des donnees
- **Analyze** = phase core legere de detection et recommandation de modules
- **Prepare** = phase d'execution des modules prepare restaures apres Analyze
- **Blueprint** = un assemblage oriente use case de packs, modules et pipeline

En pratique, ContextCompiler assemble des modules en packs, execute ces capacites dans un pipeline deterministe, puis produit une solution exploitable via un blueprint.

## 2) Couches

### Abstractions
- Contrats purs : modeles, ports, interfaces modules
- Aucune dependance IO
- Surface stable versionnee (PluginApiVersion)

### Core
- Analyze Pipeline
- Prepare Pipeline
- Compile / Global Pipeline + pipeline input ingestion imbrique
- Compiled Context
- Evidence system
- Orchestration (deterministic ordering)
- Mecanismes: sorting stable, budgets, aggregation

### Infrastructure
- IFileSystem (PhysicalFileSystem)
- IHasher (sha256 + simhash)
- Module discovery/loading (NuGet + ALC)
- Module restore, version resolution, scoped lock/load
- Serialization / artifact writing

### Modules
- Analyze modules (core only, lightweight detection)
- Prepare modules (technology-specific project analysis before compile)
- FileReaders (type fichier)
- DataReaders (shape de donnees)
- EngineeringModules (nettoyage, normalisation, enrichissement)
- Transcoders (DataEnvelope -> fragments du contexte compile)
- Guards (securite)
- Views (projections)
- Templates (framing)
- GraphExporters (dot/mermaid/json)

### Hosts
- CLI `ctxc` : interface scriptable canonique
- MCP host : interface agent IDE (Copilot)

## 3) Invariants architecturaux

- Core ne doit pas connaitre le filesystem concret
- Modules stateless (pas d'etat global)
- Tout ordering explicite (priority + stable sort)
- `Analyze` doit recommander, pas embarquer l'analyse specialisee profonde
- Les modules executables sont separes par scope `prepare` et `compile`
- La source locale canonique est `@local`
- Les guards ne doivent jamais etre silencieux
- Outputs deterministes (snapshots testables)

## 4) Testing philosophy

- Unit tests sur pipelines (mock IFileSystem/IPluginRegistry)
- Golden tests sur outputs d'un dossier fixture
- Snapshot tests sur JSON/MD
- MSTest + Moq + FluentAssertions
