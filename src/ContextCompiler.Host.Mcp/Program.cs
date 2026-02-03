using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;

using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Core.Engine;
using ContextCompiler.Core.Pipelines;
using ContextCompiler.Infrastructure.FileSystem;
using ContextCompiler.Infrastructure.Hashing;
using ContextCompiler.Infrastructure.PluginLoading;
using ModelContextProtocol;

// Context Compiler MCP Server (stdio)
// Exposes:
// - tools: compile_context, list_artifacts, read_artifact, list_views
// - resources: ctxc://artifact/<name> , ctxc://view/<id>
// Designed for VS Code / Copilot MCP consumption.

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(o => o.LogToStandardErrorThreshold = LogLevel.Information);

var assemblies = new[]
{
    typeof(ContextCompiler.Core.Engine.CompilerEngine).Assembly,
    typeof(ContextCompiler.Infrastructure.FileSystem.PhysicalFileSystem).Assembly,
    typeof(ContextCompiler.Plugins.BuiltIn.BuiltInMetadata).Assembly
};

builder.Services
    .AddSingleton<IFileSystem, PhysicalFileSystem>()
    .AddSingleton<IHasher, DefaultHasher>()
    .AddSingleton<IPluginRegistry>(PluginRegistryBuilder.FromAssemblies(assemblies))
    .AddSingleton<ICompilerEngine, CompilerEngine>()
    .AddSingleton<WorkspaceState>();

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly()
    .WithListResourcesHandler((ctx, ct) =>
    {
        var state = ctx.Services.GetRequiredService<WorkspaceState>();
        var resources = new List<Resource>();
        foreach (var kv in state.Artifacts)
        {
            resources.Add(new Resource
            {
                Name = kv.Key,
                Description = "Context Compiler artifact",
                MimeType = GuessMime(kv.Key),
                Uri = $"ctxc://artifact/{kv.Key}"
            });
        }

        foreach (var v in state.Views)
        {
            resources.Add(new Resource
            {
                Name = $"view.{v.Key}",
                Description = "Context Compiler view",
                MimeType = "text/markdown",
                Uri = $"ctxc://view/{v.Key}"
            });
        }

        return ValueTask.FromResult(new ListResourcesResult { Resources = resources });
    })
    .WithReadResourceHandler((ctx, ct) =>
    {
        var state = ctx.Services.GetRequiredService<WorkspaceState>();
        var uri = ctx.Params?.Uri;
        if (string.IsNullOrWhiteSpace(uri))
            throw new McpException(new McpError { Code = -32602, Message = "Missing uri" });

        if (uri.StartsWith("ctxc://artifact/", StringComparison.OrdinalIgnoreCase))
        {
            var name = uri["ctxc://artifact/".Length..];
            if (!state.Artifacts.TryGetValue(name, out var path) || !File.Exists(path))
                throw new McpException(new McpError { Code = -32004, Message = $"Artifact not found: {name}" });

            var text = File.ReadAllText(path);
            return Task.FromResult(new ReadResourceResult
            {
                Contents =
                [
                    new ResourceContents
                    {
                        Uri = uri,
                        MimeType = GuessMime(name),
                        Text = text
                    }
                ]
            });
        }

        if (uri.StartsWith("ctxc://view/", StringComparison.OrdinalIgnoreCase))
        {
            var id = uri["ctxc://view/".Length..];
            if (!state.Views.TryGetValue(id, out var md))
                throw new McpException(new McpError { Code = -32004, Message = $"View not found: {id}" });

            return Task.FromResult(new ReadResourceResult
            {
                Contents =
                [
                    new ResourceContents
                    {
                        Uri = uri,
                        MimeType = "text/markdown",
                        Text = md
                    }
                ]
            });
        }

        throw new McpException(new McpError { Code = -32601, Message = $"Unsupported uri scheme: {uri}" });
    });

await builder.Build().RunAsync();

static string GuessMime(string name)
{
    var ext = Path.GetExtension(name).ToLowerInvariant();
    return ext switch
    {
        ".md" => "text/markdown",
        ".json" => "application/json",
        ".dot" => "text/vnd.graphviz",
        ".txt" => "text/plain",
        _ => "text/plain"
    };
}

[McpServerToolType]
public static class ContextCompilerTools
{
    [McpServerTool, System.ComponentModel.Description("Compile a folder into Context Compiler artifacts (prompt, evidence index, graph, views). Returns a summary with output paths.")]
    public static async Task<string> CompileContext(
        IServiceProvider services,
        string inputPath,
        string outputPath,
        int maxChars = 120000)
    {
        var engine = services.GetRequiredService<ICompilerEngine>();
        var state = services.GetRequiredService<WorkspaceState>();

        Directory.CreateDirectory(outputPath);

        var rc = await engine.CompileAsync(
            new CompileRequest(inputPath, outputPath, new CompileOptions(MaxCharacters: maxChars)),
            CancellationToken.None);

        // Refresh state (for resources)
        state.LoadFromOutput(outputPath);

        var summary = new
        {
            exitCode = rc,
            inputPath,
            outputPath,
            artifacts = state.Artifacts.Keys.OrderBy(k => k).ToArray(),
            views = state.Views.Keys.OrderBy(k => k).ToArray()
        };
        return System.Text.Json.JsonSerializer.Serialize(summary, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
    }

    [McpServerTool, System.ComponentModel.Description("List current artifacts produced by the last compileContext call (names + absolute paths).")]
    public static string ListArtifacts(IServiceProvider services)
    {
        var state = services.GetRequiredService<WorkspaceState>();
        return System.Text.Json.JsonSerializer.Serialize(state.Artifacts, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
    }

    [McpServerTool, System.ComponentModel.Description("Read an artifact content by name (e.g. prompt.context.md). Prefer resources/read via ctxc://artifact/<name> for large content.")]
    public static string ReadArtifact(IServiceProvider services, string name)
    {
        var state = services.GetRequiredService<WorkspaceState>();
        if (!state.Artifacts.TryGetValue(name, out var path) || !File.Exists(path))
            throw new InvalidOperationException($"Artifact not found: {name}");
        return File.ReadAllText(path);
    }

    [McpServerTool, System.ComponentModel.Description("List current views produced by the last compileContext call (ids).")]
    public static string ListViews(IServiceProvider services)
    {
        var state = services.GetRequiredService<WorkspaceState>();
        return System.Text.Json.JsonSerializer.Serialize(state.Views.Keys.OrderBy(k => k).ToArray(), new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
    }
}

public sealed class WorkspaceState
{
    public Dictionary<string, string> Artifacts { get; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, string> Views { get; } = new(StringComparer.OrdinalIgnoreCase);

    public void LoadFromOutput(string outputPath)
    {
        Artifacts.Clear();
        Views.Clear();

        if (!Directory.Exists(outputPath)) return;

        foreach (var f in Directory.EnumerateFiles(outputPath))
        {
            var name = Path.GetFileName(f);
            Artifacts[name] = Path.GetFullPath(f);

            if (name.StartsWith("view.", StringComparison.OrdinalIgnoreCase) && name.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
            {
                var id = name["view.".Length..^".md".Length];
                Views[id] = File.ReadAllText(f);
            }
        }
    }
}
