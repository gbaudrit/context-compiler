using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Prompting.Abstractions;

namespace ContextCompiler.Prompting.Modules.Personas.Index;

public sealed class ActivatedPersonasIndexModule(IPrompt prompt, IOutput output, ICompiledContext ir, IConfigProvider cfgProvider) : IGlobalPipelineModule
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
            return builder.WithName("personas.active.json")
                          .InStore(StoreKeys.Output)
                          .WithContent(JsonSerializer.Serialize(new { active = cfgProvider.Current.Personas!.Active, mode = cfgProvider.Current.Personas.Mode, results = prompt.Personas }, jsonSerializerOptions))
                          .WithGeneratedBy(GetType());

        });

        return await context.Success();
    }
}
