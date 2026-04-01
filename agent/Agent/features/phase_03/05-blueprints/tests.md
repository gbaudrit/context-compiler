# Blueprints — Testing Strategy

This document defines the testing strategy for Blueprint functionality.

---

## Test categories

### 1. Unit tests (builder pattern)
### 2. Integration tests (module loading)
### 3. Rendering tests (template output)
### 4. Regression tests (stability)
### 5. Validation tests (constraints)

---

## 1. Unit tests — Builder pattern

### Test: BlueprintBuilder creates valid Blueprint

```csharp
[Fact]
public void BlueprintBuilder_WithAllSections_CreatesValidBlueprint()
{
    // Arrange
    var builder = new BlueprintBuilder();
    var objectiveBuilder = new ObjectiveBuilder();
    var mustBuilder = new MustConstraintBuilder();
    var stepBuilder = new BlueprintStepBuilder();
    
    // Act
    IBlueprint blueprint = builder
        .InitNew()
        .WithId("test.blueprint")
        .WithName("Test Blueprint")
        .WithDescription("Test description")
        .AddObjective(objectiveBuilder.InitNew()
            .WithName("OBJ1")
            .WithDescription("Test objective")
            .Build())
        .AddMustConstraint(mustBuilder.InitNew()
            .WithId("MUST1")
            .WithText("Test constraint")
            .Build())
        .AddStep(stepBuilder.InitNew()
            .WithContent("Test step")
            .Build())
        .Build();
    
    // Assert
    Assert.Equal("test.blueprint", blueprint.Id);
    Assert.Equal("Test Blueprint", blueprint.Name);
    Assert.Equal("Test description", blueprint.Description);
    Assert.Single(blueprint.Objectives);
    Assert.Single(blueprint.MustConstraints);
    Assert.Single(blueprint.Steps);
}
```

### Test: BlueprintBuilder InitNew resets state

```csharp
[Fact]
public void BlueprintBuilder_InitNew_ResetsState()
{
    // Arrange
    var builder = new BlueprintBuilder();
    var stepBuilder = new BlueprintStepBuilder();
    
    // Act
    IBlueprint blueprint1 = builder
        .InitNew()
        .WithId("blueprint1")
        .WithName("First")
        .AddStep(stepBuilder.InitNew().WithContent("Step 1").Build())
        .Build();
    
    IBlueprint blueprint2 = builder
        .InitNew()
        .WithId("blueprint2")
        .WithName("Second")
        .Build();
    
    // Assert
    Assert.Equal("blueprint1", blueprint1.Id);
    Assert.Equal("blueprint2", blueprint2.Id);
    Assert.Single(blueprint1.Steps);
    Assert.Empty(blueprint2.Steps);  // State was reset
}
```

### Test: BlueprintStepBuilder creates valid step

```csharp
[Fact]
public void BlueprintStepBuilder_WithConstraints_CreatesValidStep()
{
    // Arrange
    var stepBuilder = new BlueprintStepBuilder();
    var mustBuilder = new MustConstraintBuilder();
    var mustNotBuilder = new MustNotConstraintBuilder();
    
    // Act
    IBlueprintStep step = stepBuilder
        .InitNew()
        .WithContent("Test step content")
        .AddMustConstraint(mustBuilder.InitNew()
            .WithId("STEP1_MUST1")
            .WithText("Test must")
            .Build())
        .AddMustNotConstraint(mustNotBuilder.InitNew()
            .WithId("STEP1_MUSTNOT1")
            .WithText("Test must not")
            .Build())
        .Build();
    
    // Assert
    Assert.Equal("Test step content", step.Content);
    Assert.Single(step.MustConstraints);
    Assert.Single(step.MustNotConstraints);
}
```

### Test: Blueprint is immutable after Build

```csharp
[Fact]
public void Blueprint_AfterBuild_IsImmutable()
{
    // Arrange
    var builder = new BlueprintBuilder();
    var stepBuilder = new BlueprintStepBuilder();
    
    IBlueprint blueprint = builder
        .InitNew()
        .WithId("test.blueprint")
        .AddStep(stepBuilder.InitNew().WithContent("Step 1").Build())
        .Build();
    
    // Act & Assert
    Assert.Throws<NotSupportedException>(() => 
        blueprint.Steps.Add(stepBuilder.InitNew().WithContent("Step 2").Build()));
}
```

---

## 2. Integration tests — Module loading

### Test: BlueprintComposerModule registers Blueprint

```csharp
[Fact]
public async Task BlueprintComposerModule_Run_RegistersBlueprint()
{
    // Arrange
    var services = new ServiceCollection();
    services.AddSingleton<IPrompt>(new Prompt());
    services.AddSingleton<IBlueprintBuilder, BlueprintBuilder>();
    services.AddSingleton<IBlueprintStepBuilder, BlueprintStepBuilder>();
    services.AddSingleton<IMustConstraintBuilder, MustConstraintBuilder>();
    // ... other builders
    
    var serviceProvider = services.BuildServiceProvider();
    var module = new BlueprintComposerModule(
        serviceProvider.GetRequiredService<IPrompt>(),
        serviceProvider.GetRequiredService<IBlueprintBuilder>(),
        // ... other dependencies
    );
    
    // Act
    await module.Run(CancellationToken.None);
    
    // Assert
    var prompt = serviceProvider.GetRequiredService<IPrompt>();
    Assert.Single(prompt.Blueprints);
    Assert.Equal("expected.blueprint.id", prompt.Blueprints.First().Id);
}
```

### Test: Multiple Blueprint modules coexist

```csharp
[Fact]
public async Task MultipleBlueprintModules_Run_AllRegistered()
{
    // Arrange
    var services = new ServiceCollection();
    services.AddSingleton<IPrompt>(new Prompt());
    // ... register builders
    
    services.AddSingleton<IBlueprintComposerModule, RazorWebAppBlueprintModule>();
    services.AddSingleton<IBlueprintComposerModule, UserStoryBlueprintModule>();
    
    var serviceProvider = services.BuildServiceProvider();
    var modules = serviceProvider.GetServices<IBlueprintComposerModule>();
    
    // Act
    foreach (var module in modules)
    {
        await module.Run(CancellationToken.None);
    }
    
    // Assert
    var prompt = serviceProvider.GetRequiredService<IPrompt>();
    Assert.Equal(2, prompt.Blueprints.Count);
    Assert.Contains(prompt.Blueprints, b => b.Id == "dotnet.webapp.razor");
    Assert.Contains(prompt.Blueprints, b => b.Id == "agile.userstory");
}
```

### Test: Blueprint loads from NuGet package

```csharp
[Fact]
public async Task ModulesLoader_LoadFromNuGet_LoadsBlueprintModule()
{
    // Arrange
    var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
    Directory.CreateDirectory(tempDir);
    
    var configPath = Path.Combine(tempDir, ".ctxc", "modules", "modules.config.json");
    Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
    
    var config = new
    {
        version = "1.0",
        sources = new[]
        {
            new
            {
                type = "nuget",
                packages = new[]
                {
                    new { id = "ContextCompiler.Blueprints.DotNet.WebApp.Razor", version = "1.0.0" }
                }
            }
        }
    };
    
    File.WriteAllText(configPath, JsonSerializer.Serialize(config));
    
    var services = new ServiceCollection();
    services.AddModulesLoaderServices();
    // ... configure services
    
    var serviceProvider = services.BuildServiceProvider();
    var loader = serviceProvider.GetRequiredService<IModulesLoader>();
    
    // Act
    await loader.LoadFromFolder(Path.Combine(tempDir, ".ctxc", "modules"), services, CancellationToken.None);
    
    // Assert
    var blueprintModules = serviceProvider.GetServices<IBlueprintComposerModule>();
    Assert.NotEmpty(blueprintModules);
    
    // Cleanup
    Directory.Delete(tempDir, recursive: true);
}
```

---

## 3. Rendering tests — Template output

### Test: Blueprint renders with all sections

```csharp
[Fact]
public async Task ScribanTemplate_WithBlueprint_RendersAllSections()
{
    // Arrange
    var prompt = new Prompt
    {
        Blueprints = new List<IBlueprint>
        {
            CreateTestBlueprint()
        }
    };
    
    var templateProvider = new TemplateProvider();
    var template = await templateProvider.GetTemplateAsync(CancellationToken.None);
    
    // Act
    var rendered = template.Render(prompt.ToTemplateModel());
    
    // Assert
    Assert.Contains("# Blueprints", rendered);
    Assert.Contains("## Test Blueprint (test.blueprint)", rendered);
    Assert.Contains("### Objectives", rendered);
    Assert.Contains("### MUST", rendered);
    Assert.Contains("### MUST NOT", rendered);
    Assert.Contains("### Assumptions", rendered);
    Assert.Contains("### Glossary", rendered);
    Assert.Contains("### Commands", rendered);
    Assert.Contains("### Steps", rendered);
    Assert.Contains("#### Étape 1 :", rendered);
}
```

### Test: Steps are auto-numbered

```csharp
[Fact]
public async Task ScribanTemplate_WithMultipleSteps_AutoNumbersSteps()
{
    // Arrange
    var blueprintBuilder = new BlueprintBuilder();
    var stepBuilder = new BlueprintStepBuilder();
    
    var blueprint = blueprintBuilder
        .InitNew()
        .WithId("test.blueprint")
        .WithName("Test Blueprint")
        .WithDescription("Test")
        .AddStep(stepBuilder.InitNew().WithContent("First step").Build())
        .AddStep(stepBuilder.InitNew().WithContent("Second step").Build())
        .AddStep(stepBuilder.InitNew().WithContent("Third step").Build())
        .Build();
    
    var prompt = new Prompt { Blueprints = new[] { blueprint } };
    var templateProvider = new TemplateProvider();
    var template = await templateProvider.GetTemplateAsync(CancellationToken.None);
    
    // Act
    var rendered = template.Render(prompt.ToTemplateModel());
    
    // Assert
    Assert.Contains("#### Étape 1 : First step", rendered);
    Assert.Contains("#### Étape 2 : Second step", rendered);
    Assert.Contains("#### Étape 3 : Third step", rendered);
}
```

### Test: Empty sections are not rendered

```csharp
[Fact]
public async Task ScribanTemplate_WithMinimalBlueprint_OmitsEmptySections()
{
    // Arrange
    var blueprintBuilder = new BlueprintBuilder();
    var stepBuilder = new BlueprintStepBuilder();
    
    var blueprint = blueprintBuilder
        .InitNew()
        .WithId("minimal.blueprint")
        .WithName("Minimal Blueprint")
        .WithDescription("Only has steps")
        .AddStep(stepBuilder.InitNew().WithContent("Single step").Build())
        .Build();
    
    var prompt = new Prompt { Blueprints = new[] { blueprint } };
    var templateProvider = new TemplateProvider();
    var template = await templateProvider.GetTemplateAsync(CancellationToken.None);
    
    // Act
    var rendered = template.Render(prompt.ToTemplateModel());
    
    // Assert
    Assert.Contains("## Minimal Blueprint", rendered);
    Assert.Contains("### Steps", rendered);
    Assert.DoesNotContain("### Objectives", rendered);
    Assert.DoesNotContain("### MUST", rendered);
    Assert.DoesNotContain("### Assumptions", rendered);
    Assert.DoesNotContain("### Glossary", rendered);
    Assert.DoesNotContain("### Commands", rendered);
}
```

### Test: Step constraints render correctly

```csharp
[Fact]
public async Task ScribanTemplate_WithStepConstraints_RendersConstraints()
{
    // Arrange
    var blueprintBuilder = new BlueprintBuilder();
    var stepBuilder = new BlueprintStepBuilder();
    var mustBuilder = new MustConstraintBuilder();
    var mustNotBuilder = new MustNotConstraintBuilder();
    
    var blueprint = blueprintBuilder
        .InitNew()
        .WithId("test.blueprint")
        .WithName("Test Blueprint")
        .WithDescription("Test")
        .AddStep(stepBuilder.InitNew()
            .WithContent("Step with constraints")
            .AddMustConstraint(mustBuilder.InitNew()
                .WithId("STEP1_MUST1")
                .WithText("Must do this")
                .Build())
            .AddMustNotConstraint(mustNotBuilder.InitNew()
                .WithId("STEP1_MUSTNOT1")
                .WithText("Must not do that")
                .Build())
            .Build())
        .Build();
    
    var prompt = new Prompt { Blueprints = new[] { blueprint } };
    var templateProvider = new TemplateProvider();
    var template = await templateProvider.GetTemplateAsync(CancellationToken.None);
    
    // Act
    var rendered = template.Render(prompt.ToTemplateModel());
    
    // Assert
    Assert.Contains("**MUST:**", rendered);
    Assert.Contains("- STEP1_MUST1: Must do this", rendered);
    Assert.Contains("**MUST NOT:**", rendered);
    Assert.Contains("- STEP1_MUSTNOT1: Must not do that", rendered);
}
```

---

## 4. Regression tests — Stability

### Test: Blueprint output is deterministic

```csharp
[Fact]
public async Task ScribanTemplate_SameBlueprint_ProducesSameOutput()
{
    // Arrange
    var blueprint = CreateTestBlueprint();
    var prompt = new Prompt { Blueprints = new[] { blueprint } };
    var templateProvider = new TemplateProvider();
    var template = await templateProvider.GetTemplateAsync(CancellationToken.None);
    
    // Act
    var output1 = template.Render(prompt.ToTemplateModel());
    var output2 = template.Render(prompt.ToTemplateModel());
    
    // Assert
    Assert.Equal(output1, output2);
}
```

### Test: Step numbering is stable

```csharp
[Fact]
public async Task ScribanTemplate_MultipleRenders_StableStepNumbers()
{
    // Arrange
    var blueprint = CreateBlueprintWithSteps(10);
    var prompt = new Prompt { Blueprints = new[] { blueprint } };
    var templateProvider = new TemplateProvider();
    var template = await templateProvider.GetTemplateAsync(CancellationToken.None);
    
    // Act
    var outputs = new List<string>();
    for (int i = 0; i < 5; i++)
    {
        outputs.Add(template.Render(prompt.ToTemplateModel()));
    }
    
    // Assert
    Assert.All(outputs, output =>
    {
        for (int i = 1; i <= 10; i++)
        {
            Assert.Contains($"#### Étape {i} :", output);
        }
    });
    
    Assert.True(outputs.All(o => o == outputs[0]), "All outputs should be identical");
}
```

### Test: Constraint IDs remain stable

```csharp
[Fact]
public void Blueprint_ConstraintIds_RemainStable()
{
    // Arrange
    var blueprintBuilder = new BlueprintBuilder();
    var mustBuilder = new MustConstraintBuilder();
    
    // Act
    var blueprint1 = blueprintBuilder
        .InitNew()
        .WithId("test.blueprint")
        .AddMustConstraint(mustBuilder.InitNew().WithId("MUST1").WithText("Text 1").Build())
        .AddMustConstraint(mustBuilder.InitNew().WithId("MUST2").WithText("Text 2").Build())
        .Build();
    
    var blueprint2 = blueprintBuilder
        .InitNew()
        .WithId("test.blueprint")
        .AddMustConstraint(mustBuilder.InitNew().WithId("MUST1").WithText("Text 1").Build())
        .AddMustConstraint(mustBuilder.InitNew().WithId("MUST2").WithText("Text 2").Build())
        .Build();
    
    // Assert
    Assert.Equal(
        blueprint1.MustConstraints.Select(m => m.Id), 
        blueprint2.MustConstraints.Select(m => m.Id));
}
```

---

## 5. Validation tests — Constraints

### Test: Blueprint requires Id

```csharp
[Fact]
public void BlueprintBuilder_WithoutId_ThrowsException()
{
    // Arrange
    var builder = new BlueprintBuilder();
    
    // Act & Assert
    Assert.Throws<InvalidOperationException>(() => 
        builder
            .InitNew()
            .WithName("Test")
            .Build());  // Missing WithId
}
```

### Test: Blueprint requires Name

```csharp
[Fact]
public void BlueprintBuilder_WithoutName_ThrowsException()
{
    // Arrange
    var builder = new BlueprintBuilder();
    
    // Act & Assert
    Assert.Throws<InvalidOperationException>(() => 
        builder
            .InitNew()
            .WithId("test.blueprint")
            .Build());  // Missing WithName
}
```

### Test: Step requires Content

```csharp
[Fact]
public void BlueprintStepBuilder_WithoutContent_ThrowsException()
{
    // Arrange
    var builder = new BlueprintStepBuilder();
    
    // Act & Assert
    Assert.Throws<InvalidOperationException>(() => 
        builder
            .InitNew()
            .Build());  // Missing WithContent
}
```

### Test: Constraint requires Id and Text

```csharp
[Fact]
public void MustConstraintBuilder_WithoutIdOrText_ThrowsException()
{
    // Arrange
    var builder = new MustConstraintBuilder();
    
    // Act & Assert
    Assert.Throws<InvalidOperationException>(() => 
        builder.InitNew().WithId("MUST1").Build());  // Missing WithText
    
    Assert.Throws<InvalidOperationException>(() => 
        builder.InitNew().WithText("Text").Build());  // Missing WithId
}
```

---

## 6. Performance tests

### Test: Blueprint construction is fast

```csharp
[Fact]
public void BlueprintBuilder_ConstructionPerformance_IsAcceptable()
{
    // Arrange
    var builder = new BlueprintBuilder();
    var stepBuilder = new BlueprintStepBuilder();
    var mustBuilder = new MustConstraintBuilder();
    var stopwatch = Stopwatch.StartNew();
    
    // Act
    for (int i = 0; i < 1000; i++)
    {
        var blueprint = builder
            .InitNew()
            .WithId($"test.blueprint.{i}")
            .WithName("Test Blueprint")
            .WithDescription("Test")
            .AddStep(stepBuilder.InitNew().WithContent("Step 1").Build())
            .AddStep(stepBuilder.InitNew().WithContent("Step 2").Build())
            .AddMustConstraint(mustBuilder.InitNew().WithId("MUST1").WithText("Text").Build())
            .Build();
    }
    
    stopwatch.Stop();
    
    // Assert
    Assert.True(stopwatch.ElapsedMilliseconds < 1000, 
        $"Construction took {stopwatch.ElapsedMilliseconds}ms, expected < 1000ms");
}
```

### Test: Template rendering is fast

```csharp
[Fact]
public async Task ScribanTemplate_RenderingPerformance_IsAcceptable()
{
    // Arrange
    var blueprint = CreateComplexBlueprint();  // 50+ steps, constraints, etc.
    var prompt = new Prompt { Blueprints = new[] { blueprint } };
    var templateProvider = new TemplateProvider();
    var template = await templateProvider.GetTemplateAsync(CancellationToken.None);
    
    var stopwatch = Stopwatch.StartNew();
    
    // Act
    for (int i = 0; i < 100; i++)
    {
        var output = template.Render(prompt.ToTemplateModel());
    }
    
    stopwatch.Stop();
    
    // Assert
    Assert.True(stopwatch.ElapsedMilliseconds < 5000, 
        $"Rendering took {stopwatch.ElapsedMilliseconds}ms, expected < 5000ms");
}
```

---

## 7. Test helpers

### Helper: Create test Blueprint

```csharp
private static IBlueprint CreateTestBlueprint()
{
    var blueprintBuilder = new BlueprintBuilder();
    var stepBuilder = new BlueprintStepBuilder();
    var mustBuilder = new MustConstraintBuilder();
    var objectiveBuilder = new ObjectiveBuilder();
    
    return blueprintBuilder
        .InitNew()
        .WithId("test.blueprint")
        .WithName("Test Blueprint")
        .WithDescription("Test description")
        .AddObjective(objectiveBuilder.InitNew()
            .WithName("OBJ1")
            .WithDescription("Test objective")
            .Build())
        .AddMustConstraint(mustBuilder.InitNew()
            .WithId("MUST1")
            .WithText("Test constraint")
            .Build())
        .AddStep(stepBuilder.InitNew()
            .WithContent("Test step")
            .Build())
        .Build();
}
```

### Helper: Create Blueprint with N steps

```csharp
private static IBlueprint CreateBlueprintWithSteps(int stepCount)
{
    var blueprintBuilder = new BlueprintBuilder();
    var stepBuilder = new BlueprintStepBuilder();
    
    blueprintBuilder.InitNew()
        .WithId("test.blueprint")
        .WithName("Test Blueprint")
        .WithDescription("Test");
    
    for (int i = 1; i <= stepCount; i++)
    {
        blueprintBuilder.AddStep(stepBuilder.InitNew()
            .WithContent($"Step {i}")
            .Build());
    }
    
    return blueprintBuilder.Build();
}
```

---

## Test coverage targets

| Component | Target Coverage |
|-----------|----------------|
| Builders | 100% |
| Domain models | 100% |
| Module registration | 95% |
| Template rendering | 90% |
| Integration (E2E) | 80% |

---

## Continuous testing

### Pre-commit hooks
- Run unit tests on builders
- Validate Blueprint construction

### CI/CD pipeline
- Full test suite on every commit
- Integration tests with NuGet packages
- Rendering regression tests
- Performance benchmarks

### Release validation
- End-to-end tests with real modules
- Verify deterministic output
- Validate NuGet package integrity
- Check backward compatibility

---

**END OF TESTING STRATEGY**
