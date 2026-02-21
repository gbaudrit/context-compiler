using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Modules.Abstractions;

public interface IEngineeringModule : IModule
{
    Task<IDataEnvelope> ApplyAsync(IDataEnvelope envelope, CancellationToken ct);
}
