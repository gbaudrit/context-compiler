using System.CommandLine;
using System.CommandLine.Parsing;
namespace ContextCompiler.Host.Mcp;

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
            InputPath = result.GetValueForOption(inputOpt) ?? Environment.CurrentDirectory,
            Debug = result.GetValueForOption(debugOpt)
        };
    }
}
