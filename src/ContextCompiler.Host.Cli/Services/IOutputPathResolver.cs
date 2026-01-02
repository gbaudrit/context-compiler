namespace ContextCompiler.Host.Cli.Services;

internal interface IOutputPathResolver
{
    string Resolve(string inputPath);
}
