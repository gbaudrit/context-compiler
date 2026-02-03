using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class ReadDocumentPass(IPluginRegistry plugins) : IDocumentPass
    {
        public string Id => "pass.read";
        public int Priority => 200;
        public DocumentStage Stage => DocumentStage.FileRead;

        public async ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct)
        {
            IFileReaderPlugin? reader = plugins.FileReaders.FirstOrDefault(r => r.CanRead(ctx.FullPath));
            if (reader is null)
            {
                return;
            }

            IDataEnvelope envelope = await reader.ReadAsync(ctx, ct);
            //ctx.SetFileRead(doc);

            //var dataReader = plugins.DataReaders.FirstOrDefault(r => r.CanRead(doc.Content));
            //if (dataReader is null) return;

            //var envelope = await dataReader.ReadAsync(ctx, ct);
            ctx.SetData(envelope);

            await Task.CompletedTask;
        }
    }
}
