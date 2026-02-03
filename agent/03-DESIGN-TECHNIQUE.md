# Bloc 3 — Design technique (Excel Multi-Extract)

## Modèles à ajouter (Abstractions)

### CompositeDataEnvelope
Représente plusieurs extractions issues d’un même document.

- Parts : IReadOnlyList<DataPart>

### DataPart
- PartId : string (extractId)
- Source : SourceRef (path + locatorPrefix)
- Envelope : DataEnvelope

## Intégration Pipeline

Le DocumentPipelineRunner doit :
- détecter CompositeDataEnvelope
- itérer sur Parts
- appliquer engineering, guards, transcoding par part
- construire les locators avec le prefix extractId

## Evidence Locator

Format obligatoire :
extract:<id>/sheet:<name>/table:<table>/row:<n>

## Déterminisme

- Trier extracts par id
- Trier lignes et groupes
- Hashing stable
