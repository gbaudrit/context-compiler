using ContextCompiler.Abstractions.Pipelines.Document;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class BeginProcessDocumentPass(ILogger<BeginProcessDocumentPass> logger) : IDocumentPass
    {
        public string Id => "pass.beginprocess";
        public int Priority => 200;
        public DocumentStage Stage => DocumentStage.StartProcess;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
        {
            logger.LogInformation("Beginning processing of document: {DocumentPath}", ctx.FullPath);

            await Task.CompletedTask;
        }
    }
}
