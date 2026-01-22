using System.Globalization;
using System.Text;
using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Plugins.BuiltIn.GraphExporters;

public sealed class ActivatedPersonasIndexArtifact(IPrompt prompt, IOutput output, IReasoningIr ir, ICtxcConfigProvider cfgProvider) : IOutputArtifactComposerPlugin
{
    private JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.evidence.graph.json", PluginKinds.OutputArtifactComposer, priority: 0);

    public string Export(object graphModel)
        => JsonSerializer.Serialize(graphModel, jsonSerializerOptions);

    public async ValueTask Compose(CancellationToken cancellationToken)
    {
        output.AddArtifact(builder =>
        {
            return builder.WithFileName("personas.active.json")
                          .WithContent(JsonSerializer.Serialize(new { active = cfgProvider.Current.Personas!.Active, mode = cfgProvider.Current.Personas.Mode, results = prompt.Personas }, jsonSerializerOptions));

        });
    }
}
