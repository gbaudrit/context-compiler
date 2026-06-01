# Complete rebuild script for ReactFlow module

Write-Host "🔨 Complete ReactFlow Module Rebuild" -ForegroundColor Cyan
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor Cyan

$modulePath = "src\Features\Reports\Modules\ContextCompiler.Reports.Modules.Pipelines.ReactFlow"
$reactAppPath = Join-Path $modulePath "react-app"

# Step 1: Rebuild React app
Write-Host "`n📦 Step 1: Building React app..." -ForegroundColor Yellow
Push-Location $reactAppPath

try {
	Write-Host "  Running: npm run build" -ForegroundColor Gray
	npm run build

	if ($LASTEXITCODE -ne 0) {
		Write-Host "❌ React build failed" -ForegroundColor Red
		Pop-Location
		exit 1
	}

	# Verify output
	if (Test-Path "dist\index.html") {
		$size = (Get-ChildItem "dist" -Recurse -File | Measure-Object -Property Length -Sum).Sum
		Write-Host "  ✅ React app built successfully ($([math]::Round($size/1MB,2)) MB)" -ForegroundColor Green
	} else {
		Write-Host "  ❌ dist/index.html not found after build" -ForegroundColor Red
		Pop-Location
		exit 1
	}
} finally {
	Pop-Location
}

# Step 2: Build .NET module
Write-Host "`n🔧 Step 2: Building .NET module..." -ForegroundColor Yellow
Write-Host "  Running: dotnet build --configuration Release" -ForegroundColor Gray

dotnet build "$modulePath\ContextCompiler.Reports.Modules.Pipelines.ReactFlow.csproj" --configuration Release -v:minimal

if ($LASTEXITCODE -ne 0) {
	Write-Host "❌ .NET build failed" -ForegroundColor Red
	exit 1
}

Write-Host "  ✅ .NET module built successfully" -ForegroundColor Green

# Step 3: Create NuGet package
Write-Host "`n📦 Step 3: Creating NuGet package..." -ForegroundColor Yellow
Write-Host "  Running: dotnet pack --configuration Release --no-build" -ForegroundColor Gray

dotnet pack "$modulePath\ContextCompiler.Reports.Modules.Pipelines.ReactFlow.csproj" --configuration Release --no-build -v:minimal

if ($LASTEXITCODE -ne 0) {
	Write-Host "❌ Package creation failed" -ForegroundColor Red
	exit 1
}

$nupkg = Get-ChildItem "$modulePath\bin\Release\*.nupkg" | Select-Object -First 1
if ($nupkg) {
	Write-Host "  ✅ Package created: $($nupkg.Name) ($([math]::Round($nupkg.Length/1KB,0)) KB)" -ForegroundColor Green
} else {
	Write-Host "  ❌ Package not found" -ForegroundColor Red
	exit 1
}

# Step 4: Update sample cache
Write-Host "`n🔄 Step 4: Updating sample cache..." -ForegroundColor Yellow

$samplePath = "samples\all\Connectors.Git"
$moduleCachePath = "$samplePath\.ctxc\modules\ContextCompiler.Reports.Modules.Pipelines.ReactFlow"
$nupkgCachePath = "$samplePath\.ctxc\modules\_nupkg\ContextCompiler.Reports.Modules.Pipelines.ReactFlow\0.1.0-alpha.1"

# Clean old module
if (Test-Path $moduleCachePath) {
	Write-Host "  Removing old module cache..." -ForegroundColor Gray
	Remove-Item -Recurse -Force $moduleCachePath
}

# Copy new package to cache
Write-Host "  Copying package to cache..." -ForegroundColor Gray
New-Item -ItemType Directory -Path $nupkgCachePath -Force | Out-Null
Copy-Item $nupkg.FullName "$nupkgCachePath\ContextCompiler.Reports.Modules.Pipelines.ReactFlow.0.1.0-alpha.1.nupkg" -Force

Write-Host "  ✅ Sample cache updated" -ForegroundColor Green

# Summary
Write-Host "`n✅ Rebuild complete!" -ForegroundColor Green
Write-Host "`n📋 Summary:" -ForegroundColor Cyan
Write-Host "  • React app built with relative paths (base: './')" -ForegroundColor White
Write-Host "  • .NET module compiled" -ForegroundColor White
Write-Host "  • NuGet package created" -ForegroundColor White
Write-Host "  • Sample cache updated" -ForegroundColor White

Write-Host "`n🚀 Ready to test!" -ForegroundColor Green
Write-Host "  Run: cd $samplePath; dotnet run --project ..\..\..\src\Core\ContextCompiler.Cli\ContextCompiler.Cli.csproj" -ForegroundColor Gray
