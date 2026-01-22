using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.DataReaders;

public sealed class LinearDataReader(IDataEnvelopeBuilder dataEnvelopeBuilder, IDataPartBuilder dataPartBuilder) : IDataReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.data.linear", GlobalPipelinePluginKinds.DataReader, priority: 0);

    public bool CanRead(IFileInfos doc) => doc.Text is not null;

    public Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        

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
