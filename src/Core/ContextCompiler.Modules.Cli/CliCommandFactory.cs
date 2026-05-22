using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Cli;

public static class CliCommandFactory
{

    private static Option<string>? _inputOpt;
    private static Option<bool>? _debugOpt;

    [MemberNotNull(nameof(_inputOpt), nameof(_debugOpt))]
    private static RootCommand CreateRootCommand()
    {
#pragma warning disable IDE0028 // Simplify collection initialization
        RootCommand root = new("Context Compiler modules CLI (ctxc-modules)");
#pragma warning restore IDE0028 // Simplify collection initialization
        _inputOpt = new("--input", () => { return Environment.CurrentDirectory; });
        root.AddGlobalOption(_inputOpt);
        _debugOpt = new("--debug") { IsRequired = false };
        root.AddGlobalOption(_debugOpt);
        return root;
    }

    internal static GlobalCommandLineOptions ParseGlobals(string[] args)
    {
        //_ = Debugger.Launch();
        //Debugger.Break();

        RootCommand root = CreateRootCommand();
        ParseResult result = root.Parse(args);
        return new GlobalCommandLineOptions
        {
            InputPath = result.GetValueForOption(_inputOpt) ?? "",
            Debug = result.GetValueForOption(_debugOpt)
        };
    }

    public static RootCommand Create(IServiceProvider sp)
    {
        RootCommand root = CreateRootCommand();

        Option<string> configOpt = new("--config", () => ".", "Path to ctxc.config.json");
        Option<bool> forceOpt = new("--force", () => false, "Force operation");
        Option<bool> cleanOpt = new("--clean", () => false, "Clean operation");
        Option<bool> devToolsOpt = new("--dev-tools", () => false, "Add Dev tools modules");

        Command restore = new("restore", "Restore modules from NuGet and generate/update lock file.") { configOpt, forceOpt, cleanOpt, devToolsOpt };
        restore.SetHandler(async (debug, cfgFile, force, clean, devTools) =>
        {
            Handlers.IRestoreHandler handler = sp.GetRequiredService<Handlers.IRestoreHandler>();

            Dictionary<string, string> runModules = [];
            if (devTools)
            {
                runModules["ContextCompiler.Modules.DevTools.SourcesConsole@locale"] = "0.1.0-alpha.1";
            }

            Environment.ExitCode = await handler.HandleAsync(debug, cfgFile, force, clean, runModules.AsReadOnly());
        }, _debugOpt, configOpt, forceOpt, cleanOpt, devToolsOpt);

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

        Command skills = new("skills", "Plan and inspect declarative skills.");
        Command skillsPlan = new("plan", "Create a deterministic skills installation plan.") { configOpt };
        skillsPlan.SetHandler(async cfgFile =>
        {
            Handlers.ISkillsPlanHandler handler = sp.GetRequiredService<Handlers.ISkillsPlanHandler>();
            Environment.ExitCode = await handler.HandleAsync(cfgFile);
        }, configOpt);
        skills.AddCommand(skillsPlan);

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

        root.AddCommand(restore);
        root.AddCommand(verify);
        root.AddCommand(list);
        root.AddCommand(purge);
        root.AddCommand(skills);
        root.AddCommand(schemas);

        return root;
    }
}
