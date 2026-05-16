# Test script to verify ReactFlow module asset resolution

Write-Host "🔍 Testing ReactFlow Module Asset Resolution" -ForegroundColor Cyan
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor Cyan

# Find the latest package
$nupkg = Get-ChildItem -Path "bin\Release\*.nupkg" -Recurse | 
	Sort-Object LastWriteTime -Descending | 
	Select-Object -First 1

if (-not $nupkg) {
	Write-Host "❌ No package found in bin\Release\" -ForegroundColor Red
	exit 1
}

Write-Host "`n📦 Package: $($nupkg.Name)" -ForegroundColor Green
Write-Host "📏 Size: $([math]::Round($nupkg.Length / 1MB, 2)) MB`n" -ForegroundColor Green

# Extract to temp directory to simulate NuGet extraction
$tempDir = Join-Path $env:TEMP "reactflow-test-$([guid]::NewGuid())"
$extractDir = Join-Path $tempDir "extracted"
New-Item -ItemType Directory -Path $extractDir -Force | Out-Null

Write-Host "📂 Extracting to: $extractDir" -ForegroundColor Yellow

Add-Type -Assembly System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::ExtractToDirectory($nupkg.FullName, $extractDir)

# Simulate package structure after NuGet extraction
$libPath = Join-Path $extractDir "lib\net10.0"
$contentFilesPath = Join-Path $extractDir "contentFiles\any\any\react-app"

Write-Host "`n🔍 Checking extraction structure:" -ForegroundColor Cyan

# Check lib/
if (Test-Path $libPath) {
	$dllFiles = Get-ChildItem -Path $libPath -Filter "*.dll"
	Write-Host "  ✅ lib/net10.0/ exists with $($dllFiles.Count) DLL(s)" -ForegroundColor Green
	$assemblyPath = $dllFiles[0].FullName
} else {
	Write-Host "  ❌ lib/net10.0/ not found" -ForegroundColor Red
}

# Check contentFiles/
if (Test-Path $contentFilesPath) {
	$reactFiles = Get-ChildItem -Path $contentFilesPath -Recurse -File
	Write-Host "  ✅ contentFiles/any/any/react-app/ exists with $($reactFiles.Count) files" -ForegroundColor Green

	# Check for key files
	$distPath = Join-Path $contentFilesPath "dist"
	if (Test-Path (Join-Path $distPath "index.html")) {
		Write-Host "     ✅ dist/index.html found" -ForegroundColor Green
	} else {
		Write-Host "     ❌ dist/index.html NOT found" -ForegroundColor Red
	}

	if (Test-Path (Join-Path $distPath "assets")) {
		$assets = Get-ChildItem -Path (Join-Path $distPath "assets") -File
		Write-Host "     ✅ dist/assets/ found with $($assets.Count) files" -ForegroundColor Green
	} else {
		Write-Host "     ❌ dist/assets/ NOT found" -ForegroundColor Red
	}
} else {
	Write-Host "  ❌ contentFiles/any/any/react-app/ not found" -ForegroundColor Red
}

# Simulate what the module would do
Write-Host "`n🧪 Simulating module path resolution:" -ForegroundColor Cyan

if ($assemblyPath) {
	$moduleDirectory = Split-Path $assemblyPath -Parent
	Write-Host "  Module directory: $moduleDirectory" -ForegroundColor Gray

	# Go up 2 levels to package root (from lib/net10.0/ to root)
	$packageRoot = Split-Path (Split-Path $moduleDirectory -Parent) -Parent
	Write-Host "  Package root: $packageRoot" -ForegroundColor Gray

	# Test the paths the module would try
	$possiblePaths = @(
		(Join-Path $packageRoot "contentFiles\any\any\react-app"),
		(Join-Path $packageRoot "module-assets\react-app"),
		(Join-Path $packageRoot "react-app"),
		(Join-Path $moduleDirectory "react-app")
	)

	Write-Host "`n  Testing resolution paths:" -ForegroundColor Yellow
	$foundPath = $null
	foreach ($path in $possiblePaths) {
		if (Test-Path $path) {
			Write-Host "    ✅ $path" -ForegroundColor Green
			if (-not $foundPath) { $foundPath = $path }
		} else {
			Write-Host "    ❌ $path" -ForegroundColor Red
		}
	}

	if ($foundPath) {
		Write-Host "`n  🎉 Module would find react-app at:" -ForegroundColor Green
		Write-Host "     $foundPath" -ForegroundColor Green

		# Check if ReactFlowHtmlGenerator would find the dist
		$distPath = Join-Path $foundPath "dist"
		if (Test-Path (Join-Path $distPath "index.html")) {
			Write-Host "  🎉 ReactFlowHtmlGenerator would find index.html" -ForegroundColor Green
		} else {
			Write-Host "  ⚠️ ReactFlowHtmlGenerator would NOT find index.html" -ForegroundColor Yellow
		}
	} else {
		Write-Host "`n  ❌ Module would NOT find react-app in any standard location" -ForegroundColor Red
	}
}

# Cleanup
Write-Host "`n🧹 Cleaning up..." -ForegroundColor Gray
Remove-Item -Recurse -Force $tempDir -ErrorAction SilentlyContinue

Write-Host "`n✅ Test complete!" -ForegroundColor Green
