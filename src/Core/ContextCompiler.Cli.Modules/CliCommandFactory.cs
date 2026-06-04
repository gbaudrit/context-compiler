using System.CommandLine;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Cli.Modules;

public static class CliCommandFactory
{
    /// <summary>
    /// Builds the <c>modules</c> top-level command tree to be attached to the unified CLI root.
    /// </summary>
    public static Command BuildModulesCommand(IServiceProvider sp)
    {
        Command modulesRoot = new("modules", "Manage Context Compiler modules and skills.");

        Option<string> configOpt = new("--config", () => ".", "Path to ctxc.config.json");
        Option<bool> forceOpt = new("--force", () => false, "Force operation");
        Option<bool> cleanOpt = new("--clean", () => false, "Clean operation");
        Option<bool> devToolsOpt = new("--dev-tools", () => false, "Add Dev tools modules");
        Option<bool> debugOpt = new("--debug", () => false, "Enable debug");

        Command restore = new("restore", "Restore modules from NuGet and generate/update lock file.") { configOpt, forceOpt, cleanOpt, devToolsOpt, debugOpt };
        restore.SetHandler(async (debug, cfgFile, force, clean, devTools) =>
        {
            Handlers.IRestoreHandler handler = sp.GetRequiredService<Handlers.IRestoreHandler>();

            Dictionary<string, string> runModules = [];
            if (devTools)
            {
                runModules["ContextCompiler.Modules.DevTools.SourcesConsole@locale"] = "0.1.0-alpha.1";
            }

            Environment.ExitCode = await handler.HandleAsync(debug, cfgFile, force, clean, runModules.AsReadOnly());
        }, debugOpt, configOpt, forceOpt, cleanOpt, devToolsOpt);

        Command verify = new("verify", "Verify lock file and cached packages integrity (sha256).") { configOpt };
        verify.SetHandler(async cfgFile =>
        {
            Handlers.IVerifyHandler handler = sp.GetRequiredService<Handlers.IVerifyHandler>();
            Environment.ExitCode = await handler.HandleAsync(cfgFile);
        }, configOpt);

        Command list = new("list", "List installed modules in the immutable cache.") { configOpt };
        list.SetHandler(async cfgFile =>
        {
            Handlers.IListHandler handler = sp.GetRequiredService<Handlers.IListHandler>();
            Environment.ExitCode = await handler.HandleAsync(cfgFile);
        }, configOpt);

        Option<bool> purgeKeep = new("--keep-locked", () => true, "Keep lockfile-pinned modules versions.");
        Command purge = new("purge", "Purge modules cache (optionally keep lockfile pinned versions).") { configOpt, purgeKeep };
        purge.SetHandler(async (cfgFile, keepLocked) =>
        {
            Handlers.IPurgeHandler handler = sp.GetRequiredService<Handlers.IPurgeHandler>();
            Environment.ExitCode = await handler.HandleAsync(cfgFile, keepLocked);
        }, configOpt, purgeKeep);

        Command plan = new("plan", "Create a deterministic modules installation plan.") { configOpt };
        plan.SetHandler(async cfgFile =>
        {
            Handlers.IModulesPlanHandler handler = sp.GetRequiredService<Handlers.IModulesPlanHandler>();
            Environment.ExitCode = await handler.HandleAsync(cfgFile);
        }, configOpt);

        Command schemas = new("schemas", ".") { configOpt };
        Command schemasAggregate = new("aggregate", ".") { configOpt };
        Argument<string> schema1Arg = new("schema1");
        Argument<string> schemasToAggregateArgs = new("schema2");
        Option<string> outputOpt = new("--output");
        schemasAggregate.AddArgument(schema1Arg);
        schemasAggregate.AddArgument(schemasToAggregateArgs);
        schemasAggregate.AddOption(outputOpt);

        schemas.AddCommand(schemasAggregate);
        schemasAggregate.SetHandler(async (schema1, schemasToAggregate, outputPath) =>
        {
            Handlers.ISchemasAggregateHandler handler = sp.GetRequiredService<Handlers.ISchemasAggregateHandler>();
            Environment.ExitCode = await handler.HandleAsync(schema1, schemasToAggregate.Split(','), outputPath);
        }, schema1Arg, schemasToAggregateArgs, outputOpt);

        modulesRoot.AddCommand(restore);
        modulesRoot.AddCommand(verify);
        modulesRoot.AddCommand(list);
        modulesRoot.AddCommand(purge);
        modulesRoot.AddCommand(plan);
        modulesRoot.AddCommand(schemas);

        return modulesRoot;
    }
}

