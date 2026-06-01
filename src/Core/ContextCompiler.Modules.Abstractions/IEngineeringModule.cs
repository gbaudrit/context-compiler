using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Modules.Abstractions;

public interface IEngineeringModule : IModule
{
    Task<IDataEnvelope> ApplyAsync(IDataEnvelope envelope, CancellationToken ct);
}
