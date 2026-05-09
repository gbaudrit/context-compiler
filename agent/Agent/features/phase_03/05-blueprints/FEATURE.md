# Feature: Blueprints — Guided Implementation Patterns (Ultra)

**Status:** Authoritative  
**Date:** 2025-01-XX  
**Pipeline:** Global Pipeline module kind `PromptComposer` (priority: 10)  
**Introduced:** Phase 3 (Framing Path)

Blueprints provide **structured, step-by-step guidance** for implementing common patterns, architectures, and workflows (e.g., Razor Web App, Agile User Story).

Blueprints are **framing constructs** added to the `IPrompt` model and rendered in `prompt.context.md` via Scriban templates.

---

## 1. Why this feature exists

Even with clean IR, personas, and views, LLMs benefit from **structured implementation guidance**:
- **Objectives**: What are we trying to achieve?
- **Constraints**: What must/must not be done?
- **Assumptions**: What prerequisites are expected?
- **Glossary**: Domain-specific terminology
- **Commands**: Utility actions available
- **Steps**: Sequential, atomic instructions with step-specific constraints

Blueprints provide **reusable, composable patterns** that guide LLMs through complex implementations without hardcoding logic.

---

## 2. Problem it solves

Without Blueprints:
- ❌ Implementation guidance is scattered across personas, constraints, and documentation
- ❌ No structured way to provide step-by-step instructions
- ❌ Difficult to reuse patterns across different contexts
- ❌ No separation between general practices (persona) and specific workflows (blueprint)
- ❌ Steps are manually numbered and hard to maintain

With Blueprints:
- ✅ Centralized, structured guidance for specific scenarios
- ✅ Sequential steps with automatic numbering
- ✅ Step-specific constraints (MUST/MUST NOT at each stage)
- ✅ Separation of concerns: Persona = general practices, Blueprint = specific workflow
- ✅ Reusable packages (NuGet) for different scenarios
- ✅ Template-driven rendering with conditional sections

---

## 3. Alternatives rejected

### "Put everything in Personas"
- **Rejected**: Personas should define general practices (coding standards, principles), not specific workflows. Mixing them creates bloated personas.

### "Hardcode steps in prompts"
- **Rejected**: Not reusable, not modular, not maintainable.

### "Use LLM to generate steps"
- **Rejected**: Violates pre-LLM requirement. Blueprints must be deterministic.

### "Manual step numbering"
- **Rejected**: Error-prone, maintenance burden. Template handles auto-numbering.

---

## 4. Scope

### Does
- Define reusable implementation patterns (Blueprints)
- Provide structured steps with auto-numbering
- Support global and step-specific constraints
- Include objectives, assumptions, glossary, commands
- Render deterministically in `prompt.context.md`
- Support multiple blueprints per compilation
- Allow Blueprint modules as NuGet packages

### Does NOT
- Execute steps (LLM consumes the guidance)
- Validate implementation (guards handle safety)
- Generate code (LLM responsibility)
- Modify IR or fragments
- Provide persona-level general practices

---

## 5. Authoritative domain model

### IBlueprint
Core interface for Blueprint definition:

```csharp
public interface IBlueprint
{
    string Id { get; }
    string Name { get; }
    string Description { get; }
    
    IReadOnlyCollection<IObjective> Objectives { get; }
    IReadOnlyCollection<IMustConstraint> MustConstraints { get; }
    IReadOnlyCollection<IMustNotConstraint> MustNotConstraints { get; }
    IReadOnlyCollection<IAssumption> Assumptions { get; }
    IReadOnlyCollection<IGlossaryTerm> Glossary { get; }
    IReadOnlyCollection<ICommand> Commands { get; }
    IReadOnlyCollection<IBlueprintStep> Steps { get; }
}
```

### IBlueprintStep
Sequential step with optional constraints:

```csharp
public interface IBlueprintStep
{
    string Content { get; }
    IReadOnlyCollection<IMustConstraint> MustConstraints { get; }
    IReadOnlyCollection<IMustNotConstraint> MustNotConstraints { get; }
}
```

### Builders
All Blueprint components use builder pattern:
- `IBlueprintBuilder`
- `IBlueprintStepBuilder`
- `IMustConstraintBuilder`
- `IMustNotConstraintBuilder`
- `IObjectiveBuilder`
- `IAssumptionBuilder`
- `IGlossaryTermBuilder`
- `ICommandBuilder`

---

## 6. Module architecture

### IBlueprintComposerModule
Blueprint providers implement `IBlueprintComposerModule`:

```csharp
internal sealed class BlueprintComposerModule(
    IPrompt prompt,
    IBlueprintBuilder blueprintBuilder,
    IBlueprintStepBuilder stepBuilder,
    /* ... other builders ... */) : IBlueprintComposerModule
{
    public ModuleMetadata Metadata => IModule.Meta(
        "blueprints.agile.userstory", 
        GlobalPipelineModuleKinds.PromptComposer, 
        priority: 10);

    public Task Run(CancellationToken cancellationToken)
    {
        IBlueprint blueprint = blueprintBuilder
            .InitNew()
            .WithId("agile.userstory")
            .WithName("Rédaction de User Story Agile")
            .WithDescription("Blueprint pour...")
            .AddObjective(...)
            .AddMustConstraint(...)
            .AddStep(stepBuilder.InitNew()
                .WithContent("Identifier le rôle utilisateur")
                .AddMustConstraint(...)
                .Build())
            .Build();

        prompt.Blueprints = [.. prompt.Blueprints, blueprint];
        return Task.CompletedTask;
    }
}
```

### Registration
Blueprints are added to `IPrompt.Blueprints` collection during `PromptComposer` stage.

### Packaging
Blueprints are distributed as NuGet packages (e.g., `ContextCompiler.Prompting.Blueprints.DotNet.WebApp.Razor`, `ContextCompiler.Prompting.Blueprints.Agile.UserStory`).

---

## 7. Template rendering

### Scriban template structure
Blueprints are rendered in `prompt.context.md` via `prompt.context.md` template:

```scriban
{{~ if blueprints && blueprints.size > 0 ~}}
# Blueprints

{{~ for blueprint in blueprints ~}}
## {{ blueprint.name }} ({{ blueprint.id }})

{{ blueprint.description }}

{{~ if blueprint.objectives && blueprint.objectives.size > 0 ~}}
### Objectives
{{~ for obj in blueprint.objectives ~}}
- {{ obj.name }}: {{ obj.description }}
{{~ end ~}}
{{~ end ~}}

{{~ if blueprint.mustConstraints && blueprint.mustConstraints.size > 0 ~}}
### MUST
{{~ for m in blueprint.mustConstraints ~}}
- {{ m.id }}: {{ m.text }}
{{~ end ~}}
{{~ end ~}}

{{~ if blueprint.mustNotConstraints && blueprint.mustNotConstraints.size > 0 ~}}
### MUST NOT
{{~ for mn in blueprint.mustNotConstraints ~}}
- {{ mn.id }}: {{ mn.text }}
{{~ end ~}}
{{~ end ~}}

{{~ if blueprint.assumptions && blueprint.assumptions.size > 0 ~}}
### Assumptions
{{~ for a in blueprint.assumptions ~}}
- {{ a.name }}: {{ a.description }}
{{~ end ~}}
{{~ end ~}}

{{~ if blueprint.glossary && blueprint.glossary.size > 0 ~}}
### Glossary
{{~ for g in blueprint.glossary ~}}
- **{{ g.term }}**: {{ g.definition }}
{{~ end ~}}
{{~ end ~}}

{{~ if blueprint.commands && blueprint.commands.size > 0 ~}}
### Commands
{{~ for c in blueprint.commands ~}}
- {{ c.name }}: {{ c.description }}
{{~ end ~}}
{{~ end ~}}

{{~ if blueprint.steps && blueprint.steps.size > 0 ~}}
### Steps
{{~ for step in blueprint.steps ~}}

#### Étape {{ for.index + 1 }} : {{ step.content }}

{{~ if step.mustConstraints && step.mustConstraints.size > 0 ~}}
**MUST:**
{{~ for m in step.mustConstraints ~}}
- {{ m.id }}: {{ m.text }}
{{~ end ~}}
{{~ end ~}}
{{~ if step.mustNotConstraints && step.mustNotConstraints.size > 0 ~}}
**MUST NOT:**
{{~ for mn in step.mustNotConstraints ~}}
- {{ mn.id }}: {{ mn.text }}
{{~ end ~}}
{{~ end ~}}
{{~ end ~}}
{{~ end ~}}
{{~ end ~}}
{{~ end ~}}
```

### Auto-numbering
Steps are **automatically numbered** using `{{ for.index + 1 }}` in template. Blueprint modules should **NOT** include step numbers in `Content`.

✅ **Correct:**
```csharp
.WithContent("Initialiser le projet\n\nCréer le projet avec la commande...")
```

❌ **Incorrect:**
```csharp
.WithContent("## Étape 1 : Initialiser le projet\n\n...")
```

---

## 8. Separation of concerns

### Persona vs Blueprint

| Concept | Responsibility | Example |
|---------|---------------|---------|
| **Persona** | General practices, coding standards, principles | "Use PascalCase for classes", "Avoid code duplication" |
| **Blueprint** | Specific workflow, sequential steps, pattern implementation | "Step 1: Initialize project", "Step 2: Configure Program.cs" |

### Example: .NET Razor Web App

**DotnetDeveloperModule (Persona):**
- Use PascalCase for classes
- Use async/await for I/O
- Follow SOLID principles
- Use dependency injection
- Write unit tests

**RazorWebAppBlueprint (Blueprint):**
- Step 1: Create project with `dotnet new webapp`
- Step 2: Configure Program.cs with services and middleware
- Step 3: Create _Layout.cshtml and shared pages
- Step 4: Create Razor pages with PageModel
- ... (14 steps total)

---

## 9. Implemented Blueprints

### ContextCompiler.Prompting.Blueprints.DotNet.WebApp.Razor
- **Objectives:** 4 (performance, architecture, security, maintainability)
- **Global constraints:** 7 MUST + 4 MUST NOT
- **Assumptions:** 3
- **Glossary:** 8 terms (Razor Pages, PageModel, Tag Helpers, etc.)
- **Commands:** 5 (create-project, add-page, add-service, etc.)
- **Steps:** 14 (from initialization to deployment)
- **Total constraints:** 62 MUST + 8 MUST NOT across all steps

### ContextCompiler.Prompting.Blueprints.Agile.UserStory
- **Objectives:** 4 (business value, testability, quality, communication)
- **Global constraints:** 7 MUST + 5 MUST NOT
- **Assumptions:** 4
- **Glossary:** 10 terms (User Story, INVEST, DoR, DoD, etc.)
- **Commands:** 5 (write-story, review-story, split-epic, etc.)
- **Steps:** 11 (from role identification to stakeholder review)

---

## 10. MUST / MUST NOT

### MUST
- Implement `IBlueprintComposerModule` for Blueprint providers
- Use builder pattern for all Blueprint components
- Add Blueprints to `IPrompt.Blueprints` collection
- Provide unique Blueprint `Id` and descriptive `Name`
- Support automatic step numbering (no manual numbers in `Content`)
- Render deterministically via Scriban template
- Include objectives, constraints, and assumptions
- Provide step-specific constraints when relevant
- Package as NuGet for reusability
- Register as `GlobalPipelineModuleKinds.PromptComposer` with appropriate priority

### MUST NOT
- Include general practices in Blueprints (use Personas)
- Hardcode step numbers in `Content` strings
- Execute or validate steps (LLM responsibility)
- Modify IR or fragments
- Call LLM APIs
- Generate non-deterministic content (timestamps, random data)
- Bypass Builder pattern for domain object creation
- Mutate Blueprints after construction (immutable)

---

## 11. Configuration

Blueprints are loaded via NuGet package references in `.ctxc/modules/modules.config.json`:

```json
{
  "sources": [
    {
      "type": "nuget",
      "packages": [
        {
          "id": "ContextCompiler.Prompting.Blueprints.DotNet.WebApp.Razor",
          "version": "1.0.0"
        },
        {
          "id": "ContextCompiler.Prompting.Blueprints.Agile.UserStory",
          "version": "1.0.0"
        }
      ]
    }
  ]
}
```

No additional configuration required in `ctxc.config.json` — Blueprints auto-register during module discovery.

---

## 12. Extension points

### Creating new Blueprints

1. **Create project:**
   ```xml
   <Project Sdk="Microsoft.NET.Sdk">
     <PropertyGroup>
       <TargetFramework>net10.0</TargetFramework>
       <IsPackable>true</IsPackable>
       <PackageId>ContextCompiler.Blueprints.MyPattern</PackageId>
     </PropertyGroup>
     <ItemGroup>
       <ProjectReference Include="..\..\Packs\ContextCompiler.Packs.Starter.Standard\..." />
     </ItemGroup>
   </Project>
   ```

2. **Implement module:**
   ```csharp
   internal sealed class BlueprintComposerModule(
       IPrompt prompt,
       IBlueprintBuilder blueprintBuilder,
       IBlueprintStepBuilder stepBuilder,
       /* builders... */) : IBlueprintComposerModule
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
               .WithName("My Pattern Blueprint")
               .WithDescription("Guidance for...")
               .AddObjective(...)
               .AddStep(...)
               .Build();
           
           prompt.Blueprints = [.. prompt.Blueprints, blueprint];
           return Task.CompletedTask;
       }
   }
   ```

3. **Register DI:**
   ```csharp
   public static class DependencyInjection
   {
       public static IServiceCollection AddMyPatternBlueprint(
           this IServiceCollection services)
       {
           return services.AddSingleton<IBlueprintComposerModule, 
               BlueprintComposerModule>();
       }
   }
   ```

4. **Package and distribute** as NuGet

---

## 13. Testing strategy

### Unit tests
- Verify Blueprint construction via builders
- Validate all required properties are set
- Ensure step-specific constraints are attached
- Confirm auto-numbering in template rendering

### Integration tests
- Load Blueprint modules from NuGet packages
- Verify Blueprint appears in `IPrompt.Blueprints`
- Confirm rendering in `prompt.context.md`
- Validate deterministic output (byte-for-byte)

### Regression tests
- Ensure step numbering remains consistent
- Verify constraint IDs are stable
- Confirm no duplicate Blueprint IDs

---

## 14. Performance considerations

- Blueprints are constructed once during `PromptComposer` stage
- Immutable after construction (no runtime mutation)
- Template rendering is deterministic and cached
- No dynamic content generation (pre-LLM requirement)
- Minimal memory footprint (simple POCO objects)

---

## 15. Future enhancements

### Conditional steps
Allow steps to be conditionally included based on context:
```csharp
.AddStep(stepBuilder.InitNew()
    .WithContent("Configure authentication")
    .WithCondition(ctx => ctx.HasFeature("auth"))
    .Build())
```

### Step dependencies
Declare dependencies between steps:
```csharp
.AddStep(stepBuilder.InitNew()
    .WithContent("Run migrations")
    .DependsOn("database-configured")
    .Build())
```

### Blueprint composition
Combine multiple blueprints:
```csharp
.ComposedFrom(baseBlueprint)
.WithAdditionalSteps(...)
```

### Validation hooks
Allow custom validation logic:
```csharp
.WithValidator<MyBlueprintValidator>()
```

---

## 16. Examples

### Example 1: Razor Web App Blueprint
See `src/Blueprints/ContextCompiler.Prompting.Blueprints.DotNet.WebApp.Razor/`

**Key characteristics:**
- 14 steps covering full development lifecycle
- Step-specific constraints (e.g., "Step 2: Configure Program.cs" has 4 MUST + 1 MUST NOT)
- Global constraints separate from step constraints
- Integration with DotnetDeveloperModule persona
- Glossary for Razor-specific terms

### Example 2: Agile User Story Blueprint
See `src/Blueprints/ContextCompiler.Prompting.Blueprints.Agile.UserStory/`

**Key characteristics:**
- 11 steps for complete User Story lifecycle
- INVEST validation step
- Definition of Ready/Done steps
- Integration with BusinessAnalystModule persona
- Glossary for Agile terminology

---

## 17. Compliance matrix

| Requirement | Status | Notes |
|------------|--------|-------|
| Pre-LLM only | ✅ | No LLM calls in Blueprint construction |
| Deterministic | ✅ | Fixed ordering, auto-numbering, no timestamps |
| Module-first | ✅ | Blueprints are modules (`IBlueprintComposerModule`) |
| Auditable | ✅ | Blueprint IDs, constraint IDs tracked |
| Guard-enforced | N/A | Blueprints don't interact with guards |
| Builder pattern | ✅ | All components use builders |
| Immutable IR | ✅ | Blueprints don't modify IR |
| NuGet packaging | ✅ | Distributed as packages |
| Template rendering | ✅ | Scriban template with auto-numbering |
| Separation of concerns | ✅ | Persona vs Blueprint distinction clear |

---

## 18. Documentation

- **Interfaces:** `src/Core/ContextCompiler.Abstractions/Prompt/IBlueprint.cs`, `IBlueprintStep.cs`, `IBlueprintBuilder.cs`, `IBlueprintStepBuilder.cs`
- **Implementations:** `src/Core/ContextCompiler.Core/Framing/Blueprint.cs`, `BlueprintBuilder.cs`, `BlueprintStep.cs`, `BlueprintStepBuilder.cs`
- **Module interface:** `src/Core/ContextCompiler.Modules.Abstractions/IBlueprintComposerModule.cs`
- **Template:** `src/Modules/ContextCompiler.Prompting.Modules.Templates.Scriban/Templates/prompt.context.md`
- **Examples:** `src/Blueprints/ContextCompiler.Prompting.Blueprints.DotNet.WebApp.Razor/`, `src/Blueprints/ContextCompiler.Prompting.Blueprints.Agile.UserStory/`
- **Comprehensive guide:** `src/Core/ContextCompiler.Abstractions/Prompt/BLUEPRINTS.md`

---

## 19. Glossary

- **Blueprint:** Structured, step-by-step guidance for implementing a specific pattern or workflow
- **Blueprint Step:** Atomic instruction within a Blueprint, optionally with step-specific constraints
- **Auto-numbering:** Template-driven step numbering (not in Blueprint Content)
- **Global constraints:** MUST/MUST NOT applicable to entire Blueprint
- **Step constraints:** MUST/MUST NOT specific to a single step
- **Blueprint Composer Module:** Module that creates and registers Blueprints during PromptComposer stage
- **Persona:** General practices and coding standards (separate from Blueprints)
- **INVEST:** Criteria for quality User Stories (Independent, Negotiable, Valuable, Estimable, Small, Testable)
- **DoR/DoD:** Definition of Ready / Definition of Done

---

## 20. Decision log

| Date | Decision | Rationale |
|------|----------|-----------|
| 2025-01-XX | Separate Blueprint from Persona | Personas = general practices, Blueprints = specific workflows |
| 2025-01-XX | Auto-number steps in template | Reduces maintenance burden, eliminates manual numbering errors |
| 2025-01-XX | Use builder pattern | Ensures immutability and fluent API |
| 2025-01-XX | Package as NuGet | Enables reusability and versioning |
| 2025-01-XX | Support step-specific constraints | Allows fine-grained guidance at each stage |
| 2025-01-XX | Render in Scriban template | Consistent with other prompt composition (personas, constraints) |

---

**END OF FEATURE: BLUEPRINTS**
