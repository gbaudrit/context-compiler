# ContextCompiler.Modules.Commands.Registry

Squelette inspiré de `ContextCompiler.Modules.Artifacts.Registry`.

Contenu :
- index `commands.index.json`
- store de lecture du dernier index compilé
- sérialisation JSON
- outil MCP `ListCommands`

## TODO
- brancher la vraie source des commandes du noyau / des plugins dans `CommandIndexModule`
- enrichir `CommandDescriptor` selon le contrat réel des commandes
- ajouter éventuellement un handler `TryGetCommand`
