$ErrorActionPreference = 'Stop'

$packageName = 'contextcompiler'
$softwareName = 'ContextCompiler*'

[array]$key = Get-UninstallRegistryKey -SoftwareName $softwareName

if ($key.Count -eq 1) {
  $key | ForEach-Object {
	$uninstall = $_.UninstallString.Trim('"')
	$packageArgs = @{
	  packageName    = $packageName
	  fileType       = 'exe'
	  silentArgs     = '/VERYSILENT /SUPPRESSMSGBOXES /NORESTART'
	  validExitCodes = @(0, 3010, 1605, 1614, 1641)
	  file           = $uninstall
	}
	Uninstall-ChocolateyPackage @packageArgs
  }
}
elseif ($key.Count -eq 0) {
  Write-Warning "$packageName has already been uninstalled by other means."
}
else {
  Write-Warning "$($key.Count) matches found for $softwareName. Uninstall skipped."
}
