import * as vscode from "vscode";
import * as cp from "child_process";
import * as path from "path";
import * as fs from "fs";
import { CtxcViewsProvider, ViewNode } from "./viewsTree";

type LastRun = { root: string; configPath: string };

function getWorkspaceRoot(): string | undefined {
  const wf = vscode.workspace.workspaceFolders?.[0];
  return wf?.uri.fsPath;
}

function getConfig() {
  const cfg = vscode.workspace.getConfiguration("ctxc");
  return {
    cliPath: cfg.get<string>("path", "ctxc"),
    configPath: cfg.get<string>("configPath", "ctxc.config.json"),
    outputDir: cfg.get<string>("outputDir", ".ctxc/out")
  };
}

function exists(p: string): boolean {
  try { return fs.existsSync(p); } catch { return false; }
}

function runCtxcCompile(output: vscode.OutputChannel, status: vscode.StatusBarItem, cliPath: string, root: string, configPath: string): Promise<number> {
  return new Promise((resolve) => {
    status.text = "CtxC: Compiling…";
    status.show();

    const args = ["compile", "--root", root, "--config", configPath];
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
  return fs.readdirSync(viewsDir).filter(f => f.toLowerCase().endsWith(".md")).map(f => f.replace(/\.md$/i, ""));
}

async function buildPromptFromActiveView(workspaceRoot: string, outputDir: string, activeViewId: string): Promise<string> {
  const viewPath = path.join(workspaceRoot, outputDir, "views", `${activeViewId}.md`);
  if (!exists(viewPath)) throw new Error(`View not found: ${viewPath}`);
  const viewContent = fs.readFileSync(viewPath, "utf-8");

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

  const compileButton = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Left, 100);
  compileButton.text = "$(gear) CtxC: Compile";
  compileButton.command = "ctxc.compileWorkspace";
  compileButton.tooltip = "Compile context for current workspace";
  compileButton.show();

  const copyButton = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Left, 99);
  copyButton.text = "$(copy) CtxC: Copy View";
  copyButton.command = "ctxc.copyActiveViewPrompt";
  copyButton.tooltip = "Copy active CtxC view + framing to clipboard";
  copyButton.show();

  context.subscriptions.push(compileButton, copyButton);

  const workspaceRoot = getWorkspaceRoot();
  if (!workspaceRoot) return;

  const cfg = getConfig();
  let lastRun: LastRun | undefined;

  const viewsProvider = new CtxcViewsProvider(workspaceRoot, cfg.outputDir);
  vscode.window.registerTreeDataProvider("ctxcViews", viewsProvider);

  context.subscriptions.push(status, output);
  const compileButton = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Left, 100);
  compileButton.text = "$(gear) CtxC: Compile";
  compileButton.command = "ctxc.compileWorkspace";
  compileButton.tooltip = "Compile context for current workspace";
  compileButton.show();

  const copyButton = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Left, 99);
  copyButton.text = "$(copy) CtxC: Copy View";
  copyButton.command = "ctxc.copyActiveViewPrompt";
  copyButton.tooltip = "Copy active CtxC view + framing to clipboard";
  copyButton.show();

  context.subscriptions.push(compileButton, copyButton);


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
      viewsProvider.refresh();
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
      viewsProvider.refresh();
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
    if (code === 0) viewsProvider.refresh();
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
  }));
}

export function deactivate() {}
