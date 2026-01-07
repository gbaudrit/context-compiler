using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.DataReaders;

public sealed class LinearDataReader(IDataEnvelopeBuilder dataEnvelopeBuilder, IDataPartBuilder dataPartBuilder) : IDataReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.data.linear", PluginKinds.DataReader, priority: 0);

    public bool CanRead(DocumentContent doc) => doc.Text is not null;

    public Task<IDataEnvelope> ReadAsync(DocumentContent doc, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        

        return Task.FromResult(dataEnvelopeBuilder.InitNew()
                                                  .WithDataShape(DataShape.Linear)
                                                  .WithPayload(doc.Text ?? string.Empty)
                                                  .WithMetadata(new Dictionary<string, string> { { "mediaType", doc.MediaType } })
                                                  .WithSinglePart(dataPartBuilder.InitNew()
                                                                                   .WithSource(new SourceRef(doc.Path))
                                                                                   .WithPayload(doc.Text ?? string.Empty)
                                                                                   .Build())
                                                  .Build());
    }
}
