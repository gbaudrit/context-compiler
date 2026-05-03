using ContextCompiler.Abstractions.Output;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Modules.Commands.Registry.Abstractions;
using ContextCompiler.Modules.Commands.Registry.Models;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;

namespace ContextCompiler.Modules.Commands.Registry;

internal sealed class CommandIndexModule(
    IPrompt prompt,
    ICommandsIndexSerializer commandsIndexSerializer) : IConfigurationModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
        "commands.index.json",
        GlobalPipelineModuleKinds.OutputArtifactComposer,
        priority: 10000);

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        // TODO:
        // - remplacer cette liste vide par la projection réelle des commandes
        //   disponibles dans le contexte / noyau / plugins.
        CommandsIndex index = new()
        {
            Commands = [.. prompt.Commands.Select(cmd => new CommandDescriptor
            {
                Id = cmd.Id,
                Description = cmd.Description,
                PersonaId = cmd.PersonaId
            })]
        };

        prompt.AddArtifact(builder =>
        {
            return builder.WithFileName("commands.index.json")
                .WithContent(commandsIndexSerializer.Serialize(index))
                .WithDescription("Commands index file")
                .WithGeneratedBy(GetType());
        });

        return await context.Success();
    }
}
