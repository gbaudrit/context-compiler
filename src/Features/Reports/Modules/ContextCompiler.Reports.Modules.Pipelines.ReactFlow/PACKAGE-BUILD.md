# Creating a NuGet Package for ReactFlow Module

This document explains how to create a NuGet package for the ReactFlow pipeline visualization module.

## Prerequisites

1. **.NET SDK 10+** installed
2. **Node.js 18+** installed (for building the React app)

## 🚀 Quick Start (Automatic Build)

Creating a package is now as simple as:

```bash
dotnet pack --configuration Release
```

The React application will be **automatically built** if needed. That's it! ✨

## Build Process (Automatic)

When you run `dotnet pack`, the build system automatically:

1. ✅ Checks if `react-app/dist/index.html` exists
2. ✅ If missing: runs `npm install && npm run build`
3. ✅ If exists: skips the build (smart caching)
4. ✅ Includes the pre-built React app in the package

**No manual steps required!**

## Manual Build (Optional)

If you prefer to build the React app manually first:

```powershell
# Navigate to the module directory
cd src/Features/Reports/Modules/ContextCompiler.Reports.Modules.Pipelines.ReactFlow

# Build React app
.\build-react-app.ps1

# Create package
dotnet pack --configuration Release
```

## What's Included in the Package

The NuGet package includes:

- ✅ **Compiled .NET assemblies** (.dll)
- ✅ **Pre-built React app** (`react-app/dist/**`)
- ✅ **Documentation** (README.md, ARCHITECTURE.md, USAGE.md, CHANGELOG.md)

**Not included** (to keep package small):
- ❌ React source files (`react-app/src/**`)
- ❌ npm dependencies (`react-app/node_modules/**`)
- ❌ Development files (tsconfig.json, vite.config.ts, etc.)

## Package Size

Expected package size: **~2-5 MB**
- .NET assemblies: ~100-200 KB
- React dist: ~1.5-4 MB (includes React, React Flow, ELK.js, Zustand)

## Verifying the Package

After creating the package, you can inspect its contents:

```bash
# Extract the .nupkg (it's just a ZIP file)
unzip ContextCompiler.Reports.Modules.Pipelines.ReactFlow.1.0.0.nupkg -d extracted

# Check the contents
ls extracted
```

You should see:
```
extracted/
├── lib/
│   └── net10.0/
│       └── ContextCompiler.Reports.Modules.Pipelines.ReactFlow.dll
├── contentFiles/
│   └── any/
│       └── any/
│           └── react-app/
│               └── dist/
│                   ├── index.html
│                   └── assets/
│                       ├── index-[hash].js
│                       └── index-[hash].css
├── README.md
├── ARCHITECTURE.md
├── USAGE.md
└── CHANGELOG.md
```

## CI/CD Integration

The automatic build makes CI/CD integration very simple!

### Azure DevOps

```yaml
steps:
- task: NodeTool@0
  displayName: 'Install Node.js'
  inputs:
	versionSpec: '18.x'

- task: DotNetCoreCLI@2
  displayName: 'Create NuGet Package'
  inputs:
	command: 'pack'
	packagesToPack: 'src/Features/Reports/Modules/ContextCompiler.Reports.Modules.Pipelines.ReactFlow/ContextCompiler.Reports.Modules.Pipelines.ReactFlow.csproj'
	configuration: 'Release'
	packDirectory: '$(Build.ArtifactStagingDirectory)'

# React app is built automatically!

- task: PublishBuildArtifacts@1
  displayName: 'Publish NuGet Package'
  inputs:
	PathtoPublish: '$(Build.ArtifactStagingDirectory)'
	ArtifactName: 'packages'
```

### GitHub Actions

```yaml
name: Build and Pack

on:
  push:
	branches: [ main ]
  pull_request:
	branches: [ main ]

jobs:
  build:
	runs-on: windows-latest

	steps:
	- uses: actions/checkout@v3

	- name: Setup Node.js
	  uses: actions/setup-node@v3
	  with:
		node-version: '18'

	- name: Setup .NET
	  uses: actions/setup-dotnet@v3
	  with:
		dotnet-version: '10.0.x'

	- name: Create Package
	  run: dotnet pack --configuration Release

	# React app is built automatically!

	- name: Upload NuGet package
	  uses: actions/upload-artifact@v3
	  with:
		name: nuget-packages
		path: ./bin/Release/*.nupkg
```

## Publishing to NuGet.org

Once the package is built and verified:

```bash
# Push to NuGet.org
dotnet nuget push bin/Release/ContextCompiler.Reports.Modules.Pipelines.ReactFlow.1.0.0.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```

Or to a private feed:

```bash
# Push to Azure Artifacts
dotnet nuget push bin/Release/ContextCompiler.Reports.Modules.Pipelines.ReactFlow.1.0.0.nupkg --api-key az --source https://pkgs.dev.azure.com/yourorg/_packaging/yourfeed/nuget/v3/index.json
```

## Troubleshooting

### Error: dist folder not found

**Problem:** The React app wasn't built before creating the package.

**Solution:** Run `.\build-react-app.ps1` first.

### Error: Node.js not found

**Problem:** Node.js isn't installed or not in PATH.

**Solution:** Install Node.js from https://nodejs.org/ and restart your terminal.

### Package is too large

**Problem:** node_modules or source files are included.

**Solution:** Check `.csproj` file - only `react-app/dist/**` should be included.

### React app doesn't work when consuming the package

**Problem:** The dist folder wasn't committed or the package was built without running the build script.

**Solution:**
1. Ensure `react-app/dist/` is committed to source control
2. Run `.\build-react-app.ps1` before packaging
3. Verify the package contents (see "Verifying the Package" above)

## Version Management

When releasing a new version:

1. Update `CHANGELOG.md` with changes
2. Update version in `.csproj` if using explicit versioning
3. Build React app: `.\build-react-app.ps1`
4. Create package: `dotnet pack --configuration Release`
5. Tag the release in git: `git tag v1.0.1`
6. Push to NuGet.org or private feed

## Best Practices

1. **Always build React app first** before creating NuGet package
2. **Commit the dist folder** to source control (it's needed for the package)
3. **Test the package locally** before publishing:
   ```bash
   dotnet add package ContextCompiler.Reports.Modules.Pipelines.ReactFlow --source ./bin/Release
   ```
4. **Document breaking changes** in CHANGELOG.md
5. **Semantic versioning**: Major.Minor.Patch (e.g., 1.2.3)
   - Major: Breaking changes
   - Minor: New features (backward compatible)
   - Patch: Bug fixes
