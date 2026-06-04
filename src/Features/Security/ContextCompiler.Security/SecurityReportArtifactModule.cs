using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Security;

public sealed class SecurityReportArtifactModule(IOutput output, IGuardian guardian) : ICompilePipelineModule
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public ModuleMetadata Metadata => ICompilePipelineModule.Meta("security.report", CompilePipelineModuleKinds.ReportComposition, priority: 0);

    public string Export(object graphModel)
    {
        return JsonSerializer.Serialize(graphModel, jsonSerializerOptions);
    }

    public async Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
    {
        string secMd = "# Security Report\n\n" + (guardian.Findings.Count == 0 ? "No findings." :
            string.Join("\n", guardian.Findings.Select(f => $"- **{f.Severity}** `{f.PassId}` ({f.Action}): {f.Message} — `{f.EvidenceRef?.Uri}`")));

        output.AddArtifact(builder =>
        {
            return builder.WithName("security.report.md")
                          .InStore(StoreKeys.Reports)
                          .WithContent(secMd)
                          .WithGeneratedBy(GetType());

        });

        return await context.Success();
    }
}
