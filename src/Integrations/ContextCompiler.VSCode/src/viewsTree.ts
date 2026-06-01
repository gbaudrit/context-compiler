import * as vscode from "vscode";
import * as fs from "fs";
import * as path from "path";

export class CtxcViewsProvider implements vscode.TreeDataProvider<ViewNode> {
  private _onDidChangeTreeData = new vscode.EventEmitter<ViewNode | undefined | null | void>();
  readonly onDidChangeTreeData = this._onDidChangeTreeData.event;

  private activeViewId: string | undefined;

  constructor(private readonly workspaceRoot: string, private outputDir: string) {}

  setOutputDir(outputDir: string): void {
    this.outputDir = outputDir;
  }

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
    const viewsDir = path.join(this.workspaceRoot, this.outputDir);
    if (!fs.existsSync(viewsDir)) return Promise.resolve([]);

    const nodes: ViewNode[] = [];
    for (const fileName of fs.readdirSync(viewsDir)) {
      const lower = fileName.toLowerCase();
      let id: string | undefined;

      const m = /^view\.(.+)\.json$/i.exec(fileName);
      if (m?.[1]) id = m[1];

      if (!id) continue;
      const label = (this.activeViewId === id) ? `✓ ${id}` : id;
      const filePath = path.join(viewsDir, fileName);
      nodes.push(new ViewNode(label, fileName, filePath, id));
    }

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
    public readonly fileName: string,
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
