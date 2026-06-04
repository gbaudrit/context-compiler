# Skills Artifact Validation - Implementation Summary

## ✅ Implémenté

### 1. SkillsArtifactEnrichmentModule
**Phase**: `PrerequisitesEnrichment` (950000, Priority: 1000)

**Responsabilité**: Scanner le cache des skills et les enregistrer comme artifacts avec leur contenu

**Fonctionnement**:
1. Lit la config `SkillsConfig.Items` (format: `skillId: "provider@version"`)
2. Pour chaque skill, scanne `.ctxc/cache/skills/{provider}/{skillId}/{version}/`
3. **Lit le contenu de chaque fichier**
4. Enregistre chaque fichier comme `IOutputArtifact`:
   - `Category = ArtifactCategory.Skill`
   - `Name = ".agents/skills/{skillId}/{relativePath}"` (détermine le chemin de sortie)
   - `Content = file content`
   - `Metadata`:
	 - `skillId`: identifiant du skill
	 - `provider`: provider source (ex: "anthropic-agent-skills")
	 - `version`: version (ex: "main", "v1.0.0")
	 - `sourcePath`: chemin complet dans le cache
	 - `relativePath`: chemin relatif dans le skill
	 - **`excluded`: "false"** (par défaut, peut être modifié par guards)

**Note importante**: Le placement final (`.agents/skills/{skillId}/`) est déterminé par le `StoreResource` créé via `.WithName()` + `.InStore("Output")`, pas par le writer.

**Exemple de sortie**:
```
✅ Enriched 12 files for skill skill-creator
✅ Enriched 8 files for skill doc-coauthoring
✅ Skills artifact enrichment complete: 20 files registered
```

---

### 2. ArtifactSecurityGuardModule
**Localisation**: `src\Features\Security\Modules\ContextCompiler.Security.Modules.Guards.Artifacts\`  
**Phase**: `ArtifactValidation` (970000, Priority: 2000)

**Responsabilité**: Scanner les artifacts pour détecter des menaces de sécurité et **marquer** les artifacts à exclure

**Module générique** : Fonctionne pour **Skills, Tools, Configuration** (tous artifacts déployables)

**Patterns détectés**:
- **Dangerous code**: `eval(`, `exec(`, `subprocess`, `os.system`, `process.start`, `cmd.exe`, `rm -rf`
- **Hardcoded secrets**: `password=`, `secret=`, `api_key=`, `token=` avec guillemets
- **External URLs**: URLs HTTP/HTTPS non whitelistées (autorisés: github.com, anthropic.com, microsoft.com)
- **Suspicious keywords**: "exfiltrate", "backdoor", "malware", "trojan", "ransomware"

**Action sur détection**:
- ❌ **Marque TOUS les fichiers du groupe** (ex: tous les fichiers d'un skill) avec:
  - `metadata["excluded"] = "true"`
  - `metadata["exclusionReason"] = "security-threats"`

**Fichiers scannés**:
- Extensions texte: `.md`, `.txt`, `.json`, `.js`, `.ts`, `.py`, `.yaml`, `.yml`, `.sh`, `.ps1`, `.cs`, `.java`, `.go`, `.rs`, `.rb`, `.php`

**Exemple de sortie**:
```
⚠️  Security threat in Skill:skill-creator, file tool.js: [dangerous-code] Dangerous pattern 'eval(' detected at line 42
❌ Skill:skill-creator contains security threats - marking for exclusion
✅ Security scan complete: scanned 18 files, found 3 threats, excluded 12 artifacts
```

---

### 3. OutputArtifactsFilesWriterModule (modifié)
**Phase**: `ArtifactPersistence` (1000000, Priority: 10)

**Responsabilité**: Écrire **TOUS** les artifacts à leur emplacement déterminé par leur `StoreResource`

**Logique d'écriture**:
1. Pour chaque artifact dans `output.Artifacts`:
   - ✅ **Si `excluded == "false"`**: écrit via `artifact.StoreResource.WriteAllText(artifact.Content)`
   - ❌ **Si `excluded == "true"`**: skip et log la raison
2. Génère `artifacts.deployment.report.md` si des exclusions

**Placement** : Déterminé par le `StoreResource` de chaque artifact :
- Skills : `.agents/skills/{skillId}/` (défini dans `SkillsArtifactEnrichmentModule`)
- Autres : selon leur `WithName()` + `InStore()`

**Exemple de sortie**:
```
✅ Wrote output artifact: /path/to/output/.agents/skills/doc-coauthoring/SKILL.md
✅ Wrote output artifact: /path/to/output/.agents/skills/doc-coauthoring/tool.js
⚠️  Excluded artifact: Skill file from skill-creator (Reason: security-threats)
✅ Artifacts writing complete: 8 written, 12 excluded
```

---

## 📊 Flow complet

```
┌─────────────────────────────────────────────────────┐
│ 1. RESTORE (CLI)                                    │
│    ctxc skills restore                              │
│    → Downloads skills to .ctxc/cache/skills/        │
└─────────────────────────────────────────────────────┘
					↓
┌─────────────────────────────────────────────────────┐
│ 2. COMPILE (CompilePipeline)                         │
│    ctxc compile                                     │
│                                                      │
│  ┌──────────────────────────────────────────┐      │
│  │ PrerequisitesEnrichment (950000)         │      │
│  │ SkillsArtifactEnrichmentModule           │      │
│  │ → Scans cache                            │      │
│  │ → Reads file content                     │      │
│  │ → Creates artifacts with:                │      │
│  │   • Name = ".agents/skills/{id}/{file}"  │      │
│  │   • Content = file content               │      │
│  │   • excluded = false                     │      │
│  └──────────────────────────────────────────┘      │
│                    ↓                                │
│  ┌──────────────────────────────────────────┐      │
│  │ ArtifactValidation (970000)              │      │
│  │ ArtifactSecurityGuardModule              │      │
│  │ → Scans content for threats              │      │
│  │ → Sets excluded=true if threats found    │      │
│  └──────────────────────────────────────────┘      │
│                    ↓                                │
│  ┌──────────────────────────────────────────┐      │
│  │ ArtifactPersistence (1000000)            │      │
│  │ OutputArtifactsFilesWriterModule         │      │
│  │ → Writes if excluded=false               │      │
│  │ → Skips if excluded=true                 │      │
│  │ → Location determined by StoreResource   │      │
│  │ → Generates report                       │      │
│  └──────────────────────────────────────────┘      │
└─────────────────────────────────────────────────────┘
					↓
┌─────────────────────────────────────────────────────┐
│ OUTPUT                                              │
│ <outputPath>/.agents/skills/                        │
│   ├─ doc-coauthoring/                               │
│   │   ├─ SKILL.md                                   │
│   │   ├─ tool.js                                    │
│   │   └─ config.json                                │
│   └─ claude-api/                                    │
│       └─ ...                                        │
│                                                      │
│ artifacts.deployment.report.md                      │
└─────────────────────────────────────────────────────┘
```

---

## 📝 Rapport généré : `artifacts.deployment.report.md`

```markdown
# Artifacts Deployment Report

Generated: 2025-01-15 14:30:00 UTC

## Summary

- ✅ Written: 8 artifacts
- ❌ Excluded: 12 artifacts

## Exclusions by Category

### ❌ Skill
- **Count**: 12 artifact(s)
- **Reason**: security-threats

---

*This report was generated automatically during the artifact persistence phase.*
```

---

## 🎯 Principes d'architecture

### ✅ Séparation des responsabilités

1. **Enrichment Module** : Détermine QUÉ et OÙ
   - Lit le contenu
   - Définit le `StoreResource` (chemin de sortie)
   - Initialise les metadata

2. **Guard Modules** : Valide et marque
   - Scanne le contenu
   - Modifie `metadata["excluded"]`

3. **Writer Module** : Écrit (générique pour tous artifacts)
   - Respecte `excluded`
   - Écrit à l'emplacement défini par `StoreResource`
   - Génère des rapports

### ✅ Extensibilité

Le pattern fonctionne pour **n'importe quel type d'artifact** :

```csharp
// Example: MCP Tools enrichment
output.AddArtifact(builder => builder
	.WithCategory(ArtifactCategory.Tool)
	.WithName(".agents/tools/{toolId}/{file}")  // Détermine le placement
	.InStore("Output")
	.WithContent(fileContent)
	.WithMetadata("excluded", "false")
);

// Le writer écrira automatiquement à .agents/tools/{toolId}/{file}
// en respectant les exclusions
```

---

## ✅ Résumé

**2 modules spécifiques Skills + 1 module Security générique + 1 module Writer générique** :
1. ✅ `SkillsArtifactEnrichmentModule` - Enregistre avec contenu et placement (Skills spécifique)
2. ✅ `ArtifactSecurityGuardModule` - Scanne et marque les menaces (Security, générique pour Skills/Tools/Config)
3. ✅ `OutputArtifactsFilesWriterModule` - Écrit tous les artifacts (Core, générique)

**Avantages** :
- ✅ Le writer ne décide pas du placement (défini lors de l'enrichissement)
- ✅ Security guard générique réutilisable pour Tools, Configuration, etc.
- ✅ Un seul writer pour tous les artifacts
- ✅ Séparation claire des responsabilités et organisation modulaire
- ✅ Module de sécurité dans `Features/Security/` (bonne pratique d'architecture)

**Build** : ✅ Succès sans erreurs

---

## 📊 Flow complet

```
┌─────────────────────────────────────────────────────┐
│ 1. RESTORE (CLI)                                    │
│    ctxc skills restore                              │
│    → Downloads skills to .ctxc/cache/skills/        │
└─────────────────────────────────────────────────────┘
					↓
┌─────────────────────────────────────────────────────┐
│ 2. COMPILE (CompilePipeline)                         │
│    ctxc compile                                     │
│                                                      │
│  ┌──────────────────────────────────────────┐      │
│  │ PrerequisitesEnrichment (950000)         │      │
│  │ SkillsArtifactEnrichmentModule           │      │
│  │ → Scans cache                            │      │
│  │ → Registers as artifacts                 │      │
│  │ → Sets excluded=false                    │      │
│  └──────────────────────────────────────────┘      │
│                    ↓                                │
│  ┌──────────────────────────────────────────┐      │
│  │ ArtifactValidation (970000)              │      │
│  │ ArtifactSecurityGuardModule              │      │
│  │ → Scans for threats                      │      │
│  │ → Sets excluded=true if threats found    │      │
│  └──────────────────────────────────────────┘      │
│                    ↓                                │
│  ┌──────────────────────────────────────────┐      │
│  │ ArtifactPersistence (1000000)            │      │
│  │ SkillsArtifactDeploymentModule           │      │
│  │ → Deploys if excluded=false              │      │
│  │ → Skips if excluded=true                 │      │
│  │ → Generates report                       │      │
│  └──────────────────────────────────────────┘      │
└─────────────────────────────────────────────────────┘
					↓
┌─────────────────────────────────────────────────────┐
│ OUTPUT                                              │
│ .ctxc/compiled/.agents/skills/                      │
│   ├─ doc-coauthoring/                               │
│   │   ├─ SKILL.md                                   │
│   │   ├─ tool.js                                    │
│   │   └─ config.json                                │
│   └─ claude-api/                                    │
│       └─ ...                                        │
│                                                      │
│ skills.deployment.report.md                         │
└─────────────────────────────────────────────────────┘
```

---

## 📝 Rapport généré : `skills.deployment.report.md`

```markdown
# Skills Deployment Report

Generated: 2025-01-15 14:30:00 UTC

## Summary

- ✅ Deployed: 8 files
- ❌ Excluded: 12 files
- ⚠️ Skipped: 0 files

## Excluded Skills

### ❌ skill-creator
- **Reason**: security-threats

### ❌ mcp-builder
- **Reason**: security-threats

---

*This report was generated automatically during the artifact deployment phase.*
```

---

## ⚙️ Configuration

### ctxc.config.json (existant)
```json
{
  "skills": {
	"cacheRoot": ".ctxc/cache/skills",
	"compiledRoot": ".ctxc/compiled/.agents/skills",
	"items": {
	  "skill-creator": "anthropic-agent-skills@main",
	  "doc-coauthoring": "anthropic-agent-skills@main",
	  "claude-api": "anthropic-agent-skills@main"
	},
	"validation": {
	  "security": {
		"enabled": true,
		"whitelistedDomains": [
		  "github.com",
		  "anthropic.com",
		  "microsoft.com"
		]
	  }
	}
  }
}
```

---

## 🚀 Usage

### 1. Restore des skills
```bash
ctxc skills restore
```
Télécharge les skills dans `.ctxc/cache/skills/`

### 2. Compile avec validation
```bash
ctxc compile
```
- Enrichit les artifacts
- Scanne pour sécurité
- Déploie les skills validés

### 3. Consulter le rapport
```bash
cat .ctxc/compiled/skills.deployment.report.md
```

---

## 🔧 Prochaines étapes (optionnel)

### A. Affiner les patterns de sécurité
Ajouter/retirer des patterns dans `ArtifactSecurityGuardModule`:
```csharp
private static readonly string[] DangerousPatterns =
[
	"eval(",
	"exec(",
	// Ajouter vos patterns ici
];
```

### B. Configurer les domaines autorisés
Dans `ctxc.config.json`:
```json
{
  "skills": {
	"validation": {
	  "security": {
		"whitelistedDomains": [
		  "github.com",
		  "votredomaine.com"
		]
	  }
	}
  }
}
```

### C. Mode permissif (déployer malgré les threats)
Créer un flag de configuration:
```json
{
  "skills": {
	"validation": {
	  "security": {
		"enabled": true,
		"blockOnThreats": false  // ⚠️ Permet le déploiement malgré les menaces
	  }
	}
  }
}
```

Puis dans `ArtifactSecurityGuardModule`:
```csharp
if (config.Validation.Security.BlockOnThreats)
{
	metadata["excluded"] = "true";
}
else
{
	logger.LogWarning("Threats found but blockOnThreats=false, allowing deployment");
}
```

---

## ✅ Résumé

**3 modules implémentés** :
1. ✅ `SkillsArtifactEnrichmentModule` - Enregistre les skills du cache
2. ✅ `ArtifactSecurityGuardModule` - Scanne et marque les menaces
3. ✅ `SkillsArtifactDeploymentModule` - Déploie uniquement les skills sûrs

**Fonctionnalités** :
- ✅ Scan de sécurité automatique
- ✅ Exclusion basée sur metadata
- ✅ Rapport de déploiement
- ✅ Support de multiples skills
- ✅ Groupement par skill pour exclusion

**Build** : ✅ Succès sans erreurs
