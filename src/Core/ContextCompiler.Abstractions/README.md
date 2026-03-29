# ContextCompiler.Abstractions

**ContextCompiler.Abstractions** defines the core contracts of the ContextCompiler (CTXC) runtime.

It provides the fundamental abstractions for the compilation pipeline, the Reasoning IR, and the Evidence system.

This package is **not intended for module implementation**.

---

## 🎯 Purpose

This package defines the **core model and contracts** of CTXC:

- Reasoning IR structure
- Evidence system (EK / ER)
- Pipeline concepts
- Core processing contracts

It represents the **internal language of the compiler**.

---

## 🧩 What’s inside

- Reasoning IR models
- Evidence identifiers and contracts
- Core pipeline abstractions
- Context representation
- Deterministic processing contracts

---

## ⚠️ Important

👉 This package is **NOT** intended to build modules.

Modules should instead depend on:

```bash
ContextCompiler.Modules.Abstractions
```

## License

Licensed under the Apache License 2.0. See LICENSE.txt.

© 2026 Guillaume Baudrit
