"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CommandNode = exports.CtxcCommandsProvider = void 0;
const vscode = require("vscode");
const fs = require("fs");
const path = require("path");
class CtxcCommandsProvider {
    workspaceRoot;
    outputDir;
    _onDidChangeTreeData = new vscode.EventEmitter();
    onDidChangeTreeData = this._onDidChangeTreeData.event;
    constructor(workspaceRoot, outputDir) {
        this.workspaceRoot = workspaceRoot;
        this.outputDir = outputDir;
    }
    setOutputDir(outputDir) {
        this.outputDir = outputDir;
    }
    refresh() {
        this._onDidChangeTreeData.fire();
    }
    getTreeItem(element) {
        return element;
    }
    getChildren() {
        const commandsPath = path.join(this.workspaceRoot, this.outputDir, "commands.index.json");
        if (!fs.existsSync(commandsPath)) {
            return Promise.resolve([]);
        }
        let parsed;
        try {
            parsed = JSON.parse(fs.readFileSync(commandsPath, "utf-8"));
        }
        catch {
            return Promise.resolve([]);
        }
        const commands = (parsed?.commands ?? []).filter((c) => !!c && typeof c.id === "string");
        const nodes = commands
            .map((command) => new CommandNode(command.id, command.description ?? "", command.personaId ?? "", command.aliases ?? [], command.arguments ?? []))
            .sort((a, b) => a.commandId.localeCompare(b.commandId));
        return Promise.resolve(nodes);
    }
}
exports.CtxcCommandsProvider = CtxcCommandsProvider;
class CommandNode extends vscode.TreeItem {
    commandId;
    commandDescription;
    personaId;
    aliases;
    argumentsList;
    constructor(commandId, commandDescription, personaId, aliases, argumentsList) {
        super(commandId, vscode.TreeItemCollapsibleState.None);
        this.commandId = commandId;
        this.commandDescription = commandDescription;
        this.personaId = personaId;
        this.aliases = aliases;
        this.argumentsList = argumentsList;
        const descriptionParts = [];
        if (personaId) {
            descriptionParts.push(`persona: ${personaId}`);
        }
        if (aliases.length > 0) {
            descriptionParts.push(`aliases: ${aliases.join(", ")}`);
        }
        this.description =
            descriptionParts.length > 0 ? descriptionParts.join(" • ") : commandDescription;
        const tooltipLines = [commandId];
        if (commandDescription) {
            tooltipLines.push(commandDescription);
        }
        if (personaId) {
            tooltipLines.push(`Persona: ${personaId}`);
        }
        if (aliases.length > 0) {
            tooltipLines.push(`Aliases: ${aliases.join(", ")}`);
        }
        if (argumentsList.length > 0) {
            tooltipLines.push(`Arguments: ${argumentsList.join(", ")}`);
        }
        this.tooltip = tooltipLines.join("\n");
        this.contextValue = "ctxcCommand";
        this.command = {
            command: "ctxc.executeCommandFromTree",
            title: "Execute Command",
            arguments: [this],
        };
    }
}
exports.CommandNode = CommandNode;
//# sourceMappingURL=commandsTree.js.map