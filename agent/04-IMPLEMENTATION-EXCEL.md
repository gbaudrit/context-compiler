# Bloc 4 — Implémentation Excel Multi-Extract

## Provider de configuration

Créer :
- IExtractionProfileProvider
- JsonExtractionProfileProvider

Lit ctxc.config.json depuis rootPath.
Si absent → fallback.

## ExcelExtractDataReader

- Implémente IDataReaderPlugin
- Charge workbook (ClosedXML)
- Applique profiles/extracts
- Retourne CompositeDataEnvelope

Chaque extract :
- sélectionne sheet
- table ou range
- select/exclude/rename
- where filters
- produit DataPart
