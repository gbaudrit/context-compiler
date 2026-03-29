using ContextCompiler.Abstractions.Pipelines.Document;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class EndProcessDocumentPass(ILogger<EndProcessDocumentPass> logger) : IDocumentPass
    {
        public string Id => "pass.endprocess";
        public int Priority => 200;
        public DocumentStage Stage => DocumentStage.EndProcess;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
        {
            logger.LogInformation("Ending processing of document: {DocumentPath}", ctx.FullPath);
        }
    }
}
