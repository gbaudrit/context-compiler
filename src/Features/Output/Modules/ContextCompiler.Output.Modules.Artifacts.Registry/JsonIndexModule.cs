using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.CompilePipeline;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;
using ContextCompiler.Output.Modules.Artifacts.Registry.Abstractions;
using ContextCompiler.Output.Modules.Artifacts.Registry.Extensions;
using ContextCompiler.Output.Modules.Artifacts.Registry.Models;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Output.Modules.Artifacts.Registry;

internal sealed class JsonIndexModule(IConfigProvider cfgProvider,
                                        IOutput output,
                                        IJsonIndexSerializer jsonIndexSerializer,
                                        ILogger<JsonIndexModule> logger) : IConfigurationModule
{

    public ModuleMetadata Metadata => ICompilePipelineModule.Meta($"artifacts.index.json", CompilePipelineModuleKinds.ReportComposition, priority: 10000);

    public async Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
    {
        ArtifactsIndex index = new()
        {
            Artifacts = output.Artifacts.Select(a => a.ToArtifact()).ToList().AsReadOnly()
        };

        output.AddArtifact(builder =>
        {
            return builder.WithName("artifacts.index.json")
                          .InStore(StoreKeys.Output)
                          .WithContent(jsonIndexSerializer.Serialize(index))
                          .WithDescription("Artifacts index file")
                          .WithGeneratedBy(GetType());
        });

        return await context.Success();
    }


}
