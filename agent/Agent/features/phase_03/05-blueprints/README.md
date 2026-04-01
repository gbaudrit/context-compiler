# Blueprints — Quick Reference

**Feature:** Blueprints — Guided Implementation Patterns  
**Status:** Authoritative  
**Pipeline Stage:** `PromptComposer` (priority: 10)  
**Phase:** 3 (Framing Path)

---

## 📋 What are Blueprints?

Blueprints provide **structured, step-by-step guidance** for implementing specific patterns, architectures, and workflows.

They separate **general practices** (handled by Personas) from **specific workflows** (handled by Blueprints).

---

## 🎯 Key characteristics

✅ **Sequential steps** with automatic numbering  
✅ **Step-specific constraints** (MUST/MUST NOT at each stage)  
✅ **Objectives, assumptions, glossary, commands**  
✅ **Reusable NuGet packages**  
✅ **Deterministic rendering** via Scriban templates  
✅ **Separation of concerns** from Personas

---

## 🏗️ Domain model

```
IBlueprint
├── Id, Name, Description
├── Objectives (IObjective[])
├── MustConstraints (IMustConstraint[])
├── MustNotConstraints (IMustNotConstraint[])
├── Assumptions (IAssumption[])
├── Glossary (IGlossaryTerm[])
├── Commands (ICommand[])
└── Steps (IBlueprintStep[])
    ├── Content
    ├── MustConstraints
    └── MustNotConstraints
```

---

## 📝 Module structure

```csharp
internal sealed class BlueprintComposerModule(
    IPrompt prompt,
    IBlueprintBuilder blueprintBuilder,
    IBlueprintStepBuilder stepBuilder,
    /* ... builders ... */) : IBlueprintComposerModule
{
    public ModuleMetadata Metadata => IModule.Meta(
        "blueprints.mypattern", 
        GlobalPipelineModuleKinds.PromptComposer, 
        priority: 10);

    public Task Run(CancellationToken cancellationToken)
    {
        IBlueprint blueprint = blueprintBuilder
            .InitNew()
            .WithId("mypattern")
            .WithName("My Pattern")
            .WithDescription("...")
            .AddObjective(...)
            .AddMustConstraint(...)
            .AddStep(stepBuilder.InitNew()
                .WithContent("Step title\n\nStep description")
                .AddMustConstraint(...)
                .Build())
            .Build();

        prompt.Blueprints = [.. prompt.Blueprints, blueprint];
        return Task.CompletedTask;
    }
}
```

---

## 📦 Available Blueprints

### ContextCompiler.Blueprints.DotNet.WebApp.Razor
- **Purpose:** Guide for building ASP.NET Core Razor Pages applications
- **Steps:** 14 (initialization → deployment)
- **Constraints:** 62 MUST + 8 MUST NOT
- **Glossary:** 8 terms (Razor Pages, PageModel, Tag Helpers, etc.)

### ContextCompiler.Blueprints.Agile.UserStory
- **Purpose:** Guide for writing high-quality Agile User Stories
- **Steps:** 11 (role identification → stakeholder review)
- **Constraints:** Based on INVEST principles
- **Glossary:** 10 terms (User Story, INVEST, DoR, DoD, etc.)

---

## 🎨 Template rendering

Steps are **auto-numbered** in template:

```scriban
{{~ for step in blueprint.steps ~}}
#### Étape {{ for.index + 1 }} : {{ step.content }}
{{~ end ~}}
```

**Important:** Do NOT include step numbers in `Content` strings!

✅ **Correct:**
```csharp
.WithContent("Setup\n\nPrepare the environment")
```

❌ **Incorrect:**
```csharp
.WithContent("## Étape 1 : Setup\n\n...")
```

---

## 🔧 Configuration

Load via `modules.config.json`:

```json
{
  "sources": [
    {
      "type": "nuget",
      "packages": [
        {
          "id": "ContextCompiler.Blueprints.DotNet.WebApp.Razor",
          "version": "1.0.0"
        }
      ]
    }
  ]
}
```

---

## 📊 Persona vs Blueprint

| Concept | Responsibility | Example |
|---------|---------------|---------|
| **Persona** | General practices, coding standards | "Use PascalCase", "Follow SOLID" |
| **Blueprint** | Specific workflow, steps | "Step 1: Initialize project" |

---

## 🚀 Creating new Blueprints

1. Create project with `ContextCompiler.Blueprints.<Pattern>` naming
2. Implement `IBlueprintComposerModule`
3. Use builders for all components
4. Package as NuGet
5. Distribute and load via modules config

See `agent/Agent/features/phase_03/05-blueprints/examples.md` for detailed examples.

---

## ✅ MUST / MUST NOT

### MUST
- Use builder pattern
- Auto-number steps (template handles)
- Separate general practices (Persona) from workflows (Blueprint)
- Provide step-specific constraints when relevant
- Render deterministically
- Package as NuGet

### MUST NOT
- Include step numbers in Content
- Put general practices in Blueprints
- Modify IR
- Call LLM APIs
- Generate non-deterministic content

---

## 📚 Documentation

- **Feature spec:** `agent/Agent/features/phase_03/05-blueprints/FEATURE.md`
- **Examples:** `agent/Agent/features/phase_03/05-blueprints/examples.md`
- **Tests:** `agent/Agent/features/phase_03/05-blueprints/tests.md`
- **Comprehensive guide:** `src/Core/ContextCompiler.Abstractions/Prompt/BLUEPRINTS.md`
- **Implementation:** `src/Blueprints/`

---

## 🔍 Quick lookup

| Need | See |
|------|-----|
| Create new Blueprint | `examples.md` → Example 2 |
| Understand structure | `FEATURE.md` → Section 5 |
| Test Blueprints | `tests.md` |
| Module registration | `FEATURE.md` → Section 6 |
| Template rendering | `FEATURE.md` → Section 7 |
| Razor Web App example | `src/Blueprints/ContextCompiler.Blueprints.DotNet.WebApp.Razor/` |
| User Story example | `src/Blueprints/ContextCompiler.Blueprints.Agile.UserStory/` |

---

**Last updated:** 2025-01-XX  
**Status:** Production-ready
