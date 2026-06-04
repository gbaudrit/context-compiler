# Architecture Decision: Generic Artifact Writer

## Context

Lors de l'implémentation de la validation et du déploiement des skills, nous avons découvert qu'il existait déjà un module `OutputArtifactsFilesWriterModule` responsable d'écrire les artifacts.

## Decision

✅ **Utiliser et améliorer le writer générique existant** plutôt que créer des writers spécifiques par catégorie d'artifact.

## Rationale

### Principes

1. **Séparation des responsabilités**
   - **Enrichment** : Détermine le contenu ET le placement
   - **Validation** : Valide et marque pour exclusion
   - **Writer** : Écrit (générique, agnostique du type)

2. **Le placement est déterminé à l'enrichissement**
   ```csharp
   // L'enrichment définit OÙ l'artifact sera écrit
   .WithName(".agents/skills/{skillId}/{file}")
   .InStore("Output")

   // Le StoreResource pointe vers: <OutputRoot>/.agents/skills/{skillId}/{file}
   ```

3. **Le writer respecte les exclusions**
   ```csharp
   if (artifact.Metadata["excluded"] == "true") {
	   skip();
   } else {
	   artifact.StoreResource.WriteAllText(artifact.Content);
   }
   ```

## Implementation

### Modules Skills

| Module | Phase | Priority | Responsabilité |
|--------|-------|----------|----------------|
| `SkillsArtifactEnrichmentModule` | PrerequisitesEnrichment (950000) | 1000 | Scanne cache, lit contenu, crée artifacts avec `Name=".agents/skills/{id}/{file}"` |
| `ArtifactSecurityGuardModule` | ArtifactValidation (970000) | 2000 | Scanne contenu, marque `excluded=true` si menaces |
| `OutputArtifactsFilesWriterModule` | ArtifactPersistence (1000000) | 10 | Écrit tous artifacts si `excluded=false` |

### Flow de données

```
SkillsArtifactEnrichmentModule
	↓ (crée artifacts)
	↓ Name = ".agents/skills/{id}/{file}"
	↓ Content = file content
	↓ excluded = "false"
	↓
ArtifactSecurityGuardModule
	↓ (scanne)
	↓ Si menace : excluded = "true"
	↓
OutputArtifactsFilesWriterModule
	↓ (écrit si excluded = false)
	↓ artifact.StoreResource.WriteAllText(content)
	↓
Output: <OutputRoot>/.agents/skills/{id}/{file}
```

## Benefits

✅ **Réutilisabilité** : Pattern applicable à tous types d'artifacts (Skills, Tools, Config)

✅ **Cohérence** : Un seul writer pour tout

✅ **Flexibilité** : Le placement est défini par l'enrichment, pas hardcodé dans le writer

✅ **Maintenabilité** : Un seul endroit pour la logique d'exclusion et de reporting

## Example: Adding MCP Tools Support

```csharp
// 1. Create McpToolsArtifactEnrichmentModule
public class McpToolsArtifactEnrichmentModule : ICompilePipelineModule
{
	public Task<IResult<ICompilePipelineRunResult>> Run(...)
	{
		output.AddArtifact(builder => builder
			.WithCategory(ArtifactCategory.Tool)
			.WithName(".agents/tools/{toolId}/{file}")  // Placement défini ici
			.InStore("Output")
			.WithContent(fileContent)
			.WithMetadata("excluded", "false")
		);
	}
}

// 2. Le writer existant écrit automatiquement à .agents/tools/
// 3. Les guards existants peuvent marquer excluded=true
// 4. Aucune modification du writer nécessaire !
```

## Consequences

### Positive

- ✅ Un seul writer à maintenir
- ✅ Pattern cohérent et prévisible
- ✅ Facile d'ajouter de nouveaux types d'artifacts
- ✅ Le writer ne décide pas du placement (responsabilité de l'enrichment)

### Negative

- ⚠️ Le contenu doit être chargé en mémoire lors de l'enrichment
- ⚠️ Pour de gros fichiers, considérer un stream plutôt que `WithContent()`

### Mitigation

Pour les gros fichiers, on peut utiliser :
```csharp
.IsStreamedContent()  // Content vide
// Et modifier le writer pour copier depuis sourcePath si streamed
```

## Status

✅ **Accepté et implémenté**

## Notes

- Le module `SkillsArtifactDeploymentModule` a été supprimé (redondant)
- `OutputArtifactsFilesWriterModule` a été enrichi avec :
  - Respect des `excluded=true`
  - Génération de `artifacts.deployment.report.md`
  - Compteurs par catégorie

## Related Documents

- `docs/ARTIFACTS-VALIDATION.md` - Architecture complète
- `docs/SKILLS-VALIDATION-SUMMARY.md` - Implémentation détaillée
