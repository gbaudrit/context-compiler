import * as vscode from "vscode";
import * as fs from "fs";
import * as path from "path";

type CommandsIndexFile = {
  commands?: CommandDescriptor[];
};

export type CommandDescriptor = {
  id: string;
  description?: string;
  personaId?: string;
  aliases?: string[];
  arguments?: string[];
};

export class CtxcCommandsProvider implements vscode.TreeDataProvider<CommandNode> {
  private readonly _onDidChangeTreeData = new vscode.EventEmitter<void>();
  readonly onDidChangeTreeData = this._onDidChangeTreeData.event;

  constructor(
    private readonly workspaceRoot: string,
    private outputDir: string
  ) {}

  setOutputDir(outputDir: string): void {
    this.outputDir = outputDir;
  }

  refresh(): void {
    this._onDidChangeTreeData.fire();
  }

  getTreeItem(element: CommandNode): vscode.TreeItem {
    return element;
  }

  getChildren(): Thenable<CommandNode[]> {
    const commandsPath = path.join(
      this.workspaceRoot,
      this.outputDir,
      "commands.index.json"
    );

    if (!fs.existsSync(commandsPath)) {
      return Promise.resolve([]);
    }

    let parsed: CommandsIndexFile | undefined;

    try {
      parsed = JSON.parse(fs.readFileSync(commandsPath, "utf-8"));
    } catch {
      return Promise.resolve([]);
    }

    const commands = (parsed?.commands ?? []).filter(
      (c): c is CommandDescriptor => !!c && typeof c.id === "string"
    );

    const nodes = commands
      .map(
        (command) =>
          new CommandNode(
            command.id,
            command.description ?? "",
            command.personaId ?? "",
            command.aliases ?? [],
            command.arguments ?? []
          )
      )
      .sort((a, b) => a.commandId.localeCompare(b.commandId));

    return Promise.resolve(nodes);
  }
}

export class CommandNode extends vscode.TreeItem {
  constructor(
    public readonly commandId: string,
    public readonly commandDescription: string,
    public readonly personaId: string,
    public readonly aliases: readonly string[],
    public readonly argumentsList: readonly string[]
  ) {
    super(commandId, vscode.TreeItemCollapsibleState.None);

    const descriptionParts: string[] = [];

    if (personaId) {
      descriptionParts.push(`persona: ${personaId}`);
    }

    if (aliases.length > 0) {
      descriptionParts.push(`aliases: ${aliases.join(", ")}`);
    }

    this.description =
      descriptionParts.length > 0 ? descriptionParts.join(" • ") : commandDescription;

    const tooltipLines: string[] = [commandId];

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