# ContextCompiler

**ContextCompiler (CTXC)** is a deterministic, pre-LLM compilation engine that transforms heterogeneous inputs into structured, auditable context artifacts.

It provides a modular pipeline to build, analyze, and export context for downstream systems such as LLMs, search, or automation — without invoking any AI model during compilation.

---

## 🚀 Overview

ContextCompiler compiles input data (files, directories, repositories) into a canonical **Compiled Context** enriched with an **Evidence system**, then produces deterministic outputs such as:

* Context prompts
* Evidence indexes
* Evidence graphs
* Reports and diagnostics

The system is designed to be:

* **Deterministic** → same input, same output
* **Traceable** → every output is backed by evidence
* **Modular** → extensible through modules
* **Pre-LLM** → no AI calls during compilation

---

## 🧩 Architecture

ContextCompiler is structured as a layered system:

ContextCompiler (this package)
↓
ContextCompiler.Core
↓
ContextCompiler.Abstractions

Modules integrate through:

ContextCompiler.Modules.Abstractions
↓
ContextCompiler.Modules.*

---

## 📦 Installation

dotnet add package ContextCompiler

---

## ⚡ Quick start

using ContextCompiler;

var compiler = ContextCompilerBuilder
.Create()
.AddDefaultModules()
.Build();

await compiler.RunAsync("input-directory");

---

## 🧠 Core concepts

### Compiled Context

A canonical, immutable representation of the compiled context.

---

### Evidence system

Each fragment is identified by:

* **EK (EvidenceKey)** → stable identifier
* **ER (EvidenceRevision)** → content-based revision

---

### Context Views

Deterministic projections of the Compiled Context for specific purposes:

* risk
* spec
* changes

---

### Artifacts

Typical outputs:

* prompt.context.md
* evidence.index.json
* evidence.graph.json
* security.report.md
* context.health.json

---

## 🔌 Modules

ContextCompiler is extended through **modules**.

Modules are built against:

ContextCompiler.Modules.Abstractions

Examples of module types:

* Readers
* Transcoders
* Guards
* Views
* Templates
* Exporters

---

## 🛠 CLI

A command-line interface is available via:

dotnet tool install -g ContextCompiler.Cli

Usage:

ctxc compile ./input

---

## 🔢 Versioning

ContextCompiler follows Semantic Versioning:

* 0.1.0-alpha.1
* 0.1.0-preview.1
* 0.1.0-rc.1
* 1.0.0

For NuGet packages:

* avoid +build metadata
* use suffix-based builds if needed

Example:

0.1.0-preview.1.123

---

## 🔗 Related packages

* ContextCompiler.Abstractions → core contracts (Compiled Context, evidence, pipeline)
* ContextCompiler.Modules.Abstractions → module contracts
* ContextCompiler.Core → runtime engine
* ContextCompiler.Modules.* → module implementations

---

## 📄 License

Licensed under the Apache License 2.0. See LICENSE.txt.

© 2026 Guillaume Baudrit

