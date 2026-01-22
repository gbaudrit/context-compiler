using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.DataReaders;

public sealed class LinearDataReader(IDataEnvelopeBuilder dataEnvelopeBuilder, IDataPartBuilder dataPartBuilder, ILogger<LinearDataReader> logger) : IDataReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.data.linear", GlobalPipelinePluginKinds.DataReader, priority: 0);

    public bool CanRead(IFileInfos doc) => doc.MediaType.Contains("text/", StringComparison.OrdinalIgnoreCase);

    public Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        logger.LogInformation("Reading linear data from document at path '{DocumentPath}'", documentContext.FullPath);

        return Task.FromResult(dataEnvelopeBuilder.InitNew()
                                                  .WithDataShape(DataShape.Linear)
                                                  .WithMetadata(new Dictionary<string, string> { { "mediaType", documentContext.FileInfos.MediaType } })
                                                  .WithSinglePart(dataPartBuilder.InitNew()
                                                                                   .WithSource(new SourceRef(documentContext.FileInfos.Path))
                                                                                   .WithPayload(documentContext.FileInfos)
                                                                                   .WithTags(documentContext.Tags)
                                                                                   .Build())
                                                  .Build());
    }
}
