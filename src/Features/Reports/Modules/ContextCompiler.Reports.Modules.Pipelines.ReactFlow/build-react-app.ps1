# Build React App for ReactFlow Module
# This script builds the React application and prepares it for inclusion in the NuGet package

$ErrorActionPreference = "Stop"

Write-Host "=====================================" -ForegroundColor Cyan
Write-Host "Building React Flow Pipeline Viewer" -ForegroundColor Cyan
Write-Host "=====================================" -ForegroundColor Cyan
Write-Host ""

$reactAppPath = Join-Path $PSScriptRoot "react-app"

if (-not (Test-Path $reactAppPath)) {
	Write-Host "❌ Error: react-app directory not found at $reactAppPath" -ForegroundColor Red
	exit 1
}

Set-Location $reactAppPath

# Check if Node.js is installed
try {
	$nodeVersion = node --version
	Write-Host "✓ Node.js version: $nodeVersion" -ForegroundColor Green
} catch {
	Write-Host "❌ Error: Node.js is not installed or not in PATH" -ForegroundColor Red
	Write-Host "   Please install Node.js 18+ from https://nodejs.org/" -ForegroundColor Yellow
	exit 1
}

# Check if npm is installed
try {
	$npmVersion = npm --version
	Write-Host "✓ npm version: $npmVersion" -ForegroundColor Green
} catch {
	Write-Host "❌ Error: npm is not installed or not in PATH" -ForegroundColor Red
	exit 1
}

Write-Host ""

# Install dependencies
Write-Host "📦 Installing dependencies..." -ForegroundColor Yellow
npm install
if ($LASTEXITCODE -ne 0) {
	Write-Host "❌ Error: npm install failed" -ForegroundColor Red
	exit 1
}
Write-Host "✓ Dependencies installed" -ForegroundColor Green
Write-Host ""

# Build the React app
Write-Host "🔨 Building React app..." -ForegroundColor Yellow
npm run build
if ($LASTEXITCODE -ne 0) {
	Write-Host "❌ Error: npm build failed" -ForegroundColor Red
	exit 1
}
Write-Host "✓ React app built successfully" -ForegroundColor Green
Write-Host ""

# Check if dist folder exists
$distPath = Join-Path $reactAppPath "dist"
if (Test-Path $distPath) {
	$distSize = (Get-ChildItem $distPath -Recurse | Measure-Object -Property Length -Sum).Sum / 1MB
	Write-Host "✓ Build output: $distPath" -ForegroundColor Green
	Write-Host "  Size: $($distSize.ToString('F2')) MB" -ForegroundColor Gray
} else {
	Write-Host "❌ Error: dist folder not found after build" -ForegroundColor Red
	exit 1
}

Write-Host ""
Write-Host "=====================================" -ForegroundColor Cyan
Write-Host "✓ Build completed successfully!" -ForegroundColor Green
Write-Host "=====================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Next steps:" -ForegroundColor Yellow
Write-Host "  1. Rebuild the .NET project to include the new dist folder" -ForegroundColor Gray
Write-Host "  2. The React app is now ready to be included in the NuGet package" -ForegroundColor Gray
Write-Host ""
