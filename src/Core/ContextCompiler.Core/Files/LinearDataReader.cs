using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Files;

public sealed class LinearDataReader(IDataEnvelopeBuilder dataEnvelopeBuilder, IDataPartBuilder dataPartBuilder, ISourceRefBuilder sourceRefBuilder, ILogger<LinearDataReader> logger) : ILinearFileReader
{
    private bool disposedValue;

    //public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.data.linear", GlobalPipelinePluginKinds.DataReader, priority: 0);

    //public bool CanRead(IFileInfos doc) => doc.MediaType.Contains("text/", StringComparison.OrdinalIgnoreCase);

    public Task<IDataEnvelope> ReadAsync(IInputItemContext InputItemContext, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        logger.LogInformation("Reading linear data from InputItem at path '{DocumentPath}'", InputItemContext.FullPath);

        using FileStream fs = File.OpenRead(InputItemContext.FullPath);

        return Task.FromResult(dataEnvelopeBuilder.InitNew()
                                                  .WithDataShape(DataShape.Linear)
                                                  //.WithMetadata(new Dictionary<string, string> { { "mediaType", InputItemContext.FileInfos.MediaType } })
                                                  .WithSinglePart(dataPartBuilder.InitNew()
                                                                                   .WithSource(sourceRefBuilder.InitNew().WithPath(InputItemContext.FullPath).Build())
                                                                                   //.WithPayload(InputItemContext.FileInfos)
                                                                                   .WithTags(InputItemContext.Data.Tags)
                                                                                   .Build())
                                                  .Build());
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~LinearDataReader()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
