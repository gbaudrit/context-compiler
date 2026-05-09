# Architecture (Agent-Ultra)

## 1) ModÃ¨le compilateur

EntrÃ©e (dossier)
â†’ (A) Global Pipeline
â†’ (B) Ã©tape Documents
â†’ (C) Input Ingestion Pipeline (par input item)
â†’ (D) Compiled Context (canonique)
â†’ Artefacts

## 1.1) Building blocks

- **Module** = une capacité atomique branchée dans un pipeline
- **Pack** = un regroupement cohérent de modules prêts à l'emploi
- **Pipeline** = la cinématique d'exécution et de transformation des données
- **Blueprint** = un assemblage orienté use case de packs, modules et pipeline

En pratique, ContextCompiler assemble des modules en packs, exécute ces capacités dans un pipeline déterministe, puis produit une solution exploitable via un blueprint.


## 2) Couches

### Abstractions
- Contrats purs : modÃ¨les, ports, interfaces modules
- Aucune dÃ©pendance IO
- Surface stable versionnÃ©e (PluginApiVersion)

### Core
- Pipeline global + pipeline input ingestion imbriquÃ©
- Compiled Context
- Evidence system
- Orchestration (deterministic ordering)
- MÃ©canismes: sorting stable, budgets, aggregation

### Infrastructure
- IFileSystem (PhysicalFileSystem)
- IHasher (sha256 + simhash)
- Module discovery/loading (Phase 1: assemblies; Phase 2: NuGet + ALC)
- Serialization / artifact writing

### Modules
- FileReaders (type fichier)
- DataReaders (shape de donnÃ©es)
- EngineeringModules (nettoyage, normalisation, enrichissement)
- Transcoders (DataEnvelope â†’ fragments du contexte compilé)
- Guards (sÃ©curitÃ©)
- Views (projections)
- Templates (framing)
- GraphExporters (dot/mermaid/json)

### Hosts
- CLI `ctxc` : interface scriptable canonique
- MCP host : interface agent IDE (Copilot)

## 3) Invariants architecturaux

- Core ne doit pas connaÃ®tre le filesystem concret
- Modules stateless (pas dâ€™Ã©tat global)
- Tout ordering explicite (priority + stable sort)
- Les guards ne doivent jamais Ãªtre â€œsilencieuxâ€
- Outputs dÃ©terministes (snapshots testables)

## 4) Testing philosophy

- Unit tests sur pipelines (mock IFileSystem/IPluginRegistry)
- Golden tests sur outputs dâ€™un dossier fixture
- Snapshot tests sur JSON/MD
- MSTest + Moq + FluentAssertions


