using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Services
{
    internal sealed class OutputPathResolver(ILogger<OutputPathResolver> logger) : IOutputPathResolver
    {

        public string Resolve(string inputPath, string contextName)
        {
            string hidden = Path.Combine(inputPath, ".ctxc");
            string compiled = Path.Combine(hidden, $"{(string.IsNullOrEmpty(contextName) ? "" : contextName + ".")}compiled");
            logger.LogInformation("Resolved output path '{OutputPath}' from input path '{InputPath}' and context name '{ContextName}'", compiled, inputPath, contextName);
            return compiled;
        }

    }
}
