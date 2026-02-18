using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Plugins.Abstractions;

public interface IEngineeringModulePlugin : IPlugin
{
    Task<IDataEnvelope> ApplyAsync(IDataEnvelope envelope, CancellationToken ct);
}
