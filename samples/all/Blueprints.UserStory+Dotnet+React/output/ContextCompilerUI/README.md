# Context Compiler UI

Interface web d'assistance à l'utilisation des **modules**, **packs** et **blueprints** du projet [Context Compiler](https://github.com/gbaudrit/context-compiler).

---

## Structure

```
ContextCompilerUI/
├── docs/
│   └── user-stories.md          # User Stories (blueprint agile.userstory)
├── backend/
│   └── ContextCompilerUI.Api/   # .NET 8 Web API (blueprint dotnet.api.backend)
│       ├── Controllers/
│       ├── DTOs/
│       ├── Models/
│       ├── Services/
│       ├── Data/                # Catalog JSON files + artifacts.index.json
│       ├── Program.cs
│       └── appsettings.json
└── frontend/
    └── src/                     # React 18 + TypeScript (blueprint react.frontend)
        ├── components/
        ├── context/
        ├── hooks/
        ├── pages/
        ├── services/
        └── types/
```

---

## Démarrage

### Backend

```bash
cd backend/ContextCompilerUI.Api
dotnet run
# API disponible sur https://localhost:7080
# Swagger UI : https://localhost:7080/swagger
```

### Frontend

```bash
cd frontend
npm install
npm run dev
# App disponible sur http://localhost:5173
```

---

## Fonctionnalités (Sprint 1 — 17 SP)

| Page | User Story | Description |
|---|---|---|
| `/modules` | US-01 | Browse + filtrer les modules |
| `/packs` | US-02 | Browse les packs avec composition |
| `/blueprints` | US-03 | Browse blueprints + voir étapes et commandes |
| `/compose` | US-04 | Composer un contexte (sélection modules/packs/blueprints) |
| `/preview` | US-05 | Prévisualiser le prompt compilé (Markdown rendu / brut / artefacts) |

---

## Données

Les fichiers JSON de catalogue se trouvent dans `backend/.../Data/` :

- `modules.catalog.json` — liste des modules
- `packs.catalog.json` — liste des packs
- `blueprints.catalog.json` — liste des blueprints
- `artifacts.index.json` — index des artefacts produits

---

*Généré par l'exécution du blueprint `Blueprints.UserStory+Dotnet+React`*
