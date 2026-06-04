param(
  [string]$Version = "latest",
  [string]$InstallDir = "$env:USERPROFILE\.ctxc\bin",
  [switch]$NoPath
)

$ErrorActionPreference = "Stop"

$Repo = "gbaudrit/context-compiler"
$AssetName = "ctxc-win-x64.zip"
$Base = "https://github.com/$Repo/releases"

if ($Version -eq "latest") {
  $Url = "$Base/latest/download/$AssetName"
} else {
  $Url = "$Base/download/$Version/$AssetName"
}

New-Item -ItemType Directory -Force -Path $InstallDir | Out-Null

$Zip = Join-Path $env:TEMP $AssetName
Invoke-WebRequest -Uri $Url -OutFile $Zip

$Temp = Join-Path $env:TEMP ("ctxc-" + [Guid]::NewGuid())
New-Item -ItemType Directory -Force -Path $Temp | Out-Null
Expand-Archive -Path $Zip -DestinationPath $Temp -Force

Copy-Item -Path (Join-Path $Temp "*") -Destination $InstallDir -Recurse -Force

if (-not $NoPath) {
  $Current = [Environment]::GetEnvironmentVariable("Path", "User")
  if (($Current -split ";") -notcontains $InstallDir) {
	[Environment]::SetEnvironmentVariable("Path", "$Current;$InstallDir", "User")
	Write-Host "Added $InstallDir to user PATH. Restart your terminal."
  }
}

Write-Host "ContextCompiler installed in $InstallDir"
& (Join-Path $InstallDir "ctxc.exe") --version
