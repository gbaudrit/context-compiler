# ContextCompiler.Modules.Connectors.Git

`ContextCompiler.Modules.Connectors.Git` clone des dépôts Git dans le workspace avant le pipeline `Documents`, puis ajoute automatiquement des entrées `files` pour compiler le contenu cloné comme des sources locales.

Exemple :

```json
{
  "files": [
    {
      "includes": [],
      "options": {
        "connectors.git": {
          "repositories": [
            {
              "id": "ctxc-wiki",
              "repository": "gbaudrit/context-compiler",
              "wiki": true,
              "refresh": true,
              "includes": ["**/*.md"],
              "tags": ["source:reference"]
            }
          ]
        }
      }
    }
  ]
}
```

Cible par défaut :

- dépôt : `.external/git/<owner>/<repo>`
- wiki : `.external/git/<owner>/<repo>.wiki`
