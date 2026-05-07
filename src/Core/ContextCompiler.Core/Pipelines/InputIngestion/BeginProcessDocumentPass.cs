//using ContextCompiler.Abstractions.Pipelines.InputIngestion;

//using Microsoft.Extensions.Logging;

//namespace ContextCompiler.Core.Pipelines.InputIngestion
//{
//    internal sealed class BeginProcessDocumentPass(ILogger<BeginProcessDocumentPass> logger) : IDocumentPass
//    {
//        public InputIngestionPassMetadata Metadata => IDocumentPass.Meta(
//            "pass.beginprocess",
//            InputIngestionPipelineModuleKinds.BeginProcess,
//            DocumentStage.StartProcess,
//            priority: 200);

//        public ValueTask ExecuteAsync(IInputItemContext ctx, CancellationToken ct)
//        {
//            logger.LogInformation("Beginning processing of document: {DocumentPath}", ctx.FullPath);
//            return ValueTask.CompletedTask;
//        }
//    }
//}
