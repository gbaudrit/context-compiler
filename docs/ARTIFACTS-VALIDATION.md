# Artifact Validation System - Implementation Guide

## Overview
This document describes the artifact validation architecture for Context Compiler, with a focus on Skills validation and deployment.

## Architecture

### Double Validation Strategy

```
┌─────────────────────────────────────────────┐
│ PHASE 1: RESTORE (CLI)                      │
│ - Lightweight validation                    │
│ - Checksum verification                     │
│ - Trust validation                          │
│ - Structure check                           │
│ - Store in cache                            │
└─────────────────────────────────────────────┘
			   ↓
┌─────────────────────────────────────────────┐
│ PHASE 2: PIPELINE VALIDATION               │
│ - Prerequisites check (tools, versions)     │
│ - Deep security scan                        │
│ - Policy enforcement                        │
│ - Selective deployment                      │
└─────────────────────────────────────────────┘
```

## Enhanced Interfaces

### IOutputArtifact
```csharp
public interface IOutputArtifact
{
	IStoreResource StoreResource { get; init; }
	string Content { get; init; }
	string Description { get; init; }
	Type GeneratedBy { get; init; }
	string MimeType { get; init; }
	long Size { get; init; }

	// NEW
	ArtifactCategory Category { get; init; }
	IReadOnlyDictionary<string, string> Metadata { get; init; }
}

public enum ArtifactCategory
{
	Context, Evidence, Report, Graph, View,
	Skill, Tool, Configuration, Other
}
```

### ISkillProvider
```csharp
public interface ISkillProvider
{
	string ProviderId { get; }

	Task<SkillPackage> RestoreAsync(
		SkillDescriptor descriptor, 
		CancellationToken ct);

	// NEW
	Task<SkillRestoreResult> RestoreWithValidationAsync(
		SkillDescriptor descriptor, 
		RestoreOptions options, 
		CancellationToken ct);
}

public record RestoreOptions(
	bool IncludeValidation = true,
	TrustMode TrustMode = TrustMode.Permissive,
	bool VerifyChecksum = true,
	bool CheckStructure = true
);

public record SkillRestoreResult(
	SkillPackage Package,
	IReadOnlyList<RestoreFinding> Findings
);

public record RestoreFinding(
	string Code,
	RestoreSeverity Severity,
	string Message
);
```

## GlobalPipeline Phases

### Updated GlobalPipelineModuleKinds
```csharp
public enum GlobalPipelineModuleKinds
{
	Setup = 100000,
	InputDiscovery = 200000,
	InputIngestion = 300000,
	ContextProcessing = 400000,
	PolicyEnforcement = 500000,
	OutputComposition = 600000,
	OutputProjection = 700000,
	ReportComposition = 850000,
	ArtifactRendering = 900000,

	// NEW
	PrerequisitesEnrichment = 950000,  // Scan & register prerequisites as artifacts
	ArtifactValidation = 970000,        // Guards on artifacts

	ArtifactPersistence = 1000000,      // Filtered deployment
	PostProcessing = 1100000,
}
```

### GuardStage Enhancement
```csharp
public enum GuardStage 
{ 
	Discovery, Read, Fragment, View, Preflight,

	// NEW
	ArtifactValidation  // For validating artifacts before deployment
}
```

## Module Implementation Pattern

### 1. SkillsArtifactEnrichmentModule (PrerequisitesEnrichment phase)

**Responsibility**: Scan cached skills and register as artifacts

```csharp
public sealed class SkillsArtifactEnrichmentModule : IGlobalPipelineModule
{
	public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
		"skills-artifact-enrichment", 
		GlobalPipelineModuleKinds.PrerequisitesEnrichment, 
		priority: 1000);

	public Task<IResult<IGlobalPipelineRunResult>> Run(
		IGlobalPipelineRunContext context, 
		CancellationToken ct)
	{
		// 1. Get skills config
		SkillsConfig config = _skillsConfigProvider.Current;

		// 2. For each skill in cache:
		//    - Enumerate files
		//    - Create IOutputArtifact with Category = Skill
		//    - Add metadata: skillId, provider, version, sourcePath
		//    - Register in IOutput.Artifacts

		output.AddArtifact(builder => builder
			.InitNew()
			.WithCategory(ArtifactCategory.Skill)
			.WithName($"skills/{skillId}/{relativePath}")
			.WithMetadata("skillId", skillId)
			.WithMetadata("provider", provider)
			.WithMetadata("version", version)
			.WithMetadata("sourcePath", fullPath)
		);

		return context.Success();
	}
}
```

### 2. ArtifactPrerequisitesGuardModule (ArtifactValidation phase)

**Responsibility**: Validate prerequisites (tools, versions)

```csharp
public sealed class ArtifactPrerequisitesGuardModule : IGlobalPipelineModule
{
	public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
		"artifact-prerequisites-guard", 
		GlobalPipelineModuleKinds.ArtifactValidation, 
		priority: 1000);

	public Task<IResult<IGlobalPipelineRunResult>> Run(
		IGlobalPipelineRunContext context, 
		CancellationToken ct)
	{
		// 1. Filter artifacts where Category == Skill
		// 2. Parse PREREQUISITES.md or SKILL.md for required tools
		// 3. Check each tool availability and version:
		//    - docker --version
		//    - git --version
		//    - node --version
		//    - python --version
		// 4. Generate GuardFinding for missing/outdated tools

		if (!toolAvailable)
		{
			_guardian.AddFinding(new GuardFinding(
				GuardId: "prerequisites-missing",
				Severity: GuardSeverity.Critical,
				Action: GuardActionKind.Block,
				Message: $"Skill '{skillId}' requires {tool} {version}",
				Source: sourceRef
			));
		}

		return context.Success();
	}
}
```

### 3. ArtifactSecurityGuardModule (ArtifactValidation phase)

**Responsibility**: Deep security scan

```csharp
public sealed class ArtifactSecurityGuardModule : IGlobalPipelineModule
{
	public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
		"artifact-security-guard", 
		GlobalPipelineModuleKinds.ArtifactValidation, 
		priority: 2000);

	public Task<IResult<IGlobalPipelineRunResult>> Run(
		IGlobalPipelineRunContext context, 
		CancellationToken ct)
	{
		// 1. Filter skill artifacts
		// 2. Scan content for threats:
		//    - eval(), exec() calls
		//    - System commands (subprocess, os.system)
		//    - Hardcoded secrets (password=, api_key=)
		//    - Untrusted URLs
		//    - Destructive commands (rm -rf)
		//    - Suspicious keywords
		// 3. Generate GuardFinding per threat

		// Use Regex patterns:
		Regex evalPattern = new(@"\beval\s*\(", RegexOptions.IgnoreCase);
		Regex secretPattern = new(
			@"(password|secret|api[_-]?key)\s*[=:]\s*[""'][^""']+[""']", 
			RegexOptions.IgnoreCase);

		return context.Success();
	}
}
```

### 4. FilteredArtifactDeploymentModule (ArtifactPersistence phase)

**Responsibility**: Deploy validated artifacts

```csharp
public sealed class FilteredArtifactDeploymentModule : IGlobalPipelineModule
{
	public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
		"filtered-artifact-deployment", 
		GlobalPipelineModuleKinds.ArtifactPersistence, 
		priority: 1000);

	public Task<IResult<IGlobalPipelineRunResult>> Run(
		IGlobalPipelineRunContext context, 
		CancellationToken ct)
	{
		// 1. Check for critical blocking findings
		if (_guardian.HasBlockingCriticalFindings())
		{
			logger.LogError("Deployment blocked");
			return context.Failure("Critical findings block deployment");
		}

		// 2. For each artifact where Category == Skill:
		//    - Check if specific artifact has blocking findings
		//    - If blocked: skip
		//    - If OK: copy from cache to .agents/skills/{skillId}/

		// 3. Generate artifacts.deployment.report.md

		return context.Success();
	}
}
```

## Configuration Schema

### ctxc.config.json
```json
{
  "schemaVersion": 2,
  "skills": {
	"mode": "Restore",
	"cacheRoot": ".ctxc/cache/skills",
	"compiledRoot": ".ctxc/compiled/.agents/skills",
	"lockFile": ".ctxc/ctxc.skills.lock.json",

	"validation": {
	  "enabled": true,
	  "failOnCritical": true,
	  "skipOnWarning": false,

	  "prerequisites": {
		"enabled": true,
		"requiredTools": ["docker", "git"],
		"minVersions": {
		  "docker": "20.0.0",
		  "git": "2.0.0"
		}
	  },

	  "security": {
		"enabled": true,
		"blockEvalExec": true,
		"blockSystemCalls": false,
		"blockHardcodedSecrets": true,
		"warnExternalUrls": true,
		"whitelistedDomains": [
		  "github.com",
		  "anthropic.com"
		]
	  },

	  "deployment": {
		"targetPath": ".agents/skills",
		"overwriteExisting": true,
		"generateReport": true,
		"reportPath": "artifacts.deployment.report.md"
	  }
	}
  }
}
```

## Output Report

### artifacts.deployment.report.md

```markdown
# Artifacts Deployment Report

Generated: 2025-01-15 14:30:00 UTC

## Summary
- ✅ Deployed: 10 skills
- ⚠️ Skipped: 1 skill
- ❌ Blocked: 1 skill

## Guard Findings

### 🔴 [CRITICAL] prerequisites-missing
- **Message**: Skill 'mcp-builder' requires docker >= 20.0.0
- **Action**: Block
- **Source**: skill:mcp-builder

### 🔴 [CRITICAL] security-eval-detected
- **Message**: Dangerous eval() call detected in tool.js:42
- **Action**: Block
- **Source**: .ctxc/cache/skills/skill-creator/tool.js
- **Location**: Line 42

## Deployment Details

| Skill ID | Status | Files | Reason |
|----------|--------|-------|--------|
| skill-creator | ❌ Blocked | - | Security finding |
| mcp-builder | ⚠️ Skipped | - | Missing docker |
| doc-coauthoring | ✅ Deployed | 8 | - |
| claude-api | ✅ Deployed | 5 | - |
```

## Implementation Steps

1. ✅ Add `ArtifactCategory` enum and enhance `IOutputArtifact`
2. ✅ Update `IOutputArtifactBuilder` with `WithCategory()` and `WithMetadata()`
3. ✅ Add `GuardStage.ArtifactValidation`
4. ✅ Enhance `ISkillProvider` with `RestoreWithValidationAsync()`
5. ✅ Implement restore validation in `AnthropicSkillProvider`
6. ✅ Add validation configuration to `SkillsConfig`
7. ⏳ Implement `SkillsArtifactEnrichmentModule`
8. ⏳ Implement `ArtifactPrerequisitesGuardModule`
9. ⏳ Implement `ArtifactSecurityGuardModule`
10. ⏳ Implement `FilteredArtifactDeploymentModule`
11. ⏳ Wire up modules in DependencyInjection
12. ⏳ Integration tests

## Notes

- Modules must implement `IGlobalPipelineModule` with correct signature: `Task<IResult<IGlobalPipelineRunResult>> Run(...)`
- Use `IGlobalPipelineModule.Meta()` helper for metadata creation
- Return `context.Success()` or `context.Failure()` from Run method
- IGuardian should be injected to add findings
- Configuration is accessible via `ISkillsLoadConfigProvider.Current`
