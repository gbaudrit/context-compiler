namespace ContextCompiler.Cli.Modules.Handlers;

public interface IRestoreHandler
{
    Task<int> HandleAsync(string cfgFile, bool force, bool clean, IReadOnlyDictionary<string, string> runModules, CancellationToken cancellationToken, string scope = "all");
}
