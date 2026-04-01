# Architecture (Agent-Ultra)

## 1) Modèle compilateur

Entrée (dossier)
→ (A) Global Pipeline
→ (B) étape Documents
→ (C) Document Pipeline (par document)
→ (D) Reasoning IR (canonique)
→ Artefacts

## 1.1) Building blocks

- **Module** = une capacit� atomique branch�e dans un pipeline
- **Pack** = un regroupement coh�rent de modules pr�ts � l'emploi
- **Pipeline** = la cin�matique d'ex�cution et de transformation des donn�es
- **Blueprint** = un assemblage orient� use case de packs, modules et pipeline

En pratique, ContextCompiler assemble des modules en packs, ex�cute ces capacit�s dans un pipeline d�terministe, puis produit une solution exploitable via un blueprint.


## 2) Couches

### Abstractions
- Contrats purs : modèles, ports, interfaces modules
- Aucune dépendance IO
- Surface stable versionnée (PluginApiVersion)

### Core
- Pipeline global + pipeline document imbriqué
- Reasoning IR
- Evidence system
- Orchestration (deterministic ordering)
- Mécanismes: sorting stable, budgets, aggregation

### Infrastructure
- IFileSystem (PhysicalFileSystem)
- IHasher (sha256 + simhash)
- Module discovery/loading (Phase 1: assemblies; Phase 2: NuGet + ALC)
- Serialization / artifact writing

### Modules
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
- Modules stateless (pas d’état global)
- Tout ordering explicite (priority + stable sort)
- Les guards ne doivent jamais être “silencieux”
- Outputs déterministes (snapshots testables)

## 4) Testing philosophy

- Unit tests sur pipelines (mock IFileSystem/IPluginRegistry)
- Golden tests sur outputs d’un dossier fixture
- Snapshot tests sur JSON/MD
- MSTest + Moq + FluentAssertions

