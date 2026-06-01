# Example: Using Skills Store with Copilot Agent

This example shows how the Skills store is used with the Copilot agent module.

## Understanding the Store-Based Architecture

The ContextCompiler uses a store-based architecture for managing resources. The Skills store (`StoreKeys.Skills`) is used to determine where skill artifacts are deployed.

### Key Components

1. **IStore**: The store interface injected with `[FromKeyedServices(StoreKeys.Skills)]`
2. **IStoreResource**: Represents a resource within the store
3. **SkillsArtifactEnrichmentModule**: Uses the store to create artifact resources

## How It Works

```csharp
// In SkillsArtifactEnrichmentModule
public sealed class SkillsArtifactEnrichmentModule(
	[FromKeyedServices(StoreKeys.Skills)] IStore skillsStore,
	// ... other dependencies
) : IGlobalPipelineModule
{
	public Task<IResult<IGlobalPipelineRunResult>> Run(...)
	{
		// Create a resource in the Skills store
		IStoreResource skillResource = skillsStore.GetResource($"{skillId}/{relativePath}");

		// Register as artifact
		output.AddArtifact(builder => builder
			.WithStoreResource(skillResource)
			.WithContent(content)
			// ...
		);
	}
}
```

## Configuring the Skills Store

### Infrastructure Level (Recommended)

The Skills store is configured in the Infrastructure layer:

```csharp
// src/Core/ContextCompiler.Infrastructure/Storage/DependencyInjection.cs
services.TryAddDefaultStore(StoreKeys.Skills);

// This creates a store with default configuration
// The store inherits from the Root store configuration
```

### Custom Store Configuration

To customize the Skills store path:

```csharp
services.TryAddKeyedSingleton(StoreKeys.Skills, (sp, o) =>
{
	var builder = sp.GetRequiredService<IStoreConfigurationBuilder>();
	var rootConfig = sp.GetRequiredKeyedService<IStoreConfiguration>(StoreKeys.Root);

	return builder.InitNew()
		.WithParentId(StoreKeys.Root)
		.WithRootUri(rootConfig.Root.Combine(".copilot/skills"))
		.Build();
});
```

## Using the Copilot Agent Module

### Basic Usage

```csharp
using ContextCompiler.Agents.Modules.Copilot;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register infrastructure (includes Skills store)
services.AddFileSystemStorage();

// Register Copilot agent
services.AddCopilotAgent();

var provider = services.BuildServiceProvider();
```

### Accessing the Skills Store

```csharp
// Get the Skills store
var skillsStore = provider.GetKeyedService<IStore>(StoreKeys.Skills);

// Create a resource
var resource = skillsStore.GetResource("my-skill/skill.md");

// Use the resource URI
var uri = skillsStore.Combine("my-skill/skill.md");
```

## Example: Complete Flow

### 1. Infrastructure Setup

```csharp
// Program.cs or Startup.cs
services
	.AddFileSystemStorage()  // Registers all stores including Skills
	.AddCopilotAgent()       // Registers Copilot configuration
	.AddCompileCoreServices();
```

### 2. Skills Store Configuration (Optional)

By default, the Skills store uses the Root store configuration. To customize:

```csharp
// Custom configuration for Skills store
services.PostConfigure<StoreConfiguration>(StoreKeys.Skills, config =>
{
	// Customize store behavior
	config.BasePath = ".agents/copilot-skills";
});
```

### 3. Module Usage

The `SkillsArtifactEnrichmentModule` automatically:
- Injects `IStore` with key `StoreKeys.Skills`
- Scans the skills cache
- Creates resources using `skillsStore.GetResource(path)`
- Registers artifacts with `WithStoreResource()`

## Comparison with Other Approaches

### RagStore Pattern (Similar)

```csharp
// RagStore uses the same pattern
public sealed class RagStore(
	[FromKeyedServices(StoreKeys.Cache)] IStore cacheStore
) : IRagStore
{
	private readonly IStore _rootPath = cacheStore.CreateContainer("rag");
	private readonly IStoreResource _chunksPath = _rootPath.GetResource("chunks.jsonl");

	// Uses WithStoreResource() for artifacts
	_output.AddArtifact(builder => builder.WithStoreResource(_chunksPath));
}
```

### Skills Pattern (Current)

```csharp
// SkillsArtifactEnrichmentModule uses Skills store
public sealed class SkillsArtifactEnrichmentModule(
	[FromKeyedServices(StoreKeys.Skills)] IStore skillsStore
) : IGlobalPipelineModule
{
	// Create resources dynamically
	IStoreResource skillResource = skillsStore.GetResource($"{skillId}/{file}");

	// Register with WithStoreResource()
	output.AddArtifact(builder => builder.WithStoreResource(skillResource));
}
```

## Benefits of Store-Based Approach

1. **Consistency**: Same pattern across all modules (RAG, Output, Skills, etc.)
2. **Abstraction**: Modules don't manage physical paths
3. **Flexibility**: Store configuration is centralized
4. **Testability**: Easy to mock `IStore` for testing
5. **Type Safety**: `IStoreResource` instead of string paths

## Testing

### Unit Test Example

```csharp
[Test]
public void Test_SkillsStoreResourceCreation()
{
	// Arrange
	var mockStore = new Mock<IStore>();
	var mockResource = new Mock<IStoreResource>();

	mockStore.Setup(s => s.GetResource(It.IsAny<string>()))
			 .Returns(mockResource.Object);

	// Act
	var resource = mockStore.Object.GetResource("test-skill/skill.md");

	// Assert
	Assert.That(resource, Is.Not.Null);
}

[Test]
public void Test_SkillsStoreInjection()
{
	// Arrange
	var services = new ServiceCollection();
	services.AddFileSystemStorage();

	// Act
	var provider = services.BuildServiceProvider();
	var skillsStore = provider.GetKeyedService<IStore>(StoreKeys.Skills);

	// Assert
	Assert.That(skillsStore, Is.Not.Null);
	Assert.That(skillsStore.Key, Is.EqualTo(StoreKeys.Skills));
}
```

## Multiple Agents

The Skills store can be used by multiple agent modules:

```csharp
// Both Copilot and Claude can use the same Skills store
services.AddCopilotAgent();
services.AddClaudeAgent();

// The store configuration determines the actual deployment location
// Agent-specific paths can be configured at the store level
```

## Advanced: Custom Store Implementation

If you need a completely different storage mechanism:

```csharp
public class CustomSkillsStore : IStore
{
	public string Key => StoreKeys.Skills;

	public IStoreResourceUri Uri => /* custom URI */;

	public IStoreResource GetResource(string relativePath)
	{
		// Custom resource creation logic
		return new CustomStoreResource(relativePath);
	}

	// ... other implementations
}

// Register
services.AddKeyedSingleton<IStore>(StoreKeys.Skills, new CustomSkillsStore());
```

## Summary

- **Skills Store** (`StoreKeys.Skills`) is the central configuration point
- **SkillsArtifactEnrichmentModule** injects and uses the store
- **Copilot Module** provides agent-specific configuration
- **Store pattern** ensures consistency across ContextCompiler

