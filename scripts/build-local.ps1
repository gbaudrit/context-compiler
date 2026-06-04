param(
  [string]$Version = "0.1.0"
)

$ErrorActionPreference = "Stop"

# AssemblyVersion / FileVersion must be strictly numeric (X.Y.Z[.W]).
# InformationalVersion may carry a SemVer suffix (e.g. 0.1.0-local).
$NumericVersion = ($Version -split "[-+]")[0]

$env:CTX_VERSION = $NumericVersion
$Project = "src/Core/ContextCompiler.Cli/ContextCompiler.Cli.csproj"

New-Item -ItemType Directory -Force artifacts | Out-Null
New-Item -ItemType Directory -Force publish/win-x64 | Out-Null

dotnet publish $Project -c Release -r win-x64 --self-contained true `
  /p:PublishSingleFile=true /p:PublishTrimmed=false `
  /p:AssemblyVersion=$NumericVersion /p:FileVersion=$NumericVersion /p:InformationalVersion=$Version `
  -o publish/win-x64

if (Test-Path scripts/ctxc.cmd) {
  Copy-Item scripts/ctxc.cmd publish/win-x64/ctxc.cmd -Force
}

Compress-Archive -Path publish/win-x64/* -DestinationPath artifacts/ctxc-win-x64.zip -Force

$Iscc = "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe"
if (Test-Path $Iscc) {
  & $Iscc build/installer/ContextCompiler.iss
} else {
  Write-Warning "Inno Setup not found. Install with: choco install innosetup"
}
