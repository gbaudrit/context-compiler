# Architecture Decision: Security Guard Module Location

## Context

Lors de l'implémentation de la validation des artifacts (Skills, Tools, Configuration), nous avions initialement créé `ArtifactSecurityGuardModule` dans le projet `ContextCompiler.Skills.Providers.Anthropic`.

## Problem

Le module de sécurité était mal placé car :
1. **Responsabilité mal alignée** : La sécurité est une responsabilité transversale (cross-cutting concern), pas spécifique à un provider
2. **Manque de réutilisabilité** : Le guard scannait tous types d'artifacts (Skills, Tools, Config), pas que Skills
3. **Violation du principe de séparation** : Security guards devraient être dans `Features/Security/`, pas dans un provider spécifique

## Decision

✅ **Déplacer `ArtifactSecurityGuardModule` vers `src\Features\Security\Modules\ContextCompiler.Security.Modules.Guards.Artifacts\`**

## Rationale

### Organisation modulaire correcte

```
src/Features/
├── Security/
│   └── Modules/
│       ├── ContextCompiler.Security.Modules.Guards.DataPart/     (existant)
│       ├── ContextCompiler.Security.Modules.Guards.Email/        (existant)
│       └── ContextCompiler.Security.Modules.Guards.Artifacts/    ✅ NOUVEAU
│
├── Skills/
│   └── Modules/
│       └── ContextCompiler.Skills.Providers.Anthropic/
│           ├── AnthropicSkillProvider.cs
│           └── SkillsArtifactEnrichmentModule.cs  (Skills-specific)
│
└── Output/
	└── Modules/
		└── ContextCompiler.Output.Modules.Artifacts.Writer/
			└── OutputArtifactsFilesWriterModule.cs  (générique)
```

### Principes architecturaux

1. **Single Responsibility Principle**
   - Provider Anthropic : Fournir des skills
   - Security Guard : Valider la sécurité (tous artifacts)

2. **Separation of Concerns**
   - Security guards = `Features/Security/`
   - Skills enrichment = `Features/Skills/`
   - Output writing = `Features/Output/`

3. **Cohérence avec les guards existants**
   ```
   ContextCompiler.Security.Modules.Guards.DataPart     → DataPartGuardModule
   ContextCompiler.Security.Modules.Guards.Email        → EmailGuardModule
   ContextCompiler.Security.Modules.Guards.Artifacts    → ArtifactSecurityGuardModule ✅
   ```

### Scope du module

Le module est **générique** et supporte :
- ✅ `ArtifactCategory.Skill`
- ✅ `ArtifactCategory.Tool`
- ✅ `ArtifactCategory.Configuration`
- 🔄 Extensible à d'autres catégories

```csharp
// Exemple: Support futur pour MCP Tools
List<IOutputArtifact> scannableArtifacts = [.. artifacts.Where(a =>
	a.Category == ArtifactCategory.Skill ||
	a.Category == ArtifactCategory.Tool ||      // ✅ Déjà supporté
	a.Category == ArtifactCategory.Configuration)];
```

## Implementation

### Module déplacé

**Avant** : `src\Features\Skills\Modules\ContextCompiler.Skills.Providers.Anthropic\ArtifactSecurityGuardModule.cs`  
**Après** : `src\Features\Security\Modules\ContextCompiler.Security.Modules.Guards.Artifacts\ArtifactSecurityGuardModule.cs`

### Package

```xml
<PropertyGroup>
  <PackageId>ContextCompiler.Security.Modules.Guards.Artifacts</PackageId>
  <Description>Security guard module that scans output artifacts for security threats before deployment.</Description>
  <PackageTags>security;guard;artifacts;skills;scan;threats</PackageTags>
</PropertyGroup>
```

### Namespace

```csharp
// Avant
namespace ContextCompiler.Skills.Providers.Anthropic;

// Après
namespace ContextCompiler.Security.Modules.Guards.Artifacts;
```

### Module ID

```csharp
// Avant
"artifact-security-guard"

// Après
"security.guard.artifacts"  // Cohérent avec security.guard.datapart, security.guard.email
```

## Benefits

✅ **Organisation claire** : Security guards regroupés dans `Features/Security/`

✅ **Réutilisabilité** : Le guard fonctionne pour tous types d'artifacts déployables

✅ **Cohérence** : Suit le pattern des guards existants (`DataPart`, `Email`)

✅ **Découplage** : Provider Anthropic n'a plus de dépendance sur la sécurité

✅ **Extensibilité** : Facile d'ajouter d'autres guards (ex: `ArtifactLicenseGuardModule`)

## Consequences

### Positive

- ✅ Architecture modulaire cohérente
- ✅ Responsabilités bien séparées
- ✅ Guard réutilisable pour Skills, Tools, Config
- ✅ Facilite l'ajout de nouveaux guards de sécurité

### Negative

- ⚠️ Nouveau package NuGet à publier
- ⚠️ Documentation à mettre à jour

### Neutral

- 🔄 Les modules existants ne changent pas (Skills enrichment, Output writer)

## Migration

1. ✅ Créer `ContextCompiler.Security.Modules.Guards.Artifacts` project
2. ✅ Copier et adapter `ArtifactSecurityGuardModule`
3. ✅ Généraliser le support (Skills → Skills/Tools/Config)
4. ✅ Supprimer l'ancien module de Skills provider
5. ✅ Mettre à jour la documentation
6. ✅ Build réussi sans erreurs

## Status

✅ **Accepté et implémenté**

## Related Documents

- `docs/SKILLS-VALIDATION-SUMMARY.md` - Architecture mise à jour
- `docs/ADR-GENERIC-ARTIFACT-WRITER.md` - Décision sur le writer générique
- `src/Features/Security/Modules/ContextCompiler.Security.Modules.Guards.Artifacts/README.md` - Documentation du module

## Notes

Cette décision améliore significativement l'organisation modulaire et la réutilisabilité du code. Le guard de sécurité peut maintenant être utilisé indépendamment du provider de skills et supporte naturellement d'autres types d'artifacts (Tools, Configuration).
