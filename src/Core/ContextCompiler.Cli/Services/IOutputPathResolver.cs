namespace ContextCompiler.Cli.Services;

internal interface IOutputPathResolver
{
    string Resolve(string inputPath, string contextName);
}
