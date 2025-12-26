using System.Text.RegularExpressions;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.EngineeringModules;

public sealed class BasicNormalizeModule : IEngineeringModulePlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.engineering.normalize", PluginKinds.EngineeringModule, priority: 0);

    public Task<DataEnvelope> ApplyAsync(DataEnvelope envelope, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        if (envelope.Shape == DataShape.Linear && envelope.Payload is string s)
        {
            s = s.Replace("\r\n", "\n");
            s = Regex.Replace(s, "[ \t]{2,}", " ");
            return Task.FromResult(envelope with { Payload = s });
        }

        return Task.FromResult(envelope);
    }
}
