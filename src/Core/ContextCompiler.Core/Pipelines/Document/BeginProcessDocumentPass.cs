//using ContextCompiler.Abstractions.Pipelines.Document;

//using Microsoft.Extensions.Logging;

//namespace ContextCompiler.Core.Pipelines.Document
//{
//    internal sealed class BeginProcessDocumentPass(ILogger<BeginProcessDocumentPass> logger) : IDocumentPass
//    {
//        public DocumentPassMetadata Metadata => IDocumentPass.Meta(
//            "pass.beginprocess",
//            DocumentPipelineModuleKinds.BeginProcess,
//            DocumentStage.StartProcess,
//            priority: 200);

//        public ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
//        {
//            logger.LogInformation("Beginning processing of document: {DocumentPath}", ctx.FullPath);
//            return ValueTask.CompletedTask;
//        }
//    }
//}
