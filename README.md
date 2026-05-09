# Context Compiler (`ctxc`)

Compilateur **pré‑LLM** et **déterministe** qui transforme un ensemble d’entrées hétérogènes (répertoires/fichiers) en **artefacts de contexte gouvernés et auditables**.

Le projet est conçu comme un **pipeline de compilation** piloté par **modules** : le **pipeline global** orchestre des groupes de modules ordonnés, et l’étape **Documents** exécute le **pipeline document** pour produire les fragments qui alimentent le **Compiled Context**.

## Objectifs

- Fournir une chaîne **reproductible** : mêmes entrées → mêmes sorties (octet pour octet).
- Préparer le contexte **sans appeler de LLM**.
- Préserver la **traçabilité** (Evidence IDs) et l’auditabilité.
- Permettre l’extensibilité via des modules (readers, transcoders, guards, views, templates, exporters).

## Principes

- **Pré‑LLM uniquement** (aucune requête vers des services externes/LLM)
- **Déterminisme**
- **Compiled Context immuable**
- **Module-first** (toute logique au‑delà de l’orchestration est portée par des modules ordonnés.)
- **Guards** non contournables.

## Système de preuves (Evidence)

Chaque fragment du Compiled Context porte des identifiants de preuve :

- **EK (EvidenceKey)** = `hash(path + locator)` → **stable**
- **ER (EvidenceRevision)** = `hash(path + locator + normalized content)` → change **uniquement** si le contenu change

Ces identifiants doivent être préservés dans les artefacts (vues, index, rapports, etc.).

## Vues de contexte (Context Views)

Une **Context View** est une **projection déterministe** du Compiled Context : elle présente les mêmes preuves sous différents angles (ex. `risk`, `spec`, `changes`) **sans muter le contexte compilé**.

Caractéristiques :

- sélection explicite (selector/filters)
- tri stable (ordering) avec clés explicites (ex. `(score desc, source.path, source.locator, EK)`)
- rendu en artefacts (`view.<id>.md` et/ou `.json`)

## Artefacts produits (contrat)

Artefacts requis :

- `prompt.context.md`
- `evidence.index.json`
- `evidence.graph.json`
- `security.report.md`
- `context.health.json`

Tous les artefacts sont **déterministes**, versionnés et régénérables.

## Architecture (vue d’ensemble)

Modèle compilateur :

Entrée (dossier) → **Global Pipeline**
→ étape **Documents** (contient le **Document Pipeline** par document)
→ enrichissement / composition globale
→ **Compiled Context** + artefacts

Couches :

- `Abstractions` : contrats/ports/interfaces modules (pas d’IO)
- `Core` : pipelines, Compiled Context, evidence system, orchestration déterministe
- `Infrastructure` : filesystem, hashing, discovery/loading modules, sérialisation/écriture d’artefacts
- `Modules` : readers, transcoders, guards, views, templates, exporters
- `Hosts` : CLI `ctxc` et host MCP


## Organisation du dépôt

- `eng/` standards d’ingénierie (packages centraux, props/targets, editorconfig)
- `src/` code produit (Core/Infrastructure/Plugins/Hosts)
- `tests/` suites de tests (MSTest + Moq + FluentAssertions)
- `samples/` dépôts et plugins d’exemple


