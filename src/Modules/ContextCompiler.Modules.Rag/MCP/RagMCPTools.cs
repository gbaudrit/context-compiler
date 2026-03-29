using System.Text.Json;

using ContextCompiler.Modules.Abstractions.MCP;
using ContextCompiler.Modules.Rag.Abstractions;

//using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Rag.MCP;

[McpServerToolType]
public class RagMCPTools(ISemanticSearchService semanticSearchService)
{
    private static readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web) { WriteIndented = true };

    [McpServerTool, System.ComponentModel.Description("RAG search on evidence content.")]
    public async Task<string> RagSearch(string query, int maxResults = 5, float minSimilarity = 0.15f)
    {
        //ISemanticSearchService semanticSearchService = services.GetRequiredService<ISemanticSearchService>();
        return JsonSerializer.Serialize(await semanticSearchService.SearchAsync(query, maxResults, minSimilarity), _jsonOptions);
    }

    //[McpServerTool, System.ComponentModel.Description("Read an artifact content by name (e.g. prompt.context.md). Prefer resources/read via ctxc://artifact/<name> for large content.")]
    //public static string ReadArtifact(IServiceProvider services, string name)
    //{h
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
