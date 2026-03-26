# PersonaPlugin — Guide d’implémentation pour agent (Agent-Ultra)
**Date:** 2025-12-26  
**But:** fournir à un agent (Copilot/Codex) un plan d’actions *exécutable* pour implémenter un système de **Persona Plugins** + **configuration** dans `ctxc.config.json`, en respectant l’architecture Context Compiler (module-first, déterministe, testable).

---

## 0) Règles invariantes

- **Pré-LLM** : aucune interaction LLM.
- **Déterminisme** : ordering stable, pas d’aléatoire, pas de dépendance au temps.
- **Module-first** : la logique persona est portée par des modules, pas en dur.
- **Traçabilité** : la persona appliquée doit être visible dans les artefacts (metadata + prompt).
- **Testabilité** : MSTest + Moq + FluentAssertions.
- **Compatibilité** : si aucune persona n’est configurée, comportement identique à aujourd’hui.

---

## 1) Définition du concept “Persona”

Une **persona** est un overlay de framing global, destiné à orienter :
- le rôle (role)
- le style (tone)
- les priorités (focus)
- les contraintes de sortie (output contract)

Contraintes :
- Une persona ne modifie pas les données brutes.
- Une persona n’exécute pas de code LLM.
- Une persona se matérialise dans le **Template** (framing final) et/ou dans des **View**.
- Respecte C:\Users\g.baudrit\source\repos\gbaudrit\Git\context-compiler\src\ContextCompiler.Abstractions\Configuration\ctxc.config.schema.json pour la validation
---

## 2) Ajouts Abstractions (contrats)

### 2.1 Ajouter un nouveau type de plugin : PersonaPlugin
Créer dans `ContextCompiler.Abstractions/Plugins` :

- `IPersonaPlugin : IPlugin`
  - `string PersonaId { get; }`
  - `Task<PersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct)`

Créer les modèles :
- `PersonaContext`
  - `string RootPath`
  - `object ReasoningIr` (ReasoningIr)
  - `IReadOnlyDictionary<string, object>? Inputs` (optionnel)
- `PersonaResult`
  - `string PersonaId`
  - `string Title`
  - `string FramingMarkdown` (bloc markdown injecté dans le template)
  - `IReadOnlyDictionary<string,string>? Metadata`

Mettre à jour `PluginKinds` :
- ajouter `public const string Persona = "Persona";`

Mettre à jour `IPluginRegistry` :
- ajouter `IReadOnlyList<IPersonaPlugin> Personas { get; }`

Mettre à jour `PluginRegistry` et `PluginRegistryBuilder` pour découvrir les `IPersonaPlugin`.

---

## 3) Configuration — `ctxc.config.json`

### 3.1 Objectif
Permettre de sélectionner :
- 0..N personas activées
- un mode d’application (ex: `append`, `prepend`, `replace` framing)
- paramètres par persona (inputs)

### 3.2 Structure recommandée
Ajouter une section top-level :

```json
{
  "personas": {
    "active": ["dev_architect", "security_reviewer"],
    "mode": "append",
    "params": {
      "dev_architect": {
        "language": "fr",
        "style": "direct",
        "output": {
          "format": "markdown",
          "includeExamples": true
        }
      },
      "security_reviewer": {
        "severityBias": "high"
      }
    }
  }
}
```

- `active`: liste ordonnée (ordre = ordre d’application, déterministe)
- `mode`:
  - `append` : ajouter après framing standard
  - `prepend` : ajouter avant framing standard
  - `replace` : remplace framing standard (usage expert)
- `params`: dictionnaire optionnel, clé = personaId, valeur = JSON object libre

### 3.3 Provider de config
Si un provider existe déjà (Excel), l’étendre proprement :
- `IConfigProvider` lit `ctxc.config.json` une fois
- expose une vue strongly typed : `PersonaConfigSection GetPersonas()`

Sinon, créer :
- `IConfigProvider`
- `JsonConfigProvider`

⚠️ Toujours fallback : config absente => section personas vide.

---

## 4) Intégration Pipeline (Global)

### 4.1 Où appliquer la persona ?
La persona doit être appliquée **dans le Global Pipeline**, dans la phase de framing global, après l’étape `View` et avant le rendu final du prompt.

Recommandation :
- Le template `FramingTemplatePlugin` doit accepter un bloc “persona framing”.

### 4.2 Modification GlobalPipelineRunner
Ajouter :
1) Charger config personas via provider (injecté via DI).
2) Résoudre les `IPersonaPlugin` par `personaId` (active list).
3) Appeler `BuildAsync` pour chaque persona (priority + active order).
4) Produire un `personaFramingMarkdown` concaténé.

Injecter ce bloc dans le template :
- si `mode=append` : framing standard + persona framing
- si `mode=prepend` : persona framing + framing standard
- si `mode=replace` : persona framing uniquement

### 4.3 Artefacts
Écrire en sortie :
- `personas.active.json` (ids + metadata + order)
- optionnel : `persona.framing.md` (concat)

But : debug + audit.

---

## 5) Plugins BuiltIn — Persona exemples

Créer dans `ContextCompiler.Plugins.BuiltIn/Personas` :

### 5.1 `DevArchitectPersona`
PersonaId: `dev_architect`

Framing recommandé :
- rôle : Architecte .NET senior
- exigences : code testable, DI, SOLID, conventions
- output : markdown + sections fixes

### 5.2 `SecurityReviewerPersona`
PersonaId: `security_reviewer`

Framing recommandé :
- rôle : reviewer sécurité
- MUST : lister risques, secrets, injection
- output : checklist + recommendations

---

## 6) CLI & MCP (optionnel mais recommandé)

### 6.1 CLI
Ajouter à `ctxc compile` :
- `--persona <id1,id2>` override config active
- `--persona-mode <append|prepend|replace>` override
- `--config <file>` déjà prévu : permet de spécifier un chemin

Règle :
- CLI override > config file > defaults.

### 6.2 MCP
Optionnel : permettre dans `compile_context` un param `personas` ou respecter config.

---

## 7) Tests (MSTest)

Créer des tests unitaires couvrant :

1) **Config parsing**
- active list, mode, params

2) **Resolution**
- persona active non trouvée => finding Warning (ou log) + skip
- persona found => applied

3) **Template injection**
- mode append/prepend/replace produit le bon `prompt.context.md`

4) **Determinism**
- ordre des personas = ordre config
- concat stable

5) **Artifacts**
- `personas.active.json` créé avec metadata

Pour tests :
- mock `IConfigProvider` + `IPluginRegistry` + `IFileSystem`
- utiliser un IR minimal avec 1 fragment

---

## 8) Docs + MADR

### 8.1 Docs
Ajouter :
- `docs/PERSONAS.md` :
  - concept
  - config schema
  - exemples
  - interactions avec template/views

Mettre à jour :
- `PLUGINS.md` (ajouter PersonaPlugin)
- `OUTPUTS.md` (ajouter personas.active.json)

### 8.2 MADR
Créer `docs/decisions/0008-persona-plugins-and-config.md` :
- contexte : besoin d’overlays globaux (role/style/output)
- décision : PersonaPlugin + config `personas`
- conséquences : template injection + artefacts

---

## 9) Checklist “done”

- [ ] IPersonaPlugin + modèles ajoutés dans Abstractions
- [ ] PluginRegistry + builder supportent Personas
- [ ] Config provider supporte section `personas`
- [ ] GlobalPipelineRunner applique personas + écrit artefacts
- [ ] BuiltIn personas (2 exemples)
- [ ] CLI options (si choisi)
- [ ] MSTest complet
- [ ] Docs + MADR

---

## 10) Instructions à donner à l’agent (copier-coller)

> Implémente PersonaPlugin selon ce document.  
> Respecte la config `personas` dans `ctxc.config.json`.  
> Intègre au GlobalPipelineRunner avant écriture du prompt.  
> Ajoute 2 personas built-in (dev_architect, security_reviewer).  
> Écris les tests MSTest, mets à jour docs et ajoute une MADR.  
> Ne casse pas la compilation actuelle sans config.
