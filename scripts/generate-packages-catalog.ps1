$ErrorActionPreference = "Stop"

Set-StrictMode -Version Latest

$repoRoot = Split-Path -Parent $PSScriptRoot
$outputPath = Join-Path $repoRoot "contextcompiler.io\data\packages.catalog.json"

function Get-RelativePathCompat {
  param(
    [Parameter(Mandatory = $true)]
    [string]$BasePath,
    [Parameter(Mandatory = $true)]
    [string]$TargetPath
  )

  $normalizedBase = (Resolve-Path -LiteralPath $BasePath).Path
  $normalizedTarget = (Resolve-Path -LiteralPath $TargetPath).Path

  if (-not $normalizedBase.EndsWith("\")) {
    $normalizedBase = "$normalizedBase\"
  }

  $baseUri = [System.Uri]::new($normalizedBase)
  $targetUri = [System.Uri]::new($normalizedTarget)
  return $baseUri.MakeRelativeUri($targetUri).ToString().Replace("/", "\")
}

function Get-SingleNodeText {
  param(
    [Parameter(Mandatory = $true)]
    [xml]$ProjectXml,
    [Parameter(Mandatory = $true)]
    [string]$NodeName
  )

  $node = $ProjectXml.SelectSingleNode("//Project/PropertyGroup/$NodeName")
  if ($null -eq $node) {
    return $null
  }

  $value = $node.InnerText
  if ([string]::IsNullOrWhiteSpace($value)) {
    return $null
  }

  return (($value -replace "\s+", " ").Trim())
}

function Get-PackagePrefix {
  param([string]$Kind)

  switch ($Kind) {
    "module" { return "ContextCompiler.Modules." }
    "pack" { return "ContextCompiler.Packs." }
    default { throw "Unknown package kind '$Kind'." }
  }
}

function Get-Family {
  param(
    [string]$PackageId,
    [string]$Kind
  )

  $prefix = Get-PackagePrefix -Kind $Kind
  if (-not $PackageId.StartsWith($prefix)) {
    return "Other"
  }

  $suffix = $PackageId.Substring($prefix.Length)
  $parts = $suffix.Split(".")
  if ($parts.Length -eq 0 -or [string]::IsNullOrWhiteSpace($parts[0])) {
    return "Other"
  }

  return $parts[0]
}

function Get-ShortName {
  param(
    [string]$PackageId,
    [string]$Kind
  )

  $prefix = Get-PackagePrefix -Kind $Kind
  if ($PackageId.StartsWith($prefix)) {
    return $PackageId.Substring($prefix.Length)
  }

  return $PackageId
}

function Get-PackageMetadata {
  param(
    [Parameter(Mandatory = $true)]
    [string]$ProjectPath,
    [Parameter(Mandatory = $true)]
    [string]$Kind
  )

  [xml]$projectXml = Get-Content -LiteralPath $ProjectPath -Raw -Encoding UTF8

  $packageId = Get-SingleNodeText -ProjectXml $projectXml -NodeName "PackageId"
  $isPackable = Get-SingleNodeText -ProjectXml $projectXml -NodeName "IsPackable"

  if ([string]::IsNullOrWhiteSpace($packageId) -or $isPackable -ne "true") {
    return $null
  }

  $relativePath = (Get-RelativePathCompat -BasePath $repoRoot -TargetPath $ProjectPath).Replace("\", "/")
  $directoryPath = Split-Path -Parent $relativePath

  $references = @()
  $projectReferences = @($projectXml.SelectNodes("//Project/ItemGroup/ProjectReference"))
  foreach ($projectReference in $projectReferences) {
    $includePath = [string]$projectReference.GetAttribute("Include")
    if ([string]::IsNullOrWhiteSpace($includePath)) {
      continue
    }

    $resolvedReference = [System.IO.Path]::GetFullPath((Join-Path (Split-Path -Parent $ProjectPath) $includePath))
    if (-not (Test-Path -LiteralPath $resolvedReference)) {
      continue
    }

    [xml]$referenceXml = Get-Content -LiteralPath $resolvedReference -Raw -Encoding UTF8
    $referencePackageId = Get-SingleNodeText -ProjectXml $referenceXml -NodeName "PackageId"
    if (-not [string]::IsNullOrWhiteSpace($referencePackageId)) {
      $references += $referencePackageId
    }
  }

  $compositionKind = $null
  if ($Kind -eq "pack") {
    if (@($references | Where-Object { $_ -like "ContextCompiler.Packs.*" }).Count -gt 0) {
      $compositionKind = "pack-of-packs"
    } elseif (@($references | Where-Object { $_ -like "ContextCompiler.Modules.*" }).Count -gt 0) {
      $compositionKind = "pack-of-modules"
    } else {
      $compositionKind = "pack"
    }
  }

  return [ordered]@{
    kind = $Kind
    packageId = $packageId
    shortName = Get-ShortName -PackageId $packageId -Kind $Kind
    family = Get-Family -PackageId $packageId -Kind $Kind
    description = (Get-SingleNodeText -ProjectXml $projectXml -NodeName "Description")
    authors = (Get-SingleNodeText -ProjectXml $projectXml -NodeName "Authors")
    targetFramework = (Get-SingleNodeText -ProjectXml $projectXml -NodeName "TargetFramework")
    path = $directoryPath.Replace("\", "/")
    projectFile = $relativePath
    nugetUrl = "https://www.nuget.org/packages/$packageId"
    githubUrl = "https://github.com/gbaudrit/context-compiler/tree/main/$($directoryPath.Replace('\', '/'))"
    compositionKind = $compositionKind
    includes = @($references | Sort-Object -Unique)
  }
}

function Get-CatalogItems {
  param(
    [Parameter(Mandatory = $true)]
    [string]$RootPath,
    [Parameter(Mandatory = $true)]
    [string]$Kind
  )

  $projectFiles = Get-ChildItem -LiteralPath $RootPath -Filter *.csproj -Recurse -File | Sort-Object FullName
  $items = foreach ($projectFile in $projectFiles) {
    Get-PackageMetadata -ProjectPath $projectFile.FullName -Kind $Kind
  }

  return @($items | Where-Object { $null -ne $_ })
}

$modules = @(Get-CatalogItems -RootPath (Join-Path $repoRoot "src\Modules") -Kind "module")
$packs = @(Get-CatalogItems -RootPath (Join-Path $repoRoot "src\Packs") -Kind "pack")

$catalog = [ordered]@{
  generatedAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
  source = [ordered]@{
    modulesRoot = "src/Modules"
    packsRoot = "src/Packs"
  }
  stats = [ordered]@{
    modules = @($modules).Count
    packs = @($packs).Count
  }
  families = [ordered]@{
    modules = @($modules | ForEach-Object { $_.family } | Sort-Object -Unique)
    packs = @($packs | ForEach-Object { $_.family } | Sort-Object -Unique)
  }
  modules = $modules
  packs = $packs
}

$outputDir = Split-Path -Parent $outputPath
if (-not (Test-Path -LiteralPath $outputDir)) {
  New-Item -ItemType Directory -Path $outputDir | Out-Null
}

$catalog | ConvertTo-Json -Depth 10 | Set-Content -LiteralPath $outputPath -Encoding UTF8
Write-Host "Catalog generated at $outputPath"
