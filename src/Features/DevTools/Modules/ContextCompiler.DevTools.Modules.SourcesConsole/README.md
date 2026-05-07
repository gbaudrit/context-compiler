# ContextCompiler.Modules.DevTools.SourcesConsole

`ContextCompiler.Modules.DevTools.SourcesConsole` affiche les sources dans la console pour le débogage et le développement.

Ce module permet d'inspecter les sources chargées par le compilateur avant le pipeline `Documents`.

## Utilisation

Exemple de configuration :

```json
{
  "files": [
    {
      "includes": ["**/*.cs"],
      "options": {
        "devtools.sources-console": {
          "enabled": true,
          "showConfig": true,
          "showTags": true
        }
      }
    }
  ]
}
```

## Options

- `enabled` (bool, default: `true`): Active ou désactive l'affichage
- `showConfig` (bool, default: `false`): Affiche la configuration de chaque source
- `showTags` (bool, default: `true`): Affiche les tags associés aux sources

## Sortie

Le module affiche pour chaque source :
- Le chemin racine (`RootPath`)
- Les patterns d'inclusion (`includes`)
- Les patterns d'exclusion (`excludes`)
- Les tags (si `showTags` est activé)
- La configuration complète (si `showConfig` est activé)
