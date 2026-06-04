$ErrorActionPreference = 'Stop'

$packageName = 'contextcompiler'
$url64 = 'https://github.com/gbaudrit/context-compiler/releases/download/v0.1.0/ContextCompiler-Setup-0.1.0.exe'
$checksum64 = 'REPLACE_WITH_SHA256'

$packageArgs = @{
  packageName    = $packageName
  fileType       = 'exe'
  url64bit       = $url64
  softwareName   = 'ContextCompiler*'
  checksum64     = $checksum64
  checksumType64 = 'sha256'
  silentArgs     = '/VERYSILENT /SUPPRESSMSGBOXES /NORESTART'
  validExitCodes = @(0, 3010, 1641)
}

Install-ChocolateyPackage @packageArgs
