using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Abstractions.Files
{
    public interface ILinearFileReader : IDisposable
    {
        Task<IDataEnvelope> ReadAsync(IInputItemContext InputItemContext, CancellationToken ct);
    }
}
