using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.BuiltIn.Personas;

public sealed class ActivatedPersonasIndexArtifact(IPrompt prompt, IOutput output, IReasoningIr ir, ICtxcConfigProvider cfgProvider) : IOutputArtifactComposerModule
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.output.evidence.graph.json", GlobalPipelineModuleKinds.OutputArtifactComposer, priority: 0);

    public string Export(object graphModel)
    {
        return JsonSerializer.Serialize(graphModel, jsonSerializerOptions);
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        output.AddArtifact(builder =>
        {
            return builder.WithFileName("personas.active.json")
                          .WithContent(JsonSerializer.Serialize(new { active = cfgProvider.Current.Personas!.Active, mode = cfgProvider.Current.Personas.Mode, results = prompt.Personas }, jsonSerializerOptions));

        });
    }
}
