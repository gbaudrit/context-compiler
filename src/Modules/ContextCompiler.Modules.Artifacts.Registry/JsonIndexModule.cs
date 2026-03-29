using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Modules.Artifacts.Registry.Abstractions;
using ContextCompiler.Modules.Artifacts.Registry.Extensions;
using ContextCompiler.Modules.Artifacts.Registry.Models;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Artifacts.Registry;

internal sealed class JsonIndexModule(IConfigProvider cfgProvider,
                                        IPrompt prompt,
                                        IJsonIndexSerializer jsonIndexSerializer,
                                        ILogger<JsonIndexModule> logger) : IConfigurationModule
{

    public ModuleMetadata Metadata => IModule.Meta($"artifacts.index.json", GlobalPipelineModuleKinds.OutputArtifactComposer, priority: 10000);

    public Task Run(CancellationToken cancellationToken)
    {
        ArtifactsIndex index = new()
        {
            Artifacts = prompt.Artifacts.Select(a => a.ToArtifact()).ToList().AsReadOnly()
        };

        prompt.AddArtifact(builder =>
        {
            return builder.WithFileName("artifacts.index.json")
                          .WithContent(jsonIndexSerializer.Serialize(index))
                          .WithDescription("Artifacts index file")
                          .WithGeneratedBy(GetType());
        });

        return Task.CompletedTask;
    }


}
