# Context Compiler Marketing Site Kit

Ce dossier contient un site vitrine statique pour **Context Compiler**.

## Contenu

- `index.html` : landing page complète
- `styles.css` : identité visuelle et responsive design
- `app.js` : interactions légères (menu mobile, reveal, année)
- `robots.txt` : directives de crawl
- `sitemap.xml` : sitemap de base
- `site.webmanifest` : manifest minimal
- `assets/` : logo, favicon et visuels SVG
- `assets/ctxc_logo_transparent.png` : logo transparent fourni pour intégration directe
- `COPY-DECK.md` : base de message / SEO / adaptations conseillées

## Usage

1. Garder ce dossier dans le repo courant.
2. Déployer en statique sur le domaine `contextcompiler.io`.
3. Si besoin, compléter ensuite les liens documentation / contact dans `index.html`.

## Publication rapide

Le site ne nécessite aucun build.

- GitHub Pages : publier le dossier à la racine du repo cible
- Netlify : dossier de publication = `.`
- Vercel : framework preset = `Other`, output = `.`

## Ajustements recommandés avant mise en ligne

- brancher les futurs liens documentation / contact si besoin
- ajuster les CTA si tu ajoutes une démo, une waitlist ou une page docs
- si besoin, remplacer la couleur d'accent `#F89F0A` si `#F89FA` était une autre valeur voulue
