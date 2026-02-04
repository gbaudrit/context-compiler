import * as vscode from "vscode";
import * as fs from "fs";
import * as path from "path";

type PersonasActiveFile = {
	active?: string[];
	mode?: string;
	results?: PersonaResult[];
};

type PersonaResult = {
	PersonaId: string;
	Title?: string;
	Role?: string;
	FramingMarkdown?: string;
	Metadata?: unknown;
	Must?: unknown;
	MustNot?: unknown;
};

export class CtxcPersonasProvider implements vscode.TreeDataProvider<PersonaNode> {
	private _onDidChangeTreeData = new vscode.EventEmitter<PersonaNode | undefined | null | void>();
	readonly onDidChangeTreeData = this._onDidChangeTreeData.event;

	private activePersonaId: string | undefined;

	constructor(private readonly workspaceRoot: string, private outputDir: string) {}

	setOutputDir(outputDir: string): void {
		this.outputDir = outputDir;
	}

	setActivePersona(personaId: string | undefined): void {
		this.activePersonaId = personaId;
		this.refresh();
	}

	getActivePersonaId(): string | undefined {
		return this.activePersonaId;
	}

	refresh(): void {
		this._onDidChangeTreeData.fire();
	}

	getTreeItem(element: PersonaNode): vscode.TreeItem {
		return element;
	}

	getChildren(): Thenable<PersonaNode[]> {
		const personasPath = path.join(this.workspaceRoot, this.outputDir, "personas.active.json");
		if (!fs.existsSync(personasPath)) return Promise.resolve([]);

		let parsed: PersonasActiveFile | undefined;
		try {
			parsed = JSON.parse(fs.readFileSync(personasPath, "utf-8"));
		} catch {
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
			if (a.personaId === this.activePersonaId) return -1;
			if (b.personaId === this.activePersonaId) return 1;
			if (a.isActive && !b.isActive) return -1;
			if (!a.isActive && b.isActive) return 1;
			return a.personaId.localeCompare(b.personaId);
		});

		return Promise.resolve(nodes);
	}
}

export class PersonaNode extends vscode.TreeItem {
	constructor(
		public readonly label: string,
		public readonly title: string,
		public readonly role: string,
		public readonly personaId: string,
		public readonly framingMarkdown: string,
		public readonly sourceFilePath: string,
		public readonly isActive: boolean
	) {
		super(label, vscode.TreeItemCollapsibleState.None);
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
