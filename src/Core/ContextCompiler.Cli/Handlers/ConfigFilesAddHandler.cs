using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Handlers;

internal sealed class ConfigFilesAddHandler(IConfigSerializer ctxcConfigSerializer, ILogger<ConfigFilesAddHandler> logger) : ICtxcConfigFilesAddHandler
{

    public Task<int> HandleAsync(string path, string relativePath)
    {
        try
        {
            string configPath = Path.Combine(string.IsNullOrWhiteSpace(path) ? "." : path, "ctxc.config.json");
            if (!File.Exists(configPath))
            {
                logger.LogError("No ctxc.config.json found at {ConfigPath}", configPath);
                return Task.FromResult(1);
            }

            if (!IsSafeRelativePath(relativePath))
            {
                logger.LogError("Invalid relative path: {RelativePath}", relativePath);
                return Task.FromResult(1);
            }

            string json = File.ReadAllText(configPath);
            IRootConfigSection cfg = ctxcConfigSerializer.Deserialize(json);

            string normalized = NormalizeRelativePath(relativePath);

            bool exists = cfg.Sources.Any(f =>
                f.Includes.Length == 1 &&
                string.Equals(NormalizeRelativePath(f.Includes[0]), normalized, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                logger.LogInformation("Already present in config: {RelativePath}", normalized);
                return Task.FromResult(0);
            }

            cfg.AddFile([normalized],
                        [],
                        [],
                        [],
                        null);

            //cfg.Files =
            //[
            //    .. cfg.Files.OrderBy(
            //        f => f.Includes is { Length: > 0 } ? NormalizeRelativePath(f.Includes[0]) : string.Empty,
            //        StringComparer.OrdinalIgnoreCase)
            //];

            string outJson = ctxcConfigSerializer.Serialize(cfg);
            File.WriteAllText(configPath, outJson);

            logger.LogInformation("Added file include: {RelativePath}", normalized);
            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return Task.FromResult(1);
        }
    }

    private static string NormalizeRelativePath(string path)
    {
        return path.Replace('\\', '/').Trim();
    }

    private static bool IsSafeRelativePath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return false;
        }

        string p = path.Trim();
        if (Path.IsPathRooted(p))
        {
            return false;
        }

        if (p.StartsWith("~/", StringComparison.Ordinal) || p.StartsWith("~\\", StringComparison.Ordinal))
        {
            return false;
        }

        string normalized = p.Replace('\\', '/');
        return !(normalized.StartsWith("../", StringComparison.Ordinal)
                 || normalized.Contains("/../", StringComparison.Ordinal)
                 || normalized.EndsWith("/..", StringComparison.Ordinal));
    }
}
