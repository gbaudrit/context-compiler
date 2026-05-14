"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ViewNode = exports.CtxcViewsProvider = void 0;
const vscode = require("vscode");
const fs = require("fs");
const path = require("path");
class CtxcViewsProvider {
    workspaceRoot;
    outputDir;
    _onDidChangeTreeData = new vscode.EventEmitter();
    onDidChangeTreeData = this._onDidChangeTreeData.event;
    activeViewId;
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
    setActiveView(viewId) {
        this.activeViewId = viewId;
        this.refresh();
    }
    getActiveViewId() {
        return this.activeViewId;
    }
    getTreeItem(element) {
        return element;
    }
    getChildren() {
        const viewsDir = path.join(this.workspaceRoot, this.outputDir);
        if (!fs.existsSync(viewsDir))
            return Promise.resolve([]);
        const nodes = [];
        for (const fileName of fs.readdirSync(viewsDir)) {
            const lower = fileName.toLowerCase();
            let id;
            const m = /^view\.(.+)\.json$/i.exec(fileName);
            if (m?.[1])
                id = m[1];
            if (!id)
                continue;
            const label = (this.activeViewId === id) ? `✓ ${id}` : id;
            const filePath = path.join(viewsDir, fileName);
            nodes.push(new ViewNode(label, fileName, filePath, id));
        }
        nodes.sort((a, b) => {
            if (a.viewId === this.activeViewId)
                return -1;
            if (b.viewId === this.activeViewId)
                return 1;
            return a.viewId.localeCompare(b.viewId);
        });
        return Promise.resolve(nodes);
    }
}
exports.CtxcViewsProvider = CtxcViewsProvider;
class ViewNode extends vscode.TreeItem {
    label;
    fileName;
    filePath;
    viewId;
    constructor(label, fileName, filePath, viewId) {
        super(label, vscode.TreeItemCollapsibleState.None);
        this.label = label;
        this.fileName = fileName;
        this.filePath = filePath;
        this.viewId = viewId;
        this.tooltip = filePath;
        this.description = path.basename(filePath);
        this.command = {
            command: "vscode.open",
            title: "Open View",
            arguments: [vscode.Uri.file(filePath)]
        };
        this.contextValue = "ctxcView";
    }
}
exports.ViewNode = ViewNode;
//# sourceMappingURL=viewsTree.js.map