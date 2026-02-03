# Architecture (Agent-Ultra)

## 1) Modèle compilateur

Entrée (dossier)
→ (A) Document Pipeline (par fichier)
→ (B) Reasoning IR (canonique)
→ (C) Global Pipeline
→ Artefacts

## 2) Couches

### Abstractions
- Contrats purs : modèles, ports, interfaces plugins
- Aucune dépendance IO
- Surface stable versionnée (PluginApiVersion)

### Core
- Pipelines (Document + Global)
- Reasoning IR
- Evidence system
- Orchestration (deterministic ordering)
- Mécanismes: sorting stable, budgets, aggregation

### Infrastructure
- IFileSystem (PhysicalFileSystem)
- IHasher (sha256 + simhash)
- Plugin discovery/loading (Phase 1: assemblies; Phase 2: NuGet + ALC)
- Serialization / artifact writing

### Plugins
- FileReaders (type fichier)
- DataReaders (shape de données)
- EngineeringModules (nettoyage, normalisation, enrichissement)
- Transcoders (DataEnvelope → fragments IR)
- Guards (sécurité)
- Views (projections)
- Templates (framing)
- GraphExporters (dot/mermaid/json)

### Hosts
- CLI `ctxc` : interface scriptable canonique
- MCP host : interface agent IDE (Copilot)

## 3) Invariants architecturaux

- Core ne doit pas connaître le filesystem concret
- Plugins stateless (pas d’état global)
- Tout ordering explicite (priority + stable sort)
- Les guards ne doivent jamais être “silencieux”
- Outputs déterministes (snapshots testables)

## 4) Testing philosophy

- Unit tests sur pipelines (mock IFileSystem/IPluginRegistry)
- Golden tests sur outputs d’un dossier fixture
- Snapshot tests sur JSON/MD
- MSTest + Moq + FluentAssertions
