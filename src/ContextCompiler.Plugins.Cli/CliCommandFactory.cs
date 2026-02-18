using System.CommandLine;
using System.CommandLine.Parsing;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Plugins.Cli;

public static class CliCommandFactory
{
    internal static GlobalCommandLineOptions ParseGlobals(string[] args)
    {
        //_ = Debugger.Launch();
        //Debugger.Break();

        RootCommand root = new("Context Compiler CLI (ctxc)");
        Option<string> inputOpt = new("--input", () => { return Environment.CurrentDirectory; });
        root.AddGlobalOption(inputOpt);
        Option<bool> debugOpt = new("--debug") { IsRequired = false };
        root.AddGlobalOption(debugOpt);
        ParseResult result = root.Parse(args);
        return new GlobalCommandLineOptions
        {
            InputPath = result.GetValueForOption(inputOpt) ?? "",
            Debug = result.GetValueForOption(debugOpt)
        };
    }

    public static RootCommand Create(IServiceProvider sp)
    {
        RootCommand root = new("Context Compiler CLI (ctxc)");
        Option<bool> debugOpt = new(
            aliases: ["--debug", "-d"],
            description: "Enable debug"
        );
        root.AddGlobalOption(debugOpt);


        Option<string> configOpt = new("--config", () => ".", "Path to ctxc.config.json");

        Command restore = new("restore", "Restore plugins from NuGet and generate/update lock file.") { configOpt };
        restore.SetHandler(async (debug, cfgFile) =>
        {
            Handlers.IRestoreHandler handler = sp.GetRequiredService<Handlers.IRestoreHandler>();
            Environment.ExitCode = await handler.HandleAsync(debug, cfgFile);
        }, debugOpt, configOpt);

        Command verify = new("verify", "Verify lock file and cached packages integrity (sha256).") { configOpt };
        verify.SetHandler(async cfgFile =>
        {
            Handlers.IVerifyHandler handler = sp.GetRequiredService<Handlers.IVerifyHandler>();
            Environment.ExitCode = await handler.HandleAsync(cfgFile);
        }, configOpt);

        Command list = new("list", "List installed plugins in the immutable cache.") { configOpt };
        list.SetHandler(async cfgFile =>
        {
            Handlers.IListHandler handler = sp.GetRequiredService<Handlers.IListHandler>();
            Environment.ExitCode = await handler.HandleAsync(cfgFile);
        }, configOpt);

        Option<bool> purgeKeep = new("--keep-locked", () => true, "Keep lockfile-pinned plugin versions.");
        Command purge = new("purge", "Purge plugin cache (optionally keep lockfile pinned versions).") { configOpt, purgeKeep };
        purge.SetHandler(async (cfgFile, keepLocked) =>
        {
            Handlers.IPurgeHandler handler = sp.GetRequiredService<Handlers.IPurgeHandler>();
            Environment.ExitCode = await handler.HandleAsync(cfgFile, keepLocked);
        }, configOpt, purgeKeep);

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
        root.AddCommand(schemas);

        return root;
    }
}
