# ContextCompiler.Modules.Abstractions

**ContextCompiler.Modules.Abstractions** defines the public contracts used to build **modules** for the ContextCompiler (CTXC) ecosystem.

It provides the interfaces, models, and extension points required to implement compatible modules without depending on the internal runtime implementation.

---

## Purpose

This package is the foundation of the **CTXC module system**.

It allows developers to:

* Build custom CTXC modules
* Integrate with the compilation pipeline
* Exchange data through module contracts
* Produce deterministic outputs in a consistent way

---

## What’s inside

This package typically contains:

* Core module interfaces
* Module descriptors and metadata
* Module execution contracts
* Module context abstractions
* Shared capability contracts for official and third-party modules

Examples of module categories include:

* Readers
* Transcoders
* Guards
* Views
* Templates
* Exporters

---

## Usage

Modules should depend on this package:

dotnet add package ContextCompiler.Modules.Abstractions

Example:

using System.Threading;
using System.Threading.Tasks;
using ContextCompiler.Modules.Abstractions;

public sealed class MyModule : IContextModule
{
public IModuleDescriptor Descriptor { get; } =
new ModuleDescriptor(
id: "my-module",
name: "My Module",
version: "0.1.0");

```
public Task<ModuleExecutionResult> ExecuteAsync(
    IModuleContext context,
    CancellationToken cancellationToken = default)
{
    return Task.FromResult(ModuleExecutionResult.Success());
}
```

}

---

## Design principles

* **Module-first**
* **No runtime coupling**
* **Deterministic-friendly**
* **Stable public contracts**
* **Clear compatibility boundaries**

---

## Relationship with other packages

* ContextCompiler.Abstractions → core contracts for the compiler runtime
* ContextCompiler.Core → runtime engine and orchestration
* ContextCompiler → public facade package
* ContextCompiler.Modules.* → concrete module implementations

### Important

ContextCompiler.Abstractions is intended for the **core compiler model**.
ContextCompiler.Modules.Abstractions is intended for **module authors**.

Modules should primarily depend on:

ContextCompiler.Modules.Abstractions

and not directly on ContextCompiler.Core.

---

## Compatibility

The major version of ContextCompiler.Modules.Abstractions defines the compatibility contract for modules.

General rule:

* modules built against the same major version should remain compatible
* breaking changes require a new major version

Example:

* modules targeting ContextCompiler.Modules.Abstractions 1.x should work together
* incompatible contract changes require 2.0.0

---

## Versioning

This package follows Semantic Versioning with prerelease labels such as:

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

## Recommended package naming

Official modules typically follow this naming convention:

ContextCompiler.Modules.<Area>
ContextCompiler.Modules.<Area>.<Feature>

Examples:

ContextCompiler.Modules.Community
ContextCompiler.Modules.Community.Contrib
ContextCompiler.Modules.Security
ContextCompiler.Modules.Export

---

## License

Licensed under the Apache License 2.0. See LICENSE.txt.

© 2026 Guillaume Baudrit
