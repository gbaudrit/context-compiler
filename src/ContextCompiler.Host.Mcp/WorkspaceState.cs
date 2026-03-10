namespace ContextCompiler.Host.Mcp;

public sealed class WorkspaceState
{
    public Dictionary<string, string> Artifacts { get; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, string> Views { get; } = new(StringComparer.OrdinalIgnoreCase);

    public void LoadFromOutput(string outputPath)
    {
        Artifacts.Clear();
        Views.Clear();

        if (!Directory.Exists(outputPath))
        {
            return;
        }

        foreach (string f in Directory.EnumerateFiles(outputPath))
        {
            string name = Path.GetFileName(f);
            Artifacts[name] = Path.GetFullPath(f);

            if (name.StartsWith("view.", StringComparison.OrdinalIgnoreCase) && name.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
            {
                string id = name["view.".Length..^".md".Length];
                Views[id] = File.ReadAllText(f);
            }
        }
    }
}
