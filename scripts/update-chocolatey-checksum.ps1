param(
  [Parameter(Mandatory=$true)]
  [string]$Version
)

$ErrorActionPreference = "Stop"

$VersionNumber = $Version.TrimStart("v")
$InstallerName = "ContextCompiler-Setup-$VersionNumber.exe"
$Url = "https://github.com/gbaudrit/context-compiler/releases/download/$Version/$InstallerName"
$Temp = Join-Path $env:TEMP $InstallerName

Invoke-WebRequest -Uri $Url -OutFile $Temp
$Hash = (Get-FileHash $Temp -Algorithm SHA256).Hash.ToLower()

$InstallScript = "build/chocolatey/tools/chocolateyinstall.ps1"
(Get-Content $InstallScript) `
  -replace "ContextCompiler-Setup-[0-9A-Za-z\.\-\+]+\.exe", $InstallerName `
  -replace "v0.1.0", $Version `
  -replace "REPLACE_WITH_SHA256", $Hash |
  Set-Content $InstallScript

Write-Host "SHA256: $Hash"
