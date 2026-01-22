using System.Globalization;
using System.Text;
using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Plugins.BuiltIn.GraphExporters;

public sealed class SecurityReportArtifact(IPrompt prompt, IOutput output, IGuardian guardian) : IOutputArtifactComposerPlugin
{
    private JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.evidence.graph.json", PluginKinds.OutputArtifactComposer, priority: 0);

    public string Export(object graphModel)
        => JsonSerializer.Serialize(graphModel, jsonSerializerOptions);

    public async ValueTask Compose(CancellationToken cancellationToken)
    {
        var secMd = "# Security Report\n\n" + (guardian.Findings.Count == 0 ? "No findings." :
            string.Join("\n", guardian.Findings.Select(f => $"- **{f.Severity}** `{f.PassId}` ({f.Action}): {f.Message} — `{f.EvidenceRef?.Path}`")));

        output.AddArtifact(builder =>
        {
            return builder.WithFileName("security.report.md")
                          .WithContent(secMd);

        });
    }
}
