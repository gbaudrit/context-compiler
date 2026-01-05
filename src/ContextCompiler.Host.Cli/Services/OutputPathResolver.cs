using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Services
{
    internal sealed class OutputPathResolver(ILogger<OutputPathResolver> logger) : IOutputPathResolver
    {

        public string Resolve(string inputPath, string contextName)
        {
            var hidden = Path.Combine(inputPath, ".ctxc");
            var compiled = Path.Combine(hidden, $"{(string.IsNullOrEmpty(contextName) ? "" : contextName + ".")}compiled");
            logger.LogInformation("Resolved output path '{OutputPath}' from input path '{InputPath}' and context name '{ContextName}'", compiled, inputPath, contextName);
            return compiled;
        }

    }
}
