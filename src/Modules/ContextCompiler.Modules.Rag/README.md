# ContextCompiler.Modules.Rag

Squelette initial pour un module RAG local :

- embeddings locaux via `SmartComponents.LocalEmbeddings`
- persistance simple dans `.ctxc/rag`
- service de recherche sémantique
- enregistrement DI dédié

## À faire ensuite

1. brancher la vraie config du compilateur
2. remplacer le stockage JSON par un format plus compact (`chunks.jsonl` + buffers binaires)
3. ajouter le chunking
4. ajouter l'exposition MCP si tu veux garder la même philosophie que `Artifacts.Registry`
5. optionnel : ajouter un plugin `ContextCompiler.Modules.SemanticKernel`
