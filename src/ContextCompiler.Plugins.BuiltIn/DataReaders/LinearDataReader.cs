using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.DataReaders;

public sealed class LinearDataReader : IDataReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.data.linear", PluginKinds.DataReader, priority: 0);

    public bool CanRead(DocumentContent doc) => doc.Text is not null;

    public Task<DataEnvelope> ReadAsync(DocumentContent doc, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return Task.FromResult(new DataEnvelope(DataShape.Linear, doc.Text ?? string.Empty, new Dictionary<string,string>{{"mediaType",doc.MediaType}}));
    }
}
