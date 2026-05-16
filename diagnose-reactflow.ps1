# Diagnostic script for ReactFlow module issues

param(
	[string]$SamplePath = "samples\all\Connectors.Git"
)

Write-Host "🔍 ReactFlow Module Diagnostic" -ForegroundColor Cyan
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor Cyan

$modulePath = Join-Path $SamplePath ".ctxc\modules\ContextCompiler.Reports.Modules.Pipelines.ReactFlow"

if (-not (Test-Path $modulePath)) {
	Write-Host "`n❌ Module not installed at $modulePath" -ForegroundColor Red
	exit 1
}

Write-Host "`n✅ Module found at: $modulePath" -ForegroundColor Green

# Find installed version
$versions = Get-ChildItem $modulePath -Directory | Where-Object { $_.Name -match '^\d+\.\d+\.\d+' }

foreach ($version in $versions) {
	Write-Host "`n📦 Version: $($version.Name)" -ForegroundColor Cyan

	$versionPath = $version.FullName
	$libPath = Join-Path $versionPath "lib\net10.0"
	$contentFilesPath = Join-Path $versionPath "contentFiles\any\any\react-app"

	Write-Host "`n  📂 Structure check:" -ForegroundColor Yellow

	# Check lib/
	if (Test-Path $libPath) {
		$dll = Get-Item "$libPath\*.dll" | Select-Object -First 1
		Write-Host "    ✅ lib/net10.0/ exists" -ForegroundColor Green
		Write-Host "       DLL: $($dll.Name) ($([math]::Round($dll.Length/1KB,1)) KB)" -ForegroundColor Gray
		Write-Host "       Modified: $($dll.LastWriteTime)" -ForegroundColor Gray
	} else {
		Write-Host "    ❌ lib/net10.0/ NOT FOUND" -ForegroundColor Red
	}

	# Check contentFiles/
	if (Test-Path $contentFilesPath) {
		Write-Host "    ✅ contentFiles/any/any/react-app/ exists" -ForegroundColor Green

		$distPath = Join-Path $contentFilesPath "dist"
		if (Test-Path $distPath) {
			Write-Host "    ✅ dist/ exists" -ForegroundColor Green

			$indexHtml = Join-Path $distPath "index.html"
			if (Test-Path $indexHtml) {
				Write-Host "    ✅ index.html exists" -ForegroundColor Green

				$assets = Get-ChildItem (Join-Path $distPath "assets") -File
				Write-Host "       Assets: $($assets.Count) files" -ForegroundColor Gray

				foreach ($asset in $assets) {
					Write-Host "         - $($asset.Name) ($([math]::Round($asset.Length/1KB,1)) KB)" -ForegroundColor Gray
				}
			} else {
				Write-Host "    ❌ index.html NOT FOUND" -ForegroundColor Red
			}
		} else {
			Write-Host "    ❌ dist/ NOT FOUND" -ForegroundColor Red
		}
	} else {
		Write-Host "    ❌ contentFiles/any/any/react-app/ NOT FOUND" -ForegroundColor Red
	}

	# Simulate path resolution
	Write-Host "`n  🧪 Path resolution simulation:" -ForegroundColor Yellow

	$moduleDir = $libPath
	$packageRoot = Split-Path (Split-Path $moduleDir -Parent) -Parent

	Write-Host "    Module dir: $moduleDir" -ForegroundColor Gray
	Write-Host "    Package root: $packageRoot" -ForegroundColor Gray

	$paths = @(
		(Join-Path $packageRoot "contentFiles\any\any\react-app"),
		(Join-Path $packageRoot "module-assets\react-app"),
		(Join-Path $packageRoot "react-app"),
		(Join-Path $moduleDir "react-app")
	)

	Write-Host "`n    Checking paths:" -ForegroundColor Gray
	$found = $false
	foreach ($path in $paths) {
		$exists = Test-Path $path
		$status = if ($exists) { "✅ EXISTS" } else { "❌ NOT FOUND" }
		$color = if ($exists) { "Green" } else { "Red" }
		Write-Host "      $status $path" -ForegroundColor $color
		if ($exists -and -not $found) {
			$found = $true
			Write-Host "         ^ Module would use this path" -ForegroundColor Cyan
		}
	}

	if (-not $found) {
		Write-Host "`n    ⚠️ No valid path found! Module will use fallback HTML" -ForegroundColor Yellow
	}
}

# Check nupkg cache
Write-Host "`n📦 NuGet package cache:" -ForegroundColor Cyan
$nupkgCache = Join-Path $SamplePath ".ctxc\modules\_nupkg\ContextCompiler.Reports.Modules.Pipelines.ReactFlow"

if (Test-Path $nupkgCache) {
	$nupkgs = Get-ChildItem $nupkgCache -Recurse -Filter "*.nupkg"
	if ($nupkgs.Count -gt 0) {
		Write-Host "  ✅ Found $($nupkgs.Count) cached package(s)" -ForegroundColor Green
		foreach ($nupkg in $nupkgs) {
			Write-Host "     - $($nupkg.Name)" -ForegroundColor Gray
			Write-Host "       Size: $([math]::Round($nupkg.Length/1KB,1)) KB" -ForegroundColor Gray
			Write-Host "       Modified: $($nupkg.LastWriteTime)" -ForegroundColor Gray
		}
	} else {
		Write-Host "  ⚠️ Cache directory exists but no .nupkg found" -ForegroundColor Yellow
	}
} else {
	Write-Host "  ℹ️ No package cache found (will download from source)" -ForegroundColor Gray
}

Write-Host "`n✅ Diagnostic complete!" -ForegroundColor Green

Write-Host "`n💡 Recommendations:" -ForegroundColor Cyan
Write-Host "  1. If contentFiles are missing, rebuild the package:" -ForegroundColor White
Write-Host "     dotnet pack --configuration Release" -ForegroundColor Gray
Write-Host "  2. Clear module cache and reinstall:" -ForegroundColor White
Write-Host "     Remove-Item -Recurse '$modulePath'" -ForegroundColor Gray
Write-Host "  3. Check logs when running for 'Module assembly location' and 'Trying X possible paths'" -ForegroundColor White
