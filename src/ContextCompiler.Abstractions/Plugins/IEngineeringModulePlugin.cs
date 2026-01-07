using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Plugins;

public interface IEngineeringModulePlugin : IPlugin
{
    Task<IDataEnvelope> ApplyAsync(IDataEnvelope envelope, CancellationToken ct);
}
