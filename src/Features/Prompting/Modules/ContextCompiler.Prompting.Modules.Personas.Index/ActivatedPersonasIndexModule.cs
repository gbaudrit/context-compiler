using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Prompting.Abstractions;

namespace ContextCompiler.Prompting.Modules.Personas.Index;

public sealed class ActivatedPersonasIndexModule(IPrompt prompt, IOutput output, IReasoningIr ir, IConfigProvider cfgProvider) : IOutputArtifactComposerModule
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("personas.index", GlobalPipelineModuleKinds.ReportComposition, priority: 0);

    public string Export(object graphModel)
    {
        return JsonSerializer.Serialize(graphModel, jsonSerializerOptions);
    }

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        output.AddArtifact(builder =>
        {
            return builder.WithFileName("personas.active.json")
                          .WithContent(JsonSerializer.Serialize(new { active = cfgProvider.Current.Personas!.Active, mode = cfgProvider.Current.Personas.Mode, results = prompt.Personas }, jsonSerializerOptions))
                          .WithGeneratedBy(GetType());

        });

        return await context.Success();
    }
}
