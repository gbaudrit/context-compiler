"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PersonaNode = exports.CtxcPersonasProvider = void 0;
const vscode = require("vscode");
const fs = require("fs");
const path = require("path");
class CtxcPersonasProvider {
    workspaceRoot;
    outputDir;
    _onDidChangeTreeData = new vscode.EventEmitter();
    onDidChangeTreeData = this._onDidChangeTreeData.event;
    activePersonaId;
    constructor(workspaceRoot, outputDir) {
        this.workspaceRoot = workspaceRoot;
        this.outputDir = outputDir;
    }
    setOutputDir(outputDir) {
        this.outputDir = outputDir;
    }
    setActivePersona(personaId) {
        this.activePersonaId = personaId;
        this.refresh();
    }
    getActivePersonaId() {
        return this.activePersonaId;
    }
    refresh() {
        this._onDidChangeTreeData.fire();
    }
    getTreeItem(element) {
        return element;
    }
    getChildren() {
        const personasPath = path.join(this.workspaceRoot, this.outputDir, "personas.active.json");
        if (!fs.existsSync(personasPath))
            return Promise.resolve([]);
        let parsed;
        try {
            parsed = JSON.parse(fs.readFileSync(personasPath, "utf-8"));
        }
        catch {
            return Promise.resolve([]);
        }
        const active = new Set((parsed?.active ?? []).filter(Boolean));
        const results = (parsed?.results ?? []).filter(r => r && typeof r.PersonaId === "string");
        const nodes = results.map(r => {
            const id = r.PersonaId;
            const isActive = active.has(id);
            const title = r.Title?.trim() ? r.Title.trim() : id;
            const isCurrent = this.activePersonaId === id;
            const label = isCurrent ? `✓ ${id}` : (isActive ? `${id}` : id);
            const framing = r.FramingMarkdown ?? "";
            return new PersonaNode(label, title, r.Role ?? "", id, framing, personasPath, isActive);
        });
        nodes.sort((a, b) => {
            if (a.personaId === this.activePersonaId)
                return -1;
            if (b.personaId === this.activePersonaId)
                return 1;
            if (a.isActive && !b.isActive)
                return -1;
            if (!a.isActive && b.isActive)
                return 1;
            return a.personaId.localeCompare(b.personaId);
        });
        return Promise.resolve(nodes);
    }
}
exports.CtxcPersonasProvider = CtxcPersonasProvider;
class PersonaNode extends vscode.TreeItem {
    label;
    title;
    role;
    personaId;
    framingMarkdown;
    sourceFilePath;
    isActive;
    constructor(label, title, role, personaId, framingMarkdown, sourceFilePath, isActive) {
        super(label, vscode.TreeItemCollapsibleState.None);
        this.label = label;
        this.title = title;
        this.role = role;
        this.personaId = personaId;
        this.framingMarkdown = framingMarkdown;
        this.sourceFilePath = sourceFilePath;
        this.isActive = isActive;
        this.tooltip = `${title}${role ? `\n${role}` : ""}`;
        this.description = role || title;
        this.command = {
            command: "ctxc.setActivePersonaFromTree",
            title: "Set Active Persona",
            arguments: [this]
        };
        this.contextValue = "ctxcPersona";
    }
}
exports.PersonaNode = PersonaNode;
//# sourceMappingURL=personasTree.js.map