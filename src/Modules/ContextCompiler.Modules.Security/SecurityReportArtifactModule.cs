using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Security;

public sealed class SecurityReportArtifactModule(IPrompt prompt, IGuardian guardian) : IOutputArtifactComposerModule
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("security.report", GlobalPipelineModuleKinds.OutputArtifactComposer, priority: 0);

    public string Export(object graphModel)
    {
        return JsonSerializer.Serialize(graphModel, jsonSerializerOptions);
    }

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        string secMd = "# Security Report\n\n" + (guardian.Findings.Count == 0 ? "No findings." :
            string.Join("\n", guardian.Findings.Select(f => $"- **{f.Severity}** `{f.PassId}` ({f.Action}): {f.Message} — `{f.EvidenceRef?.Path}`")));

        prompt.AddArtifact(builder =>
        {
            return builder.WithFileName("security.report.md")
                          .WithContent(secMd)
                          .WithGeneratedBy(GetType());

        });

        return await context.Success();
    }
}
