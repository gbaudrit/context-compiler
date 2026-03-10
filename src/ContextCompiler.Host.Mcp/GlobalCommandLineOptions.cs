namespace ContextCompiler.Host.Mcp
{
    internal sealed record GlobalCommandLineOptions
    {
        public required string InputPath { get; init; }
        public required bool Debug { get; init; }
    }
}
