using System.Text.Json;

using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.GlobalPipeline;

namespace ContextCompiler.Plugins.BuiltIn.Security;

public sealed class SecurityReportArtifact(IPrompt prompt, IOutput output, IGuardian guardian) : IOutputArtifactComposerPlugin
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.evidence.graph.json", GlobalPipelinePluginKinds.OutputArtifactComposer, priority: 0);

    public string Export(object graphModel)
    {
        return JsonSerializer.Serialize(graphModel, jsonSerializerOptions);
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        string secMd = "# Security Report\n\n" + (guardian.Findings.Count == 0 ? "No findings." :
            string.Join("\n", guardian.Findings.Select(f => $"- **{f.Severity}** `{f.PassId}` ({f.Action}): {f.Message} — `{f.EvidenceRef?.Path}`")));

        output.AddArtifact(builder =>
        {
            return builder.WithFileName("security.report.md")
                          .WithContent(secMd);

        });
    }
}
