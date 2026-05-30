# ContextCompiler.Agents.Modules.Copilot

Agent configuration module for GitHub Copilot integration.

## Overview

This module provides configuration for GitHub Copilot agent, managing the skills deployment through the Skills store configuration. The module configures where skill artifacts are deployed by working with ContextCompiler's store system.

## Features

- **Store-based Configuration**: Leverages ContextCompiler's IStore system with the Skills key
- **Customizable Skills Path**: Configure where skill artifacts are deployed via SkillsConfig
- **Seamless Integration**: Works with the Skills store (StoreKeys.Skills)
- **Extensible Metadata**: Support for additional agent-specific configuration
- **Dependency Injection**: Standard .NET DI integration

## Installation

```bash
dotnet add package ContextCompiler.Agents.Modules.Copilot
```

## How It Works

The module works with the **Skills store** (`StoreKeys.Skills`):

1. The `SkillsArtifactEnrichmentModule` injects `IStore` using `[FromKeyedServices(StoreKeys.Skills)]`
2. The store is used to construct resource paths: `skillsStore.GetResource($"{skillId}/{relativePath}")`
3. Artifacts are registered with `WithStoreResource()` instead of hardcoded paths
4. The store's configuration determines the actual deployment location

### Architecture Flow

```
SkillsArtifactEnrichmentModule 
	↓ injects
IStore (key: Skills)
	↓ uses
GetResource(relativePath)
	↓ creates
IStoreResource
	↓ passed to
output.AddArtifact(builder => builder.WithStoreResource(...))
```

## Usage

### Basic Registration

```csharp
services.AddCopilotAgent();
```

This registers the Copilot agent with default configuration and sets up the Skills store integration.

### Custom Configuration

The actual deployment path is configured through the **Skills store configuration** in the Infrastructure layer, not directly in this module:

```csharp
// In Infrastructure/Storage/DependencyInjection.cs
services.TryAddKeyedSingleton(StoreKeys.Skills, (sp, o) =>
{
	var builder = sp.GetRequiredService<IStoreConfigurationBuilder>();
	var rootConfig = sp.GetRequiredKeyedService<IStoreConfiguration>(StoreKeys.Root);

	return builder.InitNew()
		.WithParentId(StoreKeys.Root)
		.WithRootUri(rootConfig.Root.Combine(".agents/skills")) // Configure path here
		.Build();
});
```

### Configuration File

You can also configure via `modules.json`:

```json
{
  "skills": {
	"validation": {
	  "deployment": {
		"targetPath": ".agents/skills"
	  }
	}
  }
}
```

**Note**: The `targetPath` is now used for documentation/validation purposes. The actual deployment location is determined by the Skills store configuration.

## Store-based Approach Benefits

1. **Consistency**: Uses the same pattern as other ContextCompiler features (RAG, Output, etc.)
2. **Flexibility**: Store configuration can be customized at the Infrastructure level
3. **Abstraction**: Modules don't need to know about physical paths
4. **Testability**: Easy to mock IStore for unit tests

## Integration Example

```csharp
// Startup configuration
services
	.AddFileSystemStorage()      // Registers all stores including Skills
	.AddCopilotAgent()           // Configures Copilot settings
	.AddCompileCoreServices();

// The SkillsArtifactEnrichmentModule will:
// 1. Inject IStore with key StoreKeys.Skills
// 2. Use skillsStore.GetResource(path) to create resources
// 3. Register artifacts with WithStoreResource()
```

## Comparison: Before vs After

### Before (hardcoded paths)
```csharp
string artifactPath = $".agents/skills/{skillId}/{relativePath}";
output.AddArtifact(builder => builder
	.WithName(artifactPath)
	.InStore("Output")
	// ...
);
```

### After (store-based)
```csharp
IStoreResource skillResource = skillsStore.GetResource($"{skillId}/{relativePath}");
output.AddArtifact(builder => builder
	.WithStoreResource(skillResource)
	// ...
);
```

## Extending for Other Agents

To create a module for another agent (e.g., Claude):

1. Create `ContextCompiler.Agents.Modules.Claude` project
2. The store system already supports custom paths via configuration
3. Create `AddClaudeAgent()` to configure agent-specific metadata

**Key Point**: You don't need to create a separate store for each agent. The Skills store can be configured differently based on the active agent module.

## Testing

```csharp
[Test]
public void Test_SkillsStoreInjected()
{
	var services = new ServiceCollection();
	services.AddFileSystemStorage();
	services.AddCopilotAgent();

	var provider = services.BuildServiceProvider();
	var skillsStore = provider.GetKeyedService<IStore>(StoreKeys.Skills);

	Assert.That(skillsStore, Is.Not.Null);
	Assert.That(skillsStore.Key, Is.EqualTo(StoreKeys.Skills));
}
```

## License

See the main ContextCompiler repository for license information.

