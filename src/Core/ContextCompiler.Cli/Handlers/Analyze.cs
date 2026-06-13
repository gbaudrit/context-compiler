using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Core.Engine;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Handlers;

public record CtxcAnalyzeCommandLine(
    string Input,
    string? Goal,
    string? Description);

internal sealed class CtxcAnalyzeHandler(
    IAnalyzeEngine engine,
    ILogger<CtxcAnalyzeHandler> logger) : ICtxcAnalyzeHandler
{
    public async Task<int> HandleAsync(CtxcAnalyzeCommandLine commandLine)
    {
        try
        {
            if (!Uri.TryCreate(commandLine.Input, UriKind.Absolute, out Uri? sourceUri) || !sourceUri.IsFile)
            {
                string absolute = Path.GetFullPath(commandLine.Input);
                sourceUri = new Uri(absolute, UriKind.Absolute);
            }

            AnalyzeRequest request = new()
            {
                SourceUri = sourceUri,
                Goal = commandLine.Goal,
                Description = commandLine.Description,
            };

            int rc = await engine.AnalyzeAsync(request, CancellationToken.None);
            logger.LogInformation("Analyzed {Source} (rc={Rc})", request.SourceUri, rc);
            return rc;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
