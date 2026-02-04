using System.Text.Json;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Workspace;
using ContextCompiler.Modules.Abstractions.Views;

using Microsoft.Extensions.DependencyInjection;

using ModelContextProtocol.Server;

namespace ContextCompiler.Host.Mcp;

[McpServerToolType]
public static class ContextCompilerTools
{
    private static readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web) { WriteIndented = true };

    //[McpServerTool, System.ComponentModel.Description("Compile a folder into Context Compiler artifacts (prompt, evidence index, graph, views). Returns a summary with output paths.")]
    //public static async Task<string> CompileContext(
    //    IServiceProvider services,
    //    string inputPath,
    //    string outputPath,
    //    string name,
    //    bool clean,
    //    int maxChars = 120000)
    //{
    //    ICompilerEngine engine = services.GetRequiredService<ICompilerEngine>();
    //    WorkspaceState state = services.GetRequiredService<WorkspaceState>();

    //    _ = Directory.CreateDirectory(outputPath);

    //    int rc = await engine.CompileAsync(
    //        new CompileRequest(inputPath, outputPath, name, clean, new CompileOptions(MaxCharacters: maxChars)),
    //        CancellationToken.None);

    //    // Refresh state (for resources)
    //    state.LoadFromOutput(outputPath);

    //    var summary = new
    //    {
    //        exitCode = rc,
    //        inputPath,
    //        outputPath,
    //        artifacts = state.Artifacts.Keys.OrderBy(k => k).ToArray(),
    //        views = state.Views.Keys.OrderBy(k => k).ToArray()
    //    };
    //    return JsonSerializer.Serialize(summary, _jsonOptions);
    //}

    //[McpServerTool, System.ComponentModel.Description("List current artifacts produced by the last compileContext call (names + absolute paths).")]
    //public static string ListArtifacts(IServiceProvider services)
    //{
    //    WorkspaceState state = services.GetRequiredService<WorkspaceState>();
    //    return JsonSerializer.Serialize(state.Artifacts, _jsonOptions);
    //}

    [McpServerTool, System.ComponentModel.Description("Read an artifact content by name (e.g. prompt.context.md). Prefer resources/read via ctxc://artifact/<name> for large content.")]
    public static string ReadArtifact(IServiceProvider services, string name)
    {
        IOutputArtifactReader reader = services.GetRequiredService<IOutputArtifactReader>();
        return reader.ReadAllText(name, CancellationToken.None).GetAwaiter().GetResult();
    }

    [McpServerTool, System.ComponentModel.Description("List current views produced by the last compileContext call (ids).")]
    public static string ListViews(IServiceProvider services)
    {
        IWorkspace workspace = services.GetRequiredService<IWorkspaceAccessor>().Current;
        return JsonSerializer.Serialize(workspace.Views.Select(x => new
        {
            id = x.Name,
            description = x.Description
        }).ToArray(), _jsonOptions);
    }

    [McpServerTool, System.ComponentModel.Description("Describe a view (title, fragments count, ...).")]
    public static string DescribeView(IServiceProvider services, string name)
    {
        IWorkspace workspace = services.GetRequiredService<IWorkspaceAccessor>().Current;

        IWorkspaceView? view = workspace.Views.FirstOrDefault(x => x.Name == name || x.Name == $"{name}.index") ?? throw new InvalidOperationException($"View not found: {name}");
        IEnumerable<IViewDescriberModule> viewDescriberModules = services.GetServices<IViewDescriberModule>();
        IViewDescriberModule? viewDescriberModule = viewDescriberModules.FirstOrDefault(m => m.CanProcess(view, null));

        return viewDescriberModule == null
            ? throw new InvalidOperationException($"No view describer module found for view: {name}")
            : JsonSerializer.Serialize(viewDescriberModule.Describe(view, null).Result, _jsonOptions);
    }
}
