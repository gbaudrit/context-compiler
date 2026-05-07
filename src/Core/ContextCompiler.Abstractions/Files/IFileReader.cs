using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Abstractions.Files
{
    public interface IFileReader : IDisposable
    {
        ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct);

        Task<IDataEnvelope> ReadAsync(IInputItemContext InputItemContext, CancellationToken ct);
    }
}
