# Convention NuGet pour les Modules ContextCompiler

Ce document définit les conventions pour l'empaquetage de modules ContextCompiler avec des assets statiques.

## 📦 Structure NuGet Standard

### Dossiers supportés automatiquement

Le `NuGetModuleStore` extrait automatiquement les dossiers suivants :

```
package.nupkg/
├── lib/net10.0/              ✅ Assemblies runtime (obligatoire)
├── ref/net10.0/              ✅ Reference assemblies (optionnel)
├── content/                  ✅ Assets génériques legacy (optionnel)
├── contentFiles/any/any/     ✅ Assets modernes (recommandé)
└── module-assets/            ✅ Convention personnalisée (alternative)
```

### ✨ Nouveauté : Support `contentFiles/` et `module-assets/`

Depuis la mise à jour du `NuGetModuleStore`, les modules peuvent inclure des assets statiques dans :

1. **`contentFiles/any/any/`** ⭐ (Recommandé - Convention NuGet standard)
2. **`module-assets/`** (Convention personnalisée pour ContextCompiler)

## 🎯 Recommandations par Type d'Asset

### Pour des applications React/Vue/Angular

**✅ Utiliser `contentFiles/any/any/`**

```xml
<ItemGroup>
  <Content Include="react-app\dist\**\*" 
		   Pack="true" 
		   PackagePath="contentFiles\any\any\react-app\dist\" 
		   CopyToOutputDirectory="PreserveNewest">
	<Visible>false</Visible>
  </Content>
</ItemGroup>
```

**Emplacement dans le package :**
```
package.nupkg/
└── contentFiles/
	└── any/
		└── any/
			└── react-app/
				└── dist/
					├── index.html
					└── assets/
						├── index.js
						└── style.css
```

**Accès depuis le module :**
```csharp
// Le NuGetModuleStore extrait vers:
// {InstallRoot}/{PackageId}/{Version}/{Hash}/contentFiles/any/any/react-app/dist/

// Dans votre générateur:
string[] possiblePaths = [
	Path.Combine(extractedPath, "contentFiles", "any", "any", "react-app", "dist"),
	Path.Combine(extractedPath, "react-app", "dist") // Fallback local dev
];

string? distPath = possiblePaths.FirstOrDefault(Directory.Exists);
```

### Pour des templates, schemas, ou fichiers de configuration

**✅ Utiliser `contentFiles/any/any/templates/`**

```xml
<ItemGroup>
  <Content Include="templates\**\*" 
		   Pack="true" 
		   PackagePath="contentFiles\any\any\templates\" />
</ItemGroup>
```

### Pour des assets natifs (images, vidéos, etc.)

**✅ Utiliser `module-assets/`**

```xml
<ItemGroup>
  <Content Include="assets\**\*" 
		   Pack="true" 
		   PackagePath="module-assets\assets\" />
</ItemGroup>
```

## 📋 Checklist pour Créer un Module avec Assets

### 1. Structure de projet

```
MyModule/
├── MyModule.csproj
├── MyModule.cs                    # Code C#
├── assets/                        # Assets sources
│   ├── templates/
│   └── images/
└── build-assets.ps1               # Script de préparation (si nécessaire)
```

### 2. Configuration .csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
	<TargetFramework>net10.0</TargetFramework>
	<IsPackable>true</IsPackable>
	<PackageId>ContextCompiler.MyModule</PackageId>
  </PropertyGroup>

  <ItemGroup>
	<!-- Assets statiques -->
	<Content Include="assets\**\*" 
			 Pack="true" 
			 PackagePath="contentFiles\any\any\assets\" 
			 CopyToOutputDirectory="PreserveNewest">
	  <Visible>false</Visible>
	</Content>
  </ItemGroup>
</Project>
```

### 3. Accès aux assets dans le code

```csharp
public class MyModuleGenerator
{
	public string Generate(string extractedPath)
	{
		// Chercher dans les emplacements standards
		string[] possiblePaths = [
			Path.Combine(extractedPath, "contentFiles", "any", "any", "assets"),
			Path.Combine(extractedPath, "module-assets", "assets"),
			Path.Combine(extractedPath, "assets") // Dev local
		];

		string? assetsPath = possiblePaths.FirstOrDefault(Directory.Exists);

		if (assetsPath is null)
		{
			throw new InvalidOperationException("Assets not found");
		}

		// Utiliser les assets...
		string templatePath = Path.Combine(assetsPath, "template.html");
		return File.ReadAllText(templatePath);
	}
}
```

## 🔍 Vérification du Package

### Inspecter le contenu du .nupkg

```powershell
# Extraire le package (c'est un ZIP)
$nupkg = "bin\Release\MyModule.1.0.0.nupkg"
Add-Type -Assembly System.IO.Compression.FileSystem
$zip = [System.IO.Compression.ZipFile]::OpenRead($nupkg)

# Lister les fichiers contentFiles
$zip.Entries | Where-Object { $_.FullName -like 'contentFiles/*' } | 
	Select-Object FullName, Length

$zip.Dispose()
```

### Vérifier l'extraction locale

```powershell
# Après installation du module
cd C:\Users\{User}\.contextcompiler\modules\MyModule\1.0.0\{hash}\

# Vérifier la structure
Get-ChildItem -Recurse
```

Vous devriez voir :
```
lib/net10.0/
	MyModule.dll
contentFiles/any/any/
	assets/
		template.html
```

## 📝 Exemples de Modules

### Module ReactFlow (Application React)

**Package path :** `contentFiles/any/any/react-app/dist/`

**Code d'accès :**
```csharp
string[] paths = [
	Path.Combine(extractedPath, "contentFiles", "any", "any", "react-app", "dist"),
	Path.Combine(extractedPath, "react-app", "dist")
];
string? distPath = paths.FirstOrDefault(Directory.Exists);
```

### Module avec Templates Markdown

**Package path :** `contentFiles/any/any/templates/`

**Code d'accès :**
```csharp
string templatesPath = Path.Combine(extractedPath, "contentFiles", "any", "any", "templates");
string template = File.ReadAllText(Path.Combine(templatesPath, "report.md"));
```

### Module avec Schemas JSON

**Package path :** `contentFiles/any/any/schemas/`

**Code d'accès :**
```csharp
string schemasPath = Path.Combine(extractedPath, "contentFiles", "any", "any", "schemas");
string schema = File.ReadAllText(Path.Combine(schemasPath, "pipeline.schema.json"));
```

## 🚀 Build et Pack

### Build automatique (comme ReactFlow)

Pour des assets qui nécessitent une compilation (React, TypeScript, etc.) :

```xml
<Target Name="BuildAssets" BeforeTargets="DispatchToInnerBuilds;_GetPackageFiles">
  <!-- Vérifier si build nécessaire -->
  <PropertyGroup>
	<NeedsBuild Condition="!Exists('assets\dist\index.html')">true</NeedsBuild>
  </PropertyGroup>

  <!-- Compiler les assets -->
  <Exec Command="npm run build" 
		WorkingDirectory="assets" 
		Condition="'$(NeedsBuild)' == 'true'" />
</Target>
```

### Pack simple

Pour des assets statiques (pas de build nécessaire) :

```bash
dotnet pack --configuration Release
```

## ⚠️ Points d'Attention

### 1. Taille du package

- ✅ **Bon :** Assets compressés, optimisés (minifiés)
- ❌ **Éviter :** Source maps, fichiers de développement

**Exemple ReactFlow :**
- Uncompressed: 1.7 MB
- Compressed (dans .nupkg): 530 KB

### 2. Chemins compatibles multi-plateforme

```csharp
// ✅ Bon
string path = Path.Combine(basePath, "assets", "file.txt");

// ❌ Éviter
string path = basePath + "\\assets\\file.txt";
```

### 3. Fallback pour développement local

Toujours prévoir un fallback vers la structure locale :

```csharp
string[] paths = [
	Path.Combine(extractedPath, "contentFiles", "any", "any", "assets"), // NuGet
	Path.Combine(extractedPath, "assets")                                // Dev local
];
```

## 📚 Références

- [NuGet contentFiles documentation](https://docs.microsoft.com/nuget/reference/nuspec#including-content-files)
- [NuGet package conventions](https://docs.microsoft.com/nuget/create-packages/creating-a-package)
- Module de référence : `ContextCompiler.Reports.Modules.Pipelines.ReactFlow`

## 🔄 Changelog

- **2024-XX-XX** : Ajout support `contentFiles/` et `module-assets/` dans `NuGetModuleStore`
- **2024-XX-XX** : Création du document de convention
