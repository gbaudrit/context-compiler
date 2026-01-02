using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Services
{
    internal sealed class OutputPathResolver(ILogger<OutputPathResolver> logger) : IOutputPathResolver
    {

        public string Resolve(string inputPath)
        {
            string parentPath = Directory.GetParent(inputPath.TrimEnd('\\'))?.FullName ?? "";
            if (string.IsNullOrEmpty(parentPath))
            {
                parentPath = Path.GetDirectoryName(inputPath) ?? ".";
            }
            string resolved = Path.Combine(parentPath, "ctxc");

            logger.LogInformation("Resolved output path '{OutputPath}' from input path '{InputPath}'", resolved, inputPath);
            return resolved;
        }

    }
}
