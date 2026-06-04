using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Core.Engine;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Handlers;

public record CtxcPrepareCommandLine(
    string Input,
    string? Goal,
    string? Description);

internal sealed class CtxcPrepareHandler(
    IPrepareEngine engine,
    ILogger<CtxcPrepareHandler> logger) : ICtxcPrepareHandler
{
    public async Task<int> HandleAsync(CtxcPrepareCommandLine commandLine)
    {
        try
        {
            if (!Uri.TryCreate(commandLine.Input, UriKind.Absolute, out Uri? sourceUri) || !sourceUri.IsFile)
            {
                string absolute = Path.GetFullPath(commandLine.Input);
                sourceUri = new Uri(absolute, UriKind.Absolute);
            }

            PrepareRequest request = new()
            {
                SourceUri = sourceUri,
                Goal = commandLine.Goal,
                Description = commandLine.Description,
            };

            int rc = await engine.PrepareAsync(request, CancellationToken.None);
            logger.LogInformation("Prepared {Source} (rc={Rc})", request.SourceUri, rc);
            return rc;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
