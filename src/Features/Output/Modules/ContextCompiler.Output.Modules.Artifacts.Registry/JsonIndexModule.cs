using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Output.Modules.Artifacts.Registry.Extensions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;

using Microsoft.Extensions.Logging;
using ContextCompiler.Output.Modules.Artifacts.Registry.Models;
using ContextCompiler.Output.Modules.Artifacts.Registry.Abstractions;

namespace ContextCompiler.Output.Modules.Artifacts.Registry;

internal sealed class JsonIndexModule(IConfigProvider cfgProvider,
                                        IOutput output,
                                        IJsonIndexSerializer jsonIndexSerializer,
                                        ILogger<JsonIndexModule> logger) : IConfigurationModule
{

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta($"artifacts.index.json", GlobalPipelineModuleKinds.ReportComposition, priority: 10000);

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        ArtifactsIndex index = new()
        {
            Artifacts = output.Artifacts.Select(a => a.ToArtifact()).ToList().AsReadOnly()
        };

        output.AddArtifact(builder =>
        {
            return builder.WithFileName("artifacts.index.json")
                          .WithContent(jsonIndexSerializer.Serialize(index))
                          .WithDescription("Artifacts index file")
                          .WithGeneratedBy(GetType());
        });

        return await context.Success();
    }


}
