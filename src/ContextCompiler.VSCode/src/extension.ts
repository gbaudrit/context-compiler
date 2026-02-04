import * as vscode from "vscode";
import * as cp from "child_process";
import * as path from "path";
import * as fs from "fs";
import { CtxcViewsProvider, ViewNode } from "./viewsTree";
import { CtxcPersonasProvider, PersonaNode } from "./personasTree";
import { CtxcCommandsProvider, CommandNode, CommandDescriptor } from "./commandsTree";

type LastRun = { root: string; configPath: string };

function getWorkspaceRoot(): string | undefined {
  const wf = vscode.workspace.workspaceFolders?.[0];
  return wf?.uri.fsPath;
}

function getConfig() {
  const cfg = vscode.workspace.getConfiguration("ctxc");

  const envCliPath = (process.env.CTXC_PATH ?? "").trim();
  const envConfigPath = (process.env.CTXC_CONFIG_PATH ?? "").trim();
  const envOutputDir = (process.env.CTXC_OUTPUT_DIR ?? "").trim();

  return {
    cliPath: envCliPath.length > 0 ? envCliPath : cfg.get<string>("path", "ctxc"),
    modulesCliPath: envCliPath.length > 0 ? envCliPath : cfg.get<string>("modulesPath", "ctxc-modules"),
    configPath: envConfigPath.length > 0 ? envConfigPath : cfg.get<string>("configPath", "ctxc.config.json"),
    outputDir: envOutputDir.length > 0 ? envOutputDir : cfg.get<string>("outputDir", ".ctxc/compiled")
  };
}

function exists(p: string): boolean {
  try { return fs.existsSync(p); } catch { return false; }
}

function runCtxcCompile(output: vscode.OutputChannel, status: vscode.StatusBarItem, cliPath: string, root: string, configPath: string): Promise<number> {
  return new Promise((resolve) => {
    status.text = "CtxC: Compiling…";
    status.show();

    const args = ["compile", "--input", root];
    output.appendLine(`[ctxc] ${cliPath} ${args.join(" ")}`);

    const proc = cp.spawn(cliPath, args, { cwd: root, shell: true });

    proc.stdout.on("data", (d) => output.append(d.toString()));
    proc.stderr.on("data", (d) => output.append(d.toString()));

    proc.on("close", (code) => {
      const exitCode = code ?? 1;
      output.appendLine(`\n[ctxc] exited with code ${exitCode}`);
      status.text = exitCode === 0 ? "CtxC: Ready" : "CtxC: Failed";
      resolve(exitCode);
    });

    proc.on("error", (err) => {
      output.appendLine(`[ctxc] error: ${err.message}`);
      status.text = "CtxC: Failed";
      resolve(1);
    });
  });
}

function runCtxcRestore(output: vscode.OutputChannel, status: vscode.StatusBarItem, modulesCliPath: string, root: string, configPath: string): Promise<number> {
  return new Promise((resolve) => {
    status.text = "CtxC: Restoring…";
    status.show();

    const args = ["restore", "--input", root];
    output.appendLine(`[ctxc] ${modulesCliPath} ${args.join(" ")}`);

    const proc = cp.spawn(modulesCliPath, args, { cwd: root, shell: true });

    proc.stdout.on("data", (d) => output.append(d.toString()));
    proc.stderr.on("data", (d) => output.append(d.toString()));

    proc.on("close", (code) => {
      const exitCode = code ?? 1;
      output.appendLine(`\n[ctxc] exited with code ${exitCode}`);
      status.text = exitCode === 0 ? "CtxC: Ready" : "CtxC: Failed";
      resolve(exitCode);
    });

    proc.on("error", (err) => {
      output.appendLine(`[ctxc] error: ${err.message}`);
      status.text = "CtxC: Failed";
      resolve(1);
    });
  });
}

async function pickFolder(): Promise<string | undefined> {
  const selected = await vscode.window.showOpenDialog({
    canSelectFiles: false,
    canSelectFolders: true,
    canSelectMany: false,
    openLabel: "Select folder to compile"
  });
  return selected?.[0]?.fsPath;
}

async function listViews(workspaceRoot: string, outputDir: string): Promise<string[]> {
  const viewsDir = path.join(workspaceRoot, outputDir, "views");
  if (!exists(viewsDir)) return [];

  const ids = new Set<string>();
  for (const fileName of fs.readdirSync(viewsDir)) {
    if (fileName.toLowerCase().endsWith(".md")) {
      ids.add(fileName.replace(/\.md$/i, ""));
      continue;
    }

    const m = /^view\.(.+)\.json$/i.exec(fileName);
    if (m?.[1]) ids.add(m[1]);
  }

  return Array.from(ids).sort((a, b) => a.localeCompare(b));
}

async function listPersonas(workspaceRoot: string, outputDir: string): Promise<string[]> {
  const personasPath = path.join(workspaceRoot, outputDir, "personas.active.json");
  if (!exists(personasPath)) return [];

  try {
    const parsed: any = JSON.parse(fs.readFileSync(personasPath, "utf-8"));
    const results: any[] = Array.isArray(parsed?.results) ? parsed.results : [];
    const ids = results
      .map((r: any): string | undefined => (typeof r?.PersonaId === "string" ? r.PersonaId : undefined))
      .filter((x: string | undefined): x is string => typeof x === "string" && x.length > 0);

    return [...new Set(ids)].sort((a, b) => a.localeCompare(b));
  } catch {
    return [];
  }
}

async function listCommands(workspaceRoot: string, outputDir: string): Promise<CommandDescriptor[]> {
  const commandsPath = path.join(workspaceRoot, outputDir, "commands.index.json");
  if (!exists(commandsPath)) return [];

  try {
    const parsed: any = JSON.parse(fs.readFileSync(commandsPath, "utf-8"));
    const commands: CommandDescriptor[] = Array.isArray(parsed?.commands) ? parsed.commands : [];
    const ids = commands
      .map((r: any): CommandDescriptor | undefined => (typeof r?.id === "string" ? r : undefined))
      .filter((x: CommandDescriptor | undefined): x is CommandDescriptor => typeof x === "object" && x !== null);

    return [...new Set(ids)].sort((a, b) => a.id.localeCompare(b.id));
  } catch {
    return [];
  }
}

async function buildPromptFromActiveView(workspaceRoot: string, outputDir: string, activeViewId: string): Promise<string> {
  const viewsDir = path.join(workspaceRoot, outputDir, "views");
  const mdPath = path.join(viewsDir, `${activeViewId}.md`);
  const jsonPath = path.join(viewsDir, `view.${activeViewId}.json`);

  let viewContent: string | undefined;

  if (exists(mdPath)) {
    viewContent = fs.readFileSync(mdPath, "utf-8");
  } else if (exists(jsonPath)) {
    const raw = fs.readFileSync(jsonPath, "utf-8");
    try {
      const parsed: any = JSON.parse(raw);
      if (typeof parsed === "string") viewContent = parsed;
      else if (typeof parsed?.markdown === "string") viewContent = parsed.markdown;
      else if (typeof parsed?.content === "string") viewContent = parsed.content;
      else if (typeof parsed?.text === "string") viewContent = parsed.text;
      else viewContent = JSON.stringify(parsed, null, 2);
    } catch {
      viewContent = raw;
    }
  }

  if (viewContent == null) throw new Error(`View not found: ${mdPath} or ${jsonPath}`);

  const framing = [
    "# Context-Compiler — Active View",
    "",
    `View: ${activeViewId}`,
    "",
    "## Instructions",
    "- Use the content below as the primary context.",
    "- Cite evidence ids if present in the context.",
    "- If information is missing, say so explicitly.",
    "",
    "## View Content",
    ""
  ].join("\\n");

  return framing + viewContent;
}

export async function activate(context: vscode.ExtensionContext) {
  const output = vscode.window.createOutputChannel("CtxC");
  const status = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Left);
  status.text = "CtxC: Ready";
  status.show();

  const workspaceRoot = getWorkspaceRoot();
  if (!workspaceRoot) return;

  const cfg = getConfig();
  const cfgSection = vscode.workspace.getConfiguration("ctxc");
  const inspectedPath = cfgSection.inspect<string>("path");
  output.appendLine(`[ctxc] env CTXC_PATH: ${process.env.CTXC_PATH ?? ""}`);
  output.appendLine(`[ctxc] effective path: ${cfg.cliPath}`);
  output.appendLine(`[ctxc] inspect(path): ${JSON.stringify(inspectedPath)}`);
  let lastRun: LastRun | undefined;

  const viewsProvider = new CtxcViewsProvider(workspaceRoot, cfg.outputDir);
  vscode.window.registerTreeDataProvider("ctxcViews", viewsProvider);

  const personasProvider = new CtxcPersonasProvider(workspaceRoot, cfg.outputDir);
  vscode.window.registerTreeDataProvider("ctxcPersonas", personasProvider);

  const commandsProvider = new CtxcCommandsProvider(workspaceRoot, cfg.outputDir);
  vscode.window.registerTreeDataProvider("ctxcCommands", commandsProvider)

  context.subscriptions.push(
  vscode.commands.registerCommand("ctxc.copyCommandFromTree", async (commandNode: CommandNode) => {
    const { outputDir } = getConfig();
    const commands = await listCommands(workspaceRoot, outputDir);
    if (commands.length === 0) {
      vscode.window.showInformationMessage("No commands found. Run CtxC compile first.");
      return;
    }
    const command = commands.find(cmd => cmd.id === commandNode.commandId);
    if (!command) {
      vscode.window.showErrorMessage(`Command not found: ${commandNode.commandId}`);
      return;
    }
    await vscode.env.clipboard.writeText(`${command.personaId} ${command.id}:`);

    vscode.window.showInformationMessage(`Command copied: ${commandNode.commandId}`);
  })
);

context.subscriptions.push(
  vscode.commands.registerCommand("ctxc.executeCommandFromTree", async (commandNode: CommandNode) => {
    const { outputDir } = getConfig();
    const commands = await listCommands(workspaceRoot, outputDir);
    if (commands.length === 0) {
      vscode.window.showInformationMessage("No commands found. Run CtxC compile first.");
      return;
    }
    const command = commands.find(cmd => cmd.id === commandNode.commandId);
    if (!command) {
      vscode.window.showErrorMessage(`Command not found: ${commandNode.commandId}`);
      return;
    }
    //await vscode.env.clipboard.writeText(`${command.personaId} ${command.id}:`);

    vscode.commands.executeCommand(
      "workbench.action.chat.open",
      { query: `${command.personaId} ${command.id}:`,
      isPartialQuery: true }
    );
    vscode.window.showInformationMessage(`Command executed: ${commandNode.commandId}`);
  })
);

  context.subscriptions.push(status, output);
  const compileButton = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Left, 100);
  compileButton.text = "$(gear) CtxC: Compile";
  compileButton.command = "ctxc.compileWorkspace";
  compileButton.tooltip = "Compile context for current workspace";
  compileButton.show();

    context.subscriptions.push(status, output);
  const restoreButton = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Left, 100);
  restoreButton.text = "$(arrow-down) CtxC: Restore";
  restoreButton.command = "ctxc.restoreWorkspace";
  restoreButton.tooltip = "Restore context for current workspace";
  restoreButton.show();

  const copyButton = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Left, 99);
  copyButton.text = "$(copy) CtxC: Copy View";
  copyButton.command = "ctxc.copyActiveViewPrompt";
  copyButton.tooltip = "Copy active CtxC view + framing to clipboard";
  copyButton.show();

  context.subscriptions.push(compileButton, restoreButton, copyButton);


  context.subscriptions.push(vscode.commands.registerCommand("ctxc.compileWorkspace", async () => {
    const { cliPath, configPath } = getConfig();
    const configAbs = path.isAbsolute(configPath) ? configPath : path.join(workspaceRoot, configPath);
    if (!exists(configAbs)) {
      vscode.window.showErrorMessage(`CtxC config not found: ${configAbs}`);
      return;
    }
    output.show(true);
    const code = await runCtxcCompile(output, status, cliPath, workspaceRoot, configAbs);
    if (code === 0) {
      lastRun = { root: workspaceRoot, configPath: configAbs };
      const { outputDir } = getConfig();
      viewsProvider.setOutputDir?.(outputDir);
      personasProvider.setOutputDir(outputDir);
      commandsProvider.setOutputDir(outputDir);
      viewsProvider.refresh();
      personasProvider.refresh();
    }
  }));

  context.subscriptions.push(vscode.commands.registerCommand("ctxc.restoreWorkspace", async () => {
    const { modulesCliPath, configPath } = getConfig();
    const configAbs = path.isAbsolute(configPath) ? configPath : path.join(workspaceRoot, configPath);
    if (!exists(configAbs)) {
      vscode.window.showErrorMessage(`CtxC config not found: ${configAbs}`);
      return;
    }
    output.show(true);
    const code = await runCtxcRestore(output, status, modulesCliPath, workspaceRoot, configAbs);
    if (code === 0) {
      lastRun = { root: workspaceRoot, configPath: configAbs };
      const { outputDir } = getConfig();
      viewsProvider.setOutputDir?.(outputDir);
      personasProvider.setOutputDir(outputDir);
      viewsProvider.refresh();
      personasProvider.refresh();
    }
  }));


  context.subscriptions.push(vscode.commands.registerCommand("ctxc.compileFolder", async () => {
    const folder = await pickFolder();
    if (!folder) return;

    const { cliPath, configPath } = getConfig();
    const configAbs = path.isAbsolute(configPath) ? configPath : path.join(folder, configPath);
    if (!exists(configAbs)) {
      vscode.window.showErrorMessage(`CtxC config not found: ${configAbs}`);
      return;
    }
    output.show(true);
    const code = await runCtxcCompile(output, status, cliPath, folder, configAbs);
    if (code === 0) {
      lastRun = { root: folder, configPath: configAbs };
      const { outputDir } = getConfig();
      viewsProvider.setOutputDir?.(outputDir);
      personasProvider.setOutputDir(outputDir);
      viewsProvider.refresh();
      personasProvider.refresh();
    }
  }));

  context.subscriptions.push(vscode.commands.registerCommand("ctxc.recompileLast", async () => {
    if (!lastRun) {
      vscode.window.showInformationMessage("No previous CtxC run found.");
      return;
    }
    const { cliPath } = getConfig();
    output.show(true);
    const code = await runCtxcCompile(output, status, cliPath, lastRun.root, lastRun.configPath);
    if (code === 0) {
      const { outputDir } = getConfig();
      viewsProvider.setOutputDir?.(outputDir);
      personasProvider.setOutputDir(outputDir);
      viewsProvider.refresh();
      personasProvider.refresh();
    }
  }));

  context.subscriptions.push(vscode.commands.registerCommand("ctxc.openPersonaFramingFromTree", async (node: PersonaNode) => {
    if (!node?.personaId) return;

    const content = (node.framingMarkdown || "").replaceAll("{PersonaId}", node.personaId);
    const header = [
      "# Context-Compiler — Persona",
      "",
      `PersonaId: ${node.personaId}`,
      node.title ? `Title: ${node.title}` : "",
      node.role ? `Role: ${node.role}` : "",
      "",
      "## Framing",
      ""
    ].filter(Boolean).join("\n");

    const doc = await vscode.workspace.openTextDocument({
      language: "markdown",
      content: header + "\n" + content
    });
    await vscode.window.showTextDocument(doc, { preview: true });
  }));

  context.subscriptions.push(vscode.commands.registerCommand("ctxc.selectPersona", async () => {
    const { outputDir } = getConfig();
    const ids = await listPersonas(workspaceRoot, outputDir);
    if (ids.length === 0) {
      vscode.window.showInformationMessage("No personas found. Run CtxC compile first.");
      return;
    }
    const picked = await vscode.window.showQuickPick(ids, { placeHolder: "Select the active CtxC persona" });
    if (!picked) return;
    personasProvider.setActivePersona(picked);
    vscode.window.showInformationMessage(`CtxC active persona set to: ${picked}`);
  }));

  context.subscriptions.push(vscode.commands.registerCommand("ctxc.setActivePersonaFromTree", async (node: PersonaNode) => {
    if (!node?.personaId) return;
    personasProvider.setActivePersona(node.personaId);
    vscode.window.showInformationMessage(`CtxC active persona set to: ${node.personaId}`);

    const promptFile = "prompt.context.md";
    vscode.commands.executeCommand(
      "workbench.action.chat.open",
      "load #" + promptFile + " run command role #" + node.personaId + " (en français)"
    );
  }));

  context.subscriptions.push(vscode.commands.registerCommand("ctxc.selectView", async () => {
    const { outputDir } = getConfig();
    const ids = await listViews(workspaceRoot, outputDir);
    if (ids.length === 0) {
      vscode.window.showInformationMessage("No views found. Run CtxC compile first.");
      return;
    }
    const picked = await vscode.window.showQuickPick(ids, { placeHolder: "Select the active CtxC view" });
    if (!picked) return;
    viewsProvider.setActiveView(picked);
    vscode.window.showInformationMessage(`CtxC active view set to: ${picked}`);
  }));

  context.subscriptions.push(vscode.commands.registerCommand("ctxc.openOutputs", async () => {
    const { outputDir } = getConfig();
    const compiledPath = path.join(workspaceRoot, outputDir, "compiled.context.md");
    const viewsDir = path.join(workspaceRoot, outputDir, "views");

    const items: vscode.QuickPickItem[] = [
      { label: "compiled.context.md", description: compiledPath },
      { label: "views/", description: viewsDir }
    ];

    const pick = await vscode.window.showQuickPick(items, { placeHolder: "Open compiled outputs" });
    if (!pick) return;

    const target = pick.label === "views/" ? viewsDir : compiledPath;
    if (!exists(target)) {
      vscode.window.showErrorMessage(`Not found: ${target}`);
      return;
    }
    await vscode.commands.executeCommand("revealFileInOS", vscode.Uri.file(target));
  }));

  context.subscriptions.push(vscode.commands.registerCommand("ctxc.copyActiveViewPrompt", async () => {
    const { outputDir } = getConfig();
    const active = viewsProvider.getActiveViewId();
    if (!active) {
      vscode.window.showInformationMessage("No active view. Use 'CtxC: Select View' first.");
      return;
    }
    try {
      const text = await buildPromptFromActiveView(workspaceRoot, outputDir, active);
      await vscode.env.clipboard.writeText(text);
      vscode.window.showInformationMessage(`Copied active view prompt to clipboard: ${active}`);
    } catch (e: any) {
      vscode.window.showErrorMessage(e?.message ?? String(e));
    }
  }));

  context.subscriptions.push(vscode.commands.registerCommand("ctxc.setActiveViewFromTree", async (node: ViewNode) => {
    if (!node?.viewId) return;
    viewsProvider.setActiveView(node.viewId);
    vscode.window.showInformationMessage(`CtxC active view set to: ${node.viewId}`);

    const promptFile = "prompt.context.md";
    vscode.commands.executeCommand(
      "workbench.action.chat.open",
      "load #" + promptFile + " run command view #" + node.fileName + " (en français)"
    );
  }));
}

export function deactivate() {}
