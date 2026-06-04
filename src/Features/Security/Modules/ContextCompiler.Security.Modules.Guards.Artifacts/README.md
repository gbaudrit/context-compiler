# Artifacts Security Guard Module

## Overview

Security guard module that scans output artifacts for security threats before deployment.

## Features

- **Dangerous Code Detection**: Identifies risky patterns like `eval()`, `exec()`, subprocess calls
- **Secret Scanning**: Detects hardcoded passwords, API keys, tokens, credentials
- **External URL Validation**: Flags untrusted external URLs (whitelist: github.com, anthropic.com, microsoft.com)
- **Keyword Analysis**: Detects suspicious keywords (malware, backdoor, exfiltrate, etc.)

## Supported Artifact Categories

- **Skills** (`ArtifactCategory.Skill`)
- **Tools** (`ArtifactCategory.Tool`)
- **Configuration** (`ArtifactCategory.Configuration`)

## Scanned File Types

Text-based files: `.md`, `.txt`, `.json`, `.js`, `.ts`, `.py`, `.yaml`, `.yml`, `.sh`, `.ps1`, `.cs`, `.java`, `.go`, `.rs`, `.rb`, `.php`

## Threat Detection Patterns

### Dangerous Code
- `eval(`, `exec(`
- `subprocess`, `os.system`, `shell=True`
- `process.start`, `ProcessStartInfo`
- `cmd.exe`, `powershell.exe`
- `rm -rf`, `rmdir /s`

### Secret Patterns
- `password=`, `secret=`, `api_key=`, `apikey=`, `token=`, `credentials=`
- Only flagged when combined with quotes (`"` or `'`)

### Suspicious Keywords
- `exfiltrate`, `backdoor`, `malware`, `trojan`, `ransomware`, `keylogger`, `stealer`

### Trusted Domains
- `github.com`
- `githubusercontent.com`
- `anthropic.com`
- `microsoft.com`

## Behavior

When threats are detected in an artifact group (e.g., all files of a skill):
1. Logs warnings for each specific threat with file and line number
2. Marks ALL artifacts in the group with:
   - `metadata["excluded"] = "true"`
   - `metadata["exclusionReason"] = "security-threats"`
3. Continues scanning other groups

## Integration

### Pipeline Phase
- **Phase**: `ArtifactValidation` (970000)
- **Priority**: 2000
- **Module ID**: `security.guard.artifacts`

### Example Output

```
⚠️  Security threat in Skill:skill-creator, file tool.js: [dangerous-code] Dangerous pattern 'eval(' detected at line 42
❌ Skill:skill-creator contains security threats - marking for exclusion
✅ Security scan complete: scanned 18 files, found 3 threats, excluded 12 artifacts
```

## Usage

The module runs automatically during the `ArtifactValidation` phase of the `CompilePipeline`. No manual invocation required.

Excluded artifacts will be skipped by `OutputArtifactsFilesWriterModule` during the `ArtifactPersistence` phase.

## Configuration

Currently uses hardcoded patterns and trusted domains. Future versions may support configuration via `ctxc.config.json`:

```json
{
  "security": {
	"artifacts": {
	  "enabled": true,
	  "trustedDomains": ["github.com", "yourdomain.com"],
	  "dangerousPatterns": ["eval(", "exec("],
	  "failOnThreats": true
	}
  }
}
```

## Extensibility

To add support for new artifact types:
1. Add check in `Run()`: `a.Category == ArtifactCategory.YourType`
2. Ensure artifacts have an identifier metadata (e.g., `yourTypeId`)
3. Group will automatically be created as `YourType:identifier`

## Related Modules

- `SkillsArtifactEnrichmentModule` - Registers skills as artifacts
- `OutputArtifactsFilesWriterModule` - Respects exclusions during deployment
- `DataPartGuardModule` - Similar guard for data parts during input ingestion
