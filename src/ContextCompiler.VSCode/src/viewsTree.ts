import * as vscode from "vscode";
import * as fs from "fs";
import * as path from "path";

export class CtxcViewsProvider implements vscode.TreeDataProvider<ViewNode> {
  private _onDidChangeTreeData = new vscode.EventEmitter<ViewNode | undefined | null | void>();
  readonly onDidChangeTreeData = this._onDidChangeTreeData.event;

  private activeViewId: string | undefined;

  constructor(private readonly workspaceRoot: string, private readonly outputDir: string) {}

  refresh(): void {
    this._onDidChangeTreeData.fire();
  }

  setActiveView(viewId: string | undefined): void {
    this.activeViewId = viewId;
    this.refresh();
  }

  getActiveViewId(): string | undefined {
    return this.activeViewId;
  }

  getTreeItem(element: ViewNode): vscode.TreeItem {
    return element;
  }

  getChildren(): Thenable<ViewNode[]> {
    const viewsDir = path.join(this.workspaceRoot, this.outputDir, "views");
    if (!fs.existsSync(viewsDir)) return Promise.resolve([]);

    const files = fs.readdirSync(viewsDir).filter(f => f.toLowerCase().endsWith(".md"));
    const nodes = files.map(f => {
      const id = f.replace(/\.md$/i, "");
      const label = (this.activeViewId === id) ? `★ ${id}` : id;
      const filePath = path.join(viewsDir, f);
      return new ViewNode(label, filePath, id);
    });

    nodes.sort((a, b) => {
      if (a.viewId === this.activeViewId) return -1;
      if (b.viewId === this.activeViewId) return 1;
      return a.viewId.localeCompare(b.viewId);
    });

    return Promise.resolve(nodes);
  }
}

export class ViewNode extends vscode.TreeItem {
  constructor(
    public readonly label: string,
    public readonly filePath: string,
    public readonly viewId: string
  ) {
    super(label, vscode.TreeItemCollapsibleState.None);
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
