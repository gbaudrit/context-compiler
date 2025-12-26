using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Plugins;

public interface IEngineeringModulePlugin : IPlugin
{
    Task<DataEnvelope> ApplyAsync(DataEnvelope envelope, CancellationToken ct);
}
