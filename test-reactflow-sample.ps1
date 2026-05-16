# Quick test script for ReactFlow module in Connectors.Git sample

Write-Host "🧪 Testing ReactFlow Module" -ForegroundColor Cyan
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor Cyan

$samplePath = "samples\all\Connectors.Git"

# Clean previous output
if (Test-Path "$samplePath\.ctxc\compiled\pipeline-report-reactflow.html") {
	Write-Host "`n🧹 Cleaning previous output..." -ForegroundColor Yellow
	Remove-Item "$samplePath\.ctxc\compiled\pipeline-report-reactflow.html" -Force
}

# Run the sample
Write-Host "`n▶️ Running sample..." -ForegroundColor Green
Push-Location $samplePath

# Execute with detailed logging
$env:DOTNET_ENVIRONMENT = "Development"
dotnet run --project "..\..\src\Core\ContextCompiler.Cli\ContextCompiler.Cli.csproj" `
	-- run `
	--config ".ctxc\config.json" `
	--log-level Debug `
	2>&1 | Tee-Object -Variable output

Pop-Location

# Check output
Write-Host "`n📊 Results:" -ForegroundColor Cyan

if (Test-Path "$samplePath\.ctxc\compiled\pipeline-report-reactflow.html") {
	Write-Host "  ✅ HTML generated" -ForegroundColor Green

	$html = Get-Content "$samplePath\.ctxc\compiled\pipeline-report-reactflow.html" -Raw

	if ($html -match "React App Not Built") {
		Write-Host "  ❌ HTML is fallback (React app not found)" -ForegroundColor Red
		Write-Host "`n  Error message in HTML:" -ForegroundColor Yellow
		if ($html -match "<p><strong>Error:</strong> ([^<]+)</p>") {
			Write-Host "    $($matches[1])" -ForegroundColor Red
		}
	} else {
		Write-Host "  ✅ HTML contains React app" -ForegroundColor Green
	}

	# Check for our logging
	Write-Host "`n📝 Module logs:" -ForegroundColor Cyan
	$output | Where-Object { $_ -match "ReactFlow|react-app|Module assembly" } | ForEach-Object {
		Write-Host "  $_" -ForegroundColor Gray
	}
} else {
	Write-Host "  ❌ No HTML generated" -ForegroundColor Red
}

Write-Host "`n✅ Test complete!" -ForegroundColor Green
