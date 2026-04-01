# Blueprints — Examples

This document provides concrete examples of Blueprint usage, module implementation, and rendered output.

---

## Example 1: Minimal Blueprint

### Module implementation

```csharp
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Blueprints.Example.Minimal;

internal sealed class BlueprintComposerModule(
    IPrompt prompt,
    IBlueprintBuilder blueprintBuilder,
    IBlueprintStepBuilder stepBuilder,
    IMustConstraintBuilder mustBuilder) : IBlueprintComposerModule
{
    public ModuleMetadata Metadata => IModule.Meta(
        "blueprints.example.minimal", 
        GlobalPipelineModuleKinds.PromptComposer, 
        priority: 10);

    public Task Run(CancellationToken cancellationToken)
    {
        IBlueprint blueprint = blueprintBuilder
            .InitNew()
            .WithId("example.minimal")
            .WithName("Minimal Blueprint")
            .WithDescription("A minimal blueprint with 3 steps.")
            
            .AddMustConstraint(mustBuilder.InitNew()
                .WithId("MUST1")
                .WithText("Follow the steps in order")
                .Build())
            
            .AddStep(stepBuilder.InitNew()
                .WithContent("Preparation\n\nGather all required materials.")
                .AddMustConstraint(mustBuilder.InitNew()
                    .WithId("STEP1_MUST1")
                    .WithText("Verify materials are complete")
                    .Build())
                .Build())
            
            .AddStep(stepBuilder.InitNew()
                .WithContent("Execution\n\nPerform the main task.")
                .Build())
            
            .AddStep(stepBuilder.InitNew()
                .WithContent("Validation\n\nVerify the result meets requirements.")
                .Build())
            
            .Build();

        prompt.Blueprints = [.. prompt.Blueprints, blueprint];
        return Task.CompletedTask;
    }
}
```

### Rendered output in prompt.context.md

```markdown
# Blueprints

## Minimal Blueprint (example.minimal)

A minimal blueprint with 3 steps.

### MUST
- MUST1: Follow the steps in order

### Steps

#### Étape 1 : Preparation

Gather all required materials.

**MUST:**
- STEP1_MUST1: Verify materials are complete

#### Étape 2 : Execution

Perform the main task.

#### Étape 3 : Validation

Verify the result meets requirements.
```

---

## Example 2: Complete Blueprint with all sections

### Module implementation

```csharp
internal sealed class BlueprintComposerModule(
    IPrompt prompt,
    IBlueprintBuilder blueprintBuilder,
    IBlueprintStepBuilder stepBuilder,
    IMustConstraintBuilder mustBuilder,
    IMustNotConstraintBuilder mustNotBuilder,
    IObjectiveBuilder objectiveBuilder,
    IAssumptionBuilder assumptionBuilder,
    IGlossaryTermBuilder glossaryBuilder,
    ICommandBuilder commandBuilder) : IBlueprintComposerModule
{
    public ModuleMetadata Metadata => IModule.Meta(
        "blueprints.example.complete", 
        GlobalPipelineModuleKinds.PromptComposer, 
        priority: 10);

    public Task Run(CancellationToken cancellationToken)
    {
        IBlueprint blueprint = blueprintBuilder
            .InitNew()
            .WithId("example.complete")
            .WithName("Complete Blueprint Example")
            .WithDescription("Demonstrates all Blueprint features.")
            
            // Objectives
            .AddObjective(objectiveBuilder.InitNew()
                .WithName("OBJ1")
                .WithDescription("Demonstrate all Blueprint sections")
                .Build())
            .AddObjective(objectiveBuilder.InitNew()
                .WithName("OBJ2")
                .WithDescription("Show proper constraint usage")
                .Build())
            
            // Global constraints
            .AddMustConstraint(mustBuilder.InitNew()
                .WithId("MUST1")
                .WithText("Follow the sequential steps")
                .Build())
            .AddMustConstraint(mustBuilder.InitNew()
                .WithId("MUST2")
                .WithText("Validate at each checkpoint")
                .Build())
            
            .AddMustNotConstraint(mustNotBuilder.InitNew()
                .WithId("MUSTNOT1")
                .WithText("Skip validation steps")
                .Build())
            .AddMustNotConstraint(mustNotBuilder.InitNew()
                .WithId("MUSTNOT2")
                .WithText("Proceed without prerequisites")
                .Build())
            
            // Assumptions
            .AddAssumption(assumptionBuilder.InitNew()
                .WithName("AS1")
                .WithDescription("Required tools are installed")
                .Build())
            .AddAssumption(assumptionBuilder.InitNew()
                .WithName("AS2")
                .WithDescription("User has necessary permissions")
                .Build())
            
            // Glossary
            .AddGlossaryTerm(glossaryBuilder.InitNew()
                .WithTerm("Checkpoint")
                .WithDefinition("A validation point in the workflow")
                .Build())
            .AddGlossaryTerm(glossaryBuilder.InitNew()
                .WithTerm("Prerequisites")
                .WithDefinition("Required conditions before starting")
                .Build())
            
            // Commands
            .AddCommand(commandBuilder.InitNew()
                .WithName("verify-setup")
                .WithDescription("Verify all prerequisites are met")
                .Build())
            .AddCommand(commandBuilder.InitNew()
                .WithName("run-validation")
                .WithDescription("Execute validation checks")
                .Build())
            
            // Steps
            .AddStep(stepBuilder.InitNew()
                .WithContent("Setup\n\nPrepare the environment and verify prerequisites.")
                .AddMustConstraint(mustBuilder.InitNew()
                    .WithId("STEP1_MUST1")
                    .WithText("Run verify-setup command")
                    .Build())
                .AddMustConstraint(mustBuilder.InitNew()
                    .WithId("STEP1_MUST2")
                    .WithText("Document any missing prerequisites")
                    .Build())
                .Build())
            
            .AddStep(stepBuilder.InitNew()
                .WithContent("Implementation\n\nPerform the core workflow.")
                .AddMustConstraint(mustBuilder.InitNew()
                    .WithId("STEP2_MUST1")
                    .WithText("Follow documented procedures")
                    .Build())
                .AddMustNotConstraint(mustNotBuilder.InitNew()
                    .WithId("STEP2_MUSTNOT1")
                    .WithText("Deviate from approved workflow")
                    .Build())
                .Build())
            
            .AddStep(stepBuilder.InitNew()
                .WithContent("Validation\n\nVerify the implementation meets requirements.")
                .AddMustConstraint(mustBuilder.InitNew()
                    .WithId("STEP3_MUST1")
                    .WithText("Run run-validation command")
                    .Build())
                .AddMustConstraint(mustBuilder.InitNew()
                    .WithId("STEP3_MUST2")
                    .WithText("Document validation results")
                    .Build())
                .Build())
            
            .Build();

        prompt.Blueprints = [.. prompt.Blueprints, blueprint];
        return Task.CompletedTask;
    }
}
```

### Rendered output

```markdown
# Blueprints

## Complete Blueprint Example (example.complete)

Demonstrates all Blueprint features.

### Objectives
- OBJ1: Demonstrate all Blueprint sections
- OBJ2: Show proper constraint usage

### MUST
- MUST1: Follow the sequential steps
- MUST2: Validate at each checkpoint

### MUST NOT
- MUSTNOT1: Skip validation steps
- MUSTNOT2: Proceed without prerequisites

### Assumptions
- AS1: Required tools are installed
- AS2: User has necessary permissions

### Glossary
- **Checkpoint**: A validation point in the workflow
- **Prerequisites**: Required conditions before starting

### Commands
- verify-setup: Verify all prerequisites are met
- run-validation: Execute validation checks

### Steps

#### Étape 1 : Setup

Prepare the environment and verify prerequisites.

**MUST:**
- STEP1_MUST1: Run verify-setup command
- STEP1_MUST2: Document any missing prerequisites

#### Étape 2 : Implementation

Perform the core workflow.

**MUST:**
- STEP2_MUST1: Follow documented procedures

**MUST NOT:**
- STEP2_MUSTNOT1: Deviate from approved workflow

#### Étape 3 : Validation

Verify the implementation meets requirements.

**MUST:**
- STEP3_MUST1: Run run-validation command
- STEP3_MUST2: Document validation results
```

---

## Example 3: .NET Razor Web App Blueprint (excerpt)

### Step 4: Create Razor Pages

```csharp
.AddStep(stepBuilder.InitNew()
    .WithContent("Création des pages Razor\n\nCréer les pages Razor (.cshtml) avec leurs PageModel (.cshtml.cs) correspondants.")
    .AddMustConstraint(mustBuilder.InitNew()
        .WithId("STEP4_MUST1")
        .WithText("Créer une page avec @page directive en haut")
        .Build())
    .AddMustConstraint(mustBuilder.InitNew()
        .WithId("STEP4_MUST2")
        .WithText("Créer le PageModel hérité de PageModel base class")
        .Build())
    .AddMustConstraint(mustBuilder.InitNew()
        .WithId("STEP4_MUST3")
        .WithText("Utiliser @model directive pour lier la page à son PageModel")
        .Build())
    .AddMustConstraint(mustBuilder.InitNew()
        .WithId("STEP4_MUST4")
        .WithText("Implémenter OnGet/OnPost pour les gestionnaires de requêtes HTTP")
        .Build())
    .AddMustConstraint(mustBuilder.InitNew()
        .WithId("STEP4_MUST5")
        .WithText("Utiliser [BindProperty] pour la liaison de données dans les POST")
        .Build())
    .AddMustNotConstraint(mustNotBuilder.InitNew()
        .WithId("STEP4_MUSTNOT1")
        .WithText("Accéder directement à HttpContext.Request.Form dans les handlers")
        .Build())
    .Build())
```

### Rendered output

```markdown
#### Étape 4 : Création des pages Razor

Créer les pages Razor (.cshtml) avec leurs PageModel (.cshtml.cs) correspondants.

**MUST:**
- STEP4_MUST1: Créer une page avec @page directive en haut
- STEP4_MUST2: Créer le PageModel hérité de PageModel base class
- STEP4_MUST3: Utiliser @model directive pour lier la page à son PageModel
- STEP4_MUST4: Implémenter OnGet/OnPost pour les gestionnaires de requêtes HTTP
- STEP4_MUST5: Utiliser [BindProperty] pour la liaison de données dans les POST

**MUST NOT:**
- STEP4_MUSTNOT1: Accéder directement à HttpContext.Request.Form dans les handlers
```

---

## Example 4: Agile User Story Blueprint (excerpt)

### Step 5: INVEST Validation

```csharp
.AddStep(stepBuilder.InitNew()
    .WithContent("Valider avec les critères INVEST\n\nVérifier que la User Story respecte les principes INVEST de qualité.")
    .AddMustConstraint(mustBuilder.InitNew()
        .WithId("STEP5_MUST1")
        .WithText("Vérifier l'indépendance : la story peut être développée seule")
        .Build())
    .AddMustConstraint(mustBuilder.InitNew()
        .WithId("STEP5_MUST2")
        .WithText("Vérifier la négociabilité : les détails d'implémentation sont flexibles")
        .Build())
    .AddMustConstraint(mustBuilder.InitNew()
        .WithId("STEP5_MUST3")
        .WithText("Vérifier la valeur : apporte un bénéfice clair à l'utilisateur ou au business")
        .Build())
    .AddMustConstraint(mustBuilder.InitNew()
        .WithId("STEP5_MUST4")
        .WithText("Vérifier l'estimabilité : l'équipe peut estimer l'effort nécessaire")
        .Build())
    .AddMustConstraint(mustBuilder.InitNew()
        .WithId("STEP5_MUST5")
        .WithText("Vérifier la taille : peut être complétée dans un sprint")
        .Build())
    .AddMustConstraint(mustBuilder.InitNew()
        .WithId("STEP5_MUST6")
        .WithText("Vérifier la testabilité : peut être testée objectivement")
        .Build())
    .AddMustNotConstraint(mustNotBuilder.InitNew()
        .WithId("STEP5_MUSTNOT1")
        .WithText("Accepter une User Story qui viole un ou plusieurs critères INVEST sans la décomposer")
        .Build())
    .Build())
```

### Rendered output

```markdown
#### Étape 5 : Valider avec les critères INVEST

Vérifier que la User Story respecte les principes INVEST de qualité.

**MUST:**
- STEP5_MUST1: Vérifier l'indépendance : la story peut être développée seule
- STEP5_MUST2: Vérifier la négociabilité : les détails d'implémentation sont flexibles
- STEP5_MUST3: Vérifier la valeur : apporte un bénéfice clair à l'utilisateur ou au business
- STEP5_MUST4: Vérifier l'estimabilité : l'équipe peut estimer l'effort nécessaire
- STEP5_MUST5: Vérifier la taille : peut être complétée dans un sprint
- STEP5_MUST6: Vérifier la testabilité : peut être testée objectivement

**MUST NOT:**
- STEP5_MUSTNOT1: Accepter une User Story qui viole un ou plusieurs critères INVEST sans la décomposer
```

---

## Example 5: Multiple Blueprints in one prompt

When multiple Blueprint modules are loaded, they all appear in the rendered prompt:

```markdown
# Blueprints

## Application Web .NET avec Razor Pages (dotnet.webapp.razor)

Blueprint pour construire une application web .NET moderne utilisant Razor Pages...

### Objectives
...

### Steps
...

## Rédaction de User Story Agile (agile.userstory)

Blueprint pour rédiger des User Stories Agile de haute qualité...

### Objectives
...

### Steps
...
```

---

## Example 6: Blueprint with conditional sections

When sections are empty, they don't render:

```csharp
IBlueprint blueprint = blueprintBuilder
    .InitNew()
    .WithId("example.minimal-sections")
    .WithName("Minimal Sections Blueprint")
    .WithDescription("Only has steps, no other sections.")
    
    // No objectives, constraints, assumptions, glossary, commands
    
    .AddStep(stepBuilder.InitNew()
        .WithContent("Single step\n\nDo the work.")
        .Build())
    
    .Build();
```

### Rendered output

```markdown
## Minimal Sections Blueprint (example.minimal-sections)

Only has steps, no other sections.

### Steps

#### Étape 1 : Single step

Do the work.
```

Notice: No Objectives, MUST, MUST NOT, Assumptions, Glossary, or Commands sections — template handles conditional rendering.

---

## Example 7: Project structure for Blueprint package

```
src/
  Blueprints/
    ContextCompiler.Blueprints.MyPattern/
      ContextCompiler.Blueprints.MyPattern.csproj
      BlueprintComposerModule.cs
      DependencyInjection.cs
      README.md
      MyPatternBlueprintModule.cs (optional wrapper)
```

### Project file

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <Configurations>Debug;Release;DebugLocal</Configurations>
    <IsPackable>true</IsPackable>
    <PackageId>ContextCompiler.Blueprints.MyPattern</PackageId>
    <Title>My Pattern blueprint</Title>
    <Description>Blueprint for implementing My Pattern with best practices.</Description>
    <PackageTags>context;compiler;blueprint;mypattern</PackageTags>
    <PackageReadmeFile>README.md</PackageReadmeFile>
    <Authors>ContextCompiler</Authors>
  </PropertyGroup>

  <PropertyGroup Condition="'$(Configuration)' == 'DebugLocal'">
    <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
  </PropertyGroup>

  <ItemGroup>
    <None Include="README.md" Pack="true" PackagePath="" />
    <ProjectReference Include="..\..\Packs\ContextCompiler.Packs.Starter.Standard\..." />
    <ProjectReference Include="..\..\Modules\ContextCompiler.Modules.Prompt.Templates.Scriban\..." />
  </ItemGroup>
</Project>
```

---

## Example 8: Loading Blueprint via modules.config.json

```json
{
  "version": "1.0",
  "sources": [
    {
      "type": "nuget",
      "packages": [
        {
          "id": "ContextCompiler.Blueprints.DotNet.WebApp.Razor",
          "version": "1.0.0"
        },
        {
          "id": "ContextCompiler.Blueprints.Agile.UserStory",
          "version": "1.0.0"
        },
        {
          "id": "ContextCompiler.Blueprints.MyPattern",
          "version": "1.0.0"
        }
      ]
    }
  ]
}
```

---

## Example 9: Builder pattern usage

All Blueprint components use fluent builder pattern:

```csharp
// Blueprint builder
IBlueprint blueprint = blueprintBuilder
    .InitNew()                                    // Reset state
    .WithId("my.blueprint")                       // Set ID
    .WithName("My Blueprint")                     // Set name
    .WithDescription("Description here")          // Set description
    .AddObjective(...)                            // Add objective
    .AddMustConstraint(...)                       // Add global constraint
    .AddStep(...)                                 // Add step
    .Build();                                     // Create immutable instance

// Step builder
IBlueprintStep step = stepBuilder
    .InitNew()
    .WithContent("Step title\n\nStep description")
    .AddMustConstraint(...)
    .AddMustNotConstraint(...)
    .Build();

// Constraint builder
IMustConstraint must = mustBuilder
    .InitNew()
    .WithId("MUST1")
    .WithText("Constraint text")
    .Build();

// Objective builder
IObjective objective = objectiveBuilder
    .InitNew()
    .WithName("OBJ1")
    .WithDescription("Objective description")
    .Build();

// And so on for all builder types...
```

---

## Example 10: Anti-patterns (what NOT to do)

### ❌ Manual step numbering
```csharp
// WRONG: Don't include step numbers in Content
.WithContent("## Étape 1 : Setup\n\nSetup the environment")
```

### ✅ Correct: Let template handle numbering
```csharp
// CORRECT: Template adds "Étape X :" automatically
.WithContent("Setup\n\nSetup the environment")
```

### ❌ Mixing general practices in Blueprint
```csharp
// WRONG: General practices belong in Persona
.AddMustConstraint(mustBuilder.InitNew()
    .WithId("MUST1")
    .WithText("Use PascalCase for classes")  // Too general
    .Build())
```

### ✅ Correct: Blueprint-specific guidance
```csharp
// CORRECT: Specific to this workflow
.AddMustConstraint(mustBuilder.InitNew()
    .WithId("MUST1")
    .WithText("Create Razor pages with @page directive")  // Specific
    .Build())
```

### ❌ Mutable Blueprints
```csharp
// WRONG: Blueprints are immutable
IBlueprint blueprint = blueprintBuilder.Build();
blueprint.Steps.Add(newStep);  // Compile error: read-only collection
```

### ✅ Correct: Build complete Blueprint upfront
```csharp
// CORRECT: Add all steps before Build()
IBlueprint blueprint = blueprintBuilder
    .InitNew()
    .AddStep(step1)
    .AddStep(step2)
    .AddStep(step3)
    .Build();
```

---

**END OF EXAMPLES**
