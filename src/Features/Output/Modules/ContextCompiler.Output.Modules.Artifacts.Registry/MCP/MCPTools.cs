using System.Text.Json;

using ContextCompiler.Output.Modules.Artifacts.Registry.Abstractions;
using ContextCompiler.Output.Modules.Artifacts.Registry.Models;

using Microsoft.Extensions.DependencyInjection;

using ModelContextProtocol.Server;

namespace ContextCompiler.Output.Modules.Artifacts.Registry.MCP;

[McpServerToolType]
public static class MCPTools
{
    private static readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web) { WriteIndented = true };

    [McpServerTool, System.ComponentModel.Description("List current artifacts produced by the last compileContext call (names + absolute paths).")]
    public static string ListArtifacts(IServiceProvider services)
    {
        IListArtifacts listArtifacts = services.GetRequiredService<IListArtifacts>();
        IReadOnlyList<Artifact> artifacts = listArtifacts.Execute(CancellationToken.None).Result;
        return JsonSerializer.Serialize(artifacts, _jsonOptions);
    }

    //[McpServerTool, System.ComponentModel.Description("Read an artifact content by name (e.g. prompt.context.md). Prefer resources/read via ctxc://artifact/<name> for large content.")]
    //public static string ReadArtifact(IServiceProvider services, string name)
    //{
    //    WorkspaceState state = services.GetRequiredService<WorkspaceState>();
    //    return !state.Artifacts.TryGetValue(name, out string? path) || !File.Exists(path)
    //        ? throw new InvalidOperationException($"Artifact not found: {name}")
    //        : File.ReadAllText(path);
    //}


    //[McpServerTool, System.ComponentModel.Description("Describe a view (title, fragments count, ...).")]
    //public static string DescribeView(IServiceProvider services, string name)
    //{
    //    IWorkspace workspace = services.GetRequiredService<IWorkspaceAccessor>().Current;

    //    IWorkspaceView? view = workspace.Views.FirstOrDefault(x => x.Name == name) ?? throw new InvalidOperationException($"View not found: {name}");
    //    IEnumerable<IViewDescriberModule> viewDescriberModules = services.GetServices<IViewDescriberModule>();
    //    IViewDescriberModule? viewDescriberModule = viewDescriberModules.FirstOrDefault(m => m.CanProcess(view, null));

    //    return viewDescriberModule == null
    //        ? throw new InvalidOperationException($"No view describer module found for view: {name}")
    //        : JsonSerializer.Serialize(viewDescriberModule.Describe(view, null), _jsonOptions);
    //}
}
