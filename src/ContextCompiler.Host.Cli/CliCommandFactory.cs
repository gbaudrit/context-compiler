using System.CommandLine;

using ContextCompiler.Host.Cli.Handlers;
using ContextCompiler.Host.Cli.Services;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Host.Cli;

public static class CliCommandFactory
{
    public static RootCommand Create(IServiceProvider sp)
    {
        RootCommand root = new("Context Compiler CLI (ctxc)");
        Option<bool> debugOpt = new(
            aliases: ["--debug", "-d"],
            description: "Enable debug"
        );
        root.AddGlobalOption(debugOpt);

        // compile
        Command compile = new("compile", "Compile context into reasoning artifacts");
        Option<string> inputOpt = new("--input") { IsRequired = true };
        Option<string> outputOpt = new("--output");
        Option<string?> contextOpt = new("--context");
        Option<int> maxChars = new("--max-chars", () => 1_000_000, "Maximum characters in prompt.context.md");
        Option<string?> viewsOpt = new("--views", description: "Comma-separated view ids (future hook)");
        Option<bool?> noInlineViewsOpt = new("--no-inline-views", description: "Disable inline views");
        Option<bool?> noGuardsOpt = new("--no-guards", description: "Disable non-critical guards (debug)");
        Option<string?> configOpt = new("--config", description: "Config file path");
        Option<bool> jsonOpt = new("--json", description: "Emit summary JSON");
        Option<bool> cleanOpt = new("--clean", description: "Clean output directory");
        compile.AddOption(inputOpt);
        compile.AddOption(outputOpt);
        compile.AddOption(contextOpt);
        compile.AddOption(maxChars);
        compile.AddOption(viewsOpt);
        compile.AddOption(noInlineViewsOpt);
        compile.AddOption(noGuardsOpt);
        compile.AddOption(configOpt);
        compile.AddOption(jsonOpt);
        compile.AddOption(cleanOpt);
        compile.SetHandler(async context =>
        {
            bool debug = context.ParseResult.GetValueForOption(debugOpt);
            if (debug)
            {
                _ = System.Diagnostics.Debugger.Launch();
                System.Diagnostics.Debugger.Break();
            }

            string input = context.ParseResult.GetValueForOption(inputOpt) ?? ".";
            string name = context.ParseResult.GetValueForOption(contextOpt) ?? "";

            CtxcCompileCommandLine compileCommandLine = new(
                input,
                context.ParseResult.GetValueForOption(outputOpt) ?? sp.GetRequiredService<IOutputPathResolver>().Resolve(input, name),
                name,
                context.ParseResult.GetValueForOption(maxChars),
                context.ParseResult.GetValueForOption(viewsOpt),
                context.ParseResult.GetValueForOption(noInlineViewsOpt),
                context.ParseResult.GetValueForOption(noGuardsOpt),
                context.ParseResult.GetValueForOption(configOpt),
                context.ParseResult.GetValueForOption(jsonOpt),
                context.ParseResult.GetValueForOption(cleanOpt)
                );

            ICtxcCompileHandler handler = sp.GetRequiredService<ICtxcCompileHandler>();
            Environment.ExitCode = await handler.HandleAsync(compileCommandLine);
        });
        root.AddCommand(compile);

        // new
        Command newCommand = new("new", "Create new project");
        Option<string> pathOpt = new("--path", () => ".");
        newCommand.AddOption(outputOpt);
        newCommand.SetHandler(async (pathOpt) =>
        {
            ICtxcNewProjectHandler handler = sp.GetRequiredService<ICtxcNewProjectHandler>();
            Environment.ExitCode = await handler.HandleAsync(pathOpt);
        }, pathOpt);
        root.AddCommand(newCommand);

        // diff
        Command diff = new("diff", "Compare two output folders");
        Option<string> leftOpt = new("--left") { IsRequired = true };
        Option<string> rightOpt = new("--right") { IsRequired = true };
        Option<string> formatOpt = new("--format", () => "md", "Output format md|json");
        Option<string?> outOpt = new("--out", description: "Output file path");
        diff.AddOption(leftOpt);
        diff.AddOption(rightOpt);
        diff.AddOption(formatOpt);
        diff.AddOption(outOpt);
        diff.SetHandler(async (left, right, format, outFile) =>
        {
            ICtxcDiffHandler handler = sp.GetRequiredService<ICtxcDiffHandler>();
            Environment.ExitCode = await handler.HandleAsync(left, right, format, outFile);
        }, leftOpt, rightOpt, formatOpt, outOpt);
        root.AddCommand(diff);

        // explain
        Command explain = new("explain", "Explain compilation outputs");
        Option<string> exInput = new("--input") { IsRequired = true };
        Option<string?> exOut = new("--out", description: "Output file");
        Option<string> exFormat = new("--format", () => "md", "md|json");
        explain.AddOption(exInput);
        explain.AddOption(exOut);
        explain.AddOption(exFormat);
        explain.SetHandler(async (input, outFile, format) =>
        {
            ICtxcExplainHandler handler = sp.GetRequiredService<ICtxcExplainHandler>();
            Environment.ExitCode = await handler.HandleAsync(input, outFile, format);
        }, exInput, exOut, exFormat);
        root.AddCommand(explain);

        // health
        Command health = new("health", "Compute or display health metrics");
        Option<string> hInput = new("--input") { IsRequired = true };
        Option<string> hFormat = new("--format", () => "text", "text|json");
        Option<int?> hFailBelow = new("--fail-below", description: "Fail if score below threshold");
        health.AddOption(hInput);
        health.AddOption(hFormat);
        health.AddOption(hFailBelow);
        health.SetHandler(async (input, format, failBelow) =>
        {
            ICtxcHealthHandler handler = sp.GetRequiredService<ICtxcHealthHandler>();
            Environment.ExitCode = await handler.HandleAsync(input, format, failBelow);
        }, hInput, hFormat, hFailBelow);
        root.AddCommand(health);

        // views group
        Command views = new("views", "Views commands");
        Command viewsList = new("list", "List available views");
        Option<string> vlInput = new("--input") { IsRequired = true };
        Option<bool> vlJson = new("--json");
        viewsList.AddOption(vlInput);
        viewsList.AddOption(vlJson);
        viewsList.SetHandler(async (input, json) =>
        {
            ICtxcViewsListHandler handler = sp.GetRequiredService<ICtxcViewsListHandler>();
            Environment.ExitCode = await handler.HandleAsync(input, json);
        }, vlInput, vlJson);

        Command viewsRender = new("render", "Render a view explicitly");
        Option<string> vrId = new("--id") { IsRequired = true };
        Option<string> vrInput = new("--input") { IsRequired = true };
        Option<string?> vrOut = new("--out");
        viewsRender.AddOption(vrId);
        viewsRender.AddOption(vrInput);
        viewsRender.AddOption(vrOut);
        viewsRender.SetHandler(async (id, input, outFile) =>
        {
            ICtxcViewsRenderHandler handler = sp.GetRequiredService<ICtxcViewsRenderHandler>();
            Environment.ExitCode = await handler.HandleAsync(id, input, outFile);
        }, vrId, vrInput, vrOut);

        views.AddCommand(viewsList);
        views.AddCommand(viewsRender);
        root.AddCommand(views);

        // guards group
        Command guards = new("guards", "Guards commands");
        Command guardsReport = new("report", "Output guards report");
        Option<string> grInput = new("--input") { IsRequired = true };
        Option<string> grFormat = new("--format", () => "md", "md|json");
        Option<string?> grOut = new("--out");
        guardsReport.AddOption(grInput);
        guardsReport.AddOption(grFormat);
        guardsReport.AddOption(grOut);
        guardsReport.SetHandler(async (input, format, outFile) =>
        {
            ICtxcGuardsReportHandler handler = sp.GetRequiredService<ICtxcGuardsReportHandler>();
            Environment.ExitCode = await handler.HandleAsync(input, format, outFile);
        }, grInput, grFormat, grOut);
        guards.AddCommand(guardsReport);
        root.AddCommand(guards);

        // plugins group (stubs phase 1)
        Command plugins = new("plugins", "Plugins management");
        Command pluginsList = new("list", "List loaded plugins");
        Option<bool> plJson = new("--json");
        pluginsList.AddOption(plJson);
        pluginsList.SetHandler(async (json) =>
        {
            ICtxcPluginsListHandler handler = sp.GetRequiredService<ICtxcPluginsListHandler>();
            Environment.ExitCode = await handler.HandleAsync(json);
        }, plJson);

        Command pluginsAdd = new("add", "Install plugin (stub)");
        Argument<string> paId = new("packageId");
        Option<string?> paVer = new("--version");
        Option<string?> paSrc = new("--source");
        pluginsAdd.AddArgument(paId);
        pluginsAdd.AddOption(paVer);
        pluginsAdd.AddOption(paSrc);
        pluginsAdd.SetHandler(async (packageId, version, source) =>
        {
            ICtxcPluginsAddHandler handler = sp.GetRequiredService<ICtxcPluginsAddHandler>();
            Environment.ExitCode = await handler.HandleAsync(packageId, version, source);
        }, paId, paVer, paSrc);

        Command pluginsRemove = new("remove", "Uninstall plugin (stub)");
        Argument<string> prId = new("packageId");
        pluginsRemove.AddArgument(prId);
        pluginsRemove.SetHandler(async (packageId) =>
        {
            ICtxcPluginsRemoveHandler handler = sp.GetRequiredService<ICtxcPluginsRemoveHandler>();
            Environment.ExitCode = await handler.HandleAsync(packageId);
        }, prId);

        plugins.AddCommand(pluginsList);
        plugins.AddCommand(pluginsAdd);
        plugins.AddCommand(pluginsRemove);
        root.AddCommand(plugins);

        // graph group
        Command graph = new("graph", "Graph commands");
        Command graphExport = new("export", "Export reasoning graph");
        Option<string> giInput = new("--input") { IsRequired = true };
        Option<string> giFormat = new("--format") { IsRequired = true };
        Option<string?> giOut = new("--out");
        graphExport.AddOption(giInput);
        graphExport.AddOption(giFormat);
        graphExport.AddOption(giOut);
        graphExport.SetHandler(async (input, format, outFile) =>
        {
            ICtxcGraphExportHandler handler = sp.GetRequiredService<ICtxcGraphExportHandler>();
            Environment.ExitCode = await handler.HandleAsync(input, format, outFile);
        }, giInput, giFormat, giOut);
        graph.AddCommand(graphExport);
        root.AddCommand(graph);

        return root;
    }
}
