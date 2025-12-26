using System.CommandLine;
using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Host.Cli;

public static class CliCommandFactory
{
    public static RootCommand Create(IServiceProvider sp)
    {
        var root = new RootCommand("Context Compiler CLI (ctxc)");

        // compile
        var compile = new Command("compile", "Compile context into reasoning artifacts");
        var inputOpt = new Option<string>("--input") { IsRequired = true };
        var outputOpt = new Option<string>("--output") { IsRequired = true };
        var maxChars = new Option<int>("--max-chars", () => 1_000_000, "Maximum characters in prompt.context.md");
        var viewsOpt = new Option<string?>("--views", description: "Comma-separated view ids (future hook)");
        var noGuards = new Option<bool>("--no-guards", description: "Disable non-critical guards (debug)");
        var configOpt = new Option<string?>("--config", description: "Config file path");
        var jsonOpt = new Option<bool>("--json", description: "Emit summary JSON");
        compile.AddOption(inputOpt);
        compile.AddOption(outputOpt);
        compile.AddOption(maxChars);
        compile.AddOption(viewsOpt);
        compile.AddOption(noGuards);
        compile.AddOption(configOpt);
        compile.AddOption(jsonOpt);
        compile.SetHandler(async (input, output, max, views, disableNonCritical, config, json) =>
        {
            var handler = sp.GetRequiredService<Handlers.ICtxcCompileHandler>();
            Environment.ExitCode = await handler.HandleAsync(input, output, max, views, disableNonCritical, config, json);
        }, inputOpt, outputOpt, maxChars, viewsOpt, noGuards, configOpt, jsonOpt);
        root.AddCommand(compile);

        // diff
        var diff = new Command("diff", "Compare two output folders");
        var leftOpt = new Option<string>("--left") { IsRequired = true };
        var rightOpt = new Option<string>("--right") { IsRequired = true };
        var formatOpt = new Option<string>("--format", () => "md", "Output format md|json");
        var outOpt = new Option<string?>("--out", description: "Output file path");
        diff.AddOption(leftOpt);
        diff.AddOption(rightOpt);
        diff.AddOption(formatOpt);
        diff.AddOption(outOpt);
        diff.SetHandler(async (left, right, format, outFile) =>
        {
            var handler = sp.GetRequiredService<Handlers.ICtxcDiffHandler>();
            Environment.ExitCode = await handler.HandleAsync(left, right, format, outFile);
        }, leftOpt, rightOpt, formatOpt, outOpt);
        root.AddCommand(diff);

        // explain
        var explain = new Command("explain", "Explain compilation outputs");
        var exInput = new Option<string>("--input") { IsRequired = true };
        var exOut = new Option<string?>("--out", description: "Output file");
        var exFormat = new Option<string>("--format", () => "md", "md|json");
        explain.AddOption(exInput);
        explain.AddOption(exOut);
        explain.AddOption(exFormat);
        explain.SetHandler(async (input, outFile, format) =>
        {
            var handler = sp.GetRequiredService<Handlers.ICtxcExplainHandler>();
            Environment.ExitCode = await handler.HandleAsync(input, outFile, format);
        }, exInput, exOut, exFormat);
        root.AddCommand(explain);

        // health
        var health = new Command("health", "Compute or display health metrics");
        var hInput = new Option<string>("--input") { IsRequired = true };
        var hFormat = new Option<string>("--format", () => "text", "text|json");
        var hFailBelow = new Option<int?>("--fail-below", description: "Fail if score below threshold");
        health.AddOption(hInput);
        health.AddOption(hFormat);
        health.AddOption(hFailBelow);
        health.SetHandler(async (input, format, failBelow) =>
        {
            var handler = sp.GetRequiredService<Handlers.ICtxcHealthHandler>();
            Environment.ExitCode = await handler.HandleAsync(input, format, failBelow);
        }, hInput, hFormat, hFailBelow);
        root.AddCommand(health);

        // views group
        var views = new Command("views", "Views commands");
        var viewsList = new Command("list", "List available views");
        var vlInput = new Option<string>("--input") { IsRequired = true };
        var vlJson = new Option<bool>("--json");
        viewsList.AddOption(vlInput);
        viewsList.AddOption(vlJson);
        viewsList.SetHandler(async (input, json) =>
        {
            var handler = sp.GetRequiredService<Handlers.ICtxcViewsListHandler>();
            Environment.ExitCode = await handler.HandleAsync(input, json);
        }, vlInput, vlJson);

        var viewsRender = new Command("render", "Render a view explicitly");
        var vrId = new Option<string>("--id") { IsRequired = true };
        var vrInput = new Option<string>("--input") { IsRequired = true };
        var vrOut = new Option<string?>("--out");
        viewsRender.AddOption(vrId);
        viewsRender.AddOption(vrInput);
        viewsRender.AddOption(vrOut);
        viewsRender.SetHandler(async (id, input, outFile) =>
        {
            var handler = sp.GetRequiredService<Handlers.ICtxcViewsRenderHandler>();
            Environment.ExitCode = await handler.HandleAsync(id, input, outFile);
        }, vrId, vrInput, vrOut);

        views.AddCommand(viewsList);
        views.AddCommand(viewsRender);
        root.AddCommand(views);

        // guards group
        var guards = new Command("guards", "Guards commands");
        var guardsReport = new Command("report", "Output guards report");
        var grInput = new Option<string>("--input") { IsRequired = true };
        var grFormat = new Option<string>("--format", () => "md", "md|json");
        var grOut = new Option<string?>("--out");
        guardsReport.AddOption(grInput);
        guardsReport.AddOption(grFormat);
        guardsReport.AddOption(grOut);
        guardsReport.SetHandler(async (input, format, outFile) =>
        {
            var handler = sp.GetRequiredService<Handlers.ICtxcGuardsReportHandler>();
            Environment.ExitCode = await handler.HandleAsync(input, format, outFile);
        }, grInput, grFormat, grOut);
        guards.AddCommand(guardsReport);
        root.AddCommand(guards);

        // plugins group (stubs phase 1)
        var plugins = new Command("plugins", "Plugins management");
        var pluginsList = new Command("list", "List loaded plugins");
        var plJson = new Option<bool>("--json");
        pluginsList.AddOption(plJson);
        pluginsList.SetHandler(async (json) =>
        {
            var handler = sp.GetRequiredService<Handlers.ICtxcPluginsListHandler>();
            Environment.ExitCode = await handler.HandleAsync(json);
        }, plJson);

        var pluginsAdd = new Command("add", "Install plugin (stub)");
        var paId = new Argument<string>("packageId");
        var paVer = new Option<string?>("--version");
        var paSrc = new Option<string?>("--source");
        pluginsAdd.AddArgument(paId);
        pluginsAdd.AddOption(paVer);
        pluginsAdd.AddOption(paSrc);
        pluginsAdd.SetHandler(async (packageId, version, source) =>
        {
            var handler = sp.GetRequiredService<Handlers.ICtxcPluginsAddHandler>();
            Environment.ExitCode = await handler.HandleAsync(packageId, version, source);
        }, paId, paVer, paSrc);

        var pluginsRemove = new Command("remove", "Uninstall plugin (stub)");
        var prId = new Argument<string>("packageId");
        pluginsRemove.AddArgument(prId);
        pluginsRemove.SetHandler(async (packageId) =>
        {
            var handler = sp.GetRequiredService<Handlers.ICtxcPluginsRemoveHandler>();
            Environment.ExitCode = await handler.HandleAsync(packageId);
        }, prId);

        plugins.AddCommand(pluginsList);
        plugins.AddCommand(pluginsAdd);
        plugins.AddCommand(pluginsRemove);
        root.AddCommand(plugins);

        // graph group
        var graph = new Command("graph", "Graph commands");
        var graphExport = new Command("export", "Export reasoning graph");
        var giInput = new Option<string>("--input") { IsRequired = true };
        var giFormat = new Option<string>("--format") { IsRequired = true };
        var giOut = new Option<string?>("--out");
        graphExport.AddOption(giInput);
        graphExport.AddOption(giFormat);
        graphExport.AddOption(giOut);
        graphExport.SetHandler(async (input, format, outFile) =>
        {
            var handler = sp.GetRequiredService<Handlers.ICtxcGraphExportHandler>();
            Environment.ExitCode = await handler.HandleAsync(input, format, outFile);
        }, giInput, giFormat, giOut);
        graph.AddCommand(graphExport);
        root.AddCommand(graph);

        return root;
    }
}
