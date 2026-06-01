# Building the ReactFlow Module

This module includes a **React application** that is **automatically built** before creating the NuGet package.

## 🚀 Quick Start (Automatic Build)

Simply run:

```bash
dotnet pack --configuration Release
```

The React app will be **automatically built** if needed. That's it! ✨

## How It Works

The `.csproj` file includes a custom MSBuild target that:

1. ✅ Checks if `react-app/dist/index.html` exists
2. ✅ If missing: automatically runs `npm install && npm run build`
3. ✅ If exists: skips the build (smart caching)
4. ✅ Validates Node.js/npm are installed
5. ✅ Shows clear progress messages

**Requirements:**
- Node.js 18+ must be installed and in PATH
- npm must be available

## Development Workflow

### React Development

```bash
cd react-app
npm run dev  # Starts Vite dev server with hot reload on http://localhost:5173
```

Make your changes, save, and see live updates in the browser.

### .NET Development

```bash
dotnet build  # Builds .NET (auto-builds React if needed)
dotnet test   # Run tests
```

### Creating a Package

```bash
# Automatic (recommended) - React is built automatically if needed
dotnet pack --configuration Release

# Package created in bin/Release/
```

## Manual Build (Optional)

You can manually build the React app if you prefer:

```powershell
# Using the build script
.\build-react-app.ps1
```

Or with npm directly:

```bash
cd react-app
npm install
npm run build
cd ..
```

## Clean Build

To force a complete rebuild:

```bash
dotnet clean  # Removes both .NET and React builds
dotnet pack   # Rebuilds everything automatically
```

Or clean React only:

```bash
Remove-Item -Recurse -Force react-app\dist
dotnet pack  # Will rebuild React automatically
```

## CI/CD Integration

The automatic build works seamlessly in CI/CD pipelines. Just ensure Node.js is installed:

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
	packagesToPack: '**/ContextCompiler.Reports.Modules.Pipelines.ReactFlow.csproj'
	configuration: 'Release'

# That's it! React is built automatically
```

### GitHub Actions

```yaml
steps:
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

# React is built automatically!
```

## Build Messages

During `dotnet pack`, you'll see:

```
🔍 Checking if React app needs to be built...
🔨 Building React app...
📦 Installing npm dependencies...
⚛️ Building React app (this may take a minute)...
✅ React app built successfully!
```

Or if already built:

```
🔍 Checking if React app needs to be built...
✅ React app already built (dist/index.html exists)
```

## What Gets Packaged

The NuGet package includes:

- ✅ Compiled .NET assemblies (`.dll`)
- ✅ Pre-built React app (`react-app/dist/**`)
  - Optimized JavaScript bundles
  - CSS stylesheets
  - `index.html`
- ✅ Documentation files

**Not included** (keeps package small):

- ❌ React source files (`react-app/src/**`)
- ❌ npm dependencies (`react-app/node_modules/**`)
- ❌ TypeScript/Vite config files

Expected package size: **~2-5 MB**

## Troubleshooting

### Error: Node.js not found

**Problem:**
```
❌ Node.js is not installed or not in PATH.
```

**Solution:** Install Node.js from https://nodejs.org/ and restart your terminal.

### npm build failed

**Problem:** TypeScript compilation errors

**Solution:** Build manually to see detailed errors:
```bash
cd react-app
npm run build
```

### Stale Build

**Problem:** Changes not reflected in package

**Solution:** Force rebuild:
```bash
Remove-Item -Recurse -Force react-app\dist
dotnet pack --configuration Release
```

### "dist already exists" but want to rebuild

**Problem:** dist/ exists but you want a fresh build

**Solution:** Clean first:
```bash
dotnet clean
dotnet pack --configuration Release
```

## Advanced: Skip Auto-Build

If you want complete control (not recommended for most users):

```bash
# Manually build React first
cd react-app && npm run build && cd ..

# Pack (auto-build will be skipped since dist/ exists)
dotnet pack --configuration Release
```

## Benefits of Auto-Build

✅ **No manual steps** - just `dotnet pack`  
✅ **CI/CD friendly** - standard .NET build pipelines work  
✅ **Smart caching** - only rebuilds when needed  
✅ **Clear feedback** - progress messages show what's happening  
✅ **Error handling** - clear error messages if something fails  
✅ **Developer friendly** - works for both React and .NET devs  
✅ **No runtime Node.js** - consumers don't need Node.js installed

## Need Help?

- React app issues: Check `react-app/README.md`
- .NET issues: Check main project README
- Packaging: See `PACKAGE-BUILD.md`
