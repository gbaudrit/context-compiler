using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.CompilePipeline;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Modules.Commands.Registry.Abstractions;
using ContextCompiler.Prompting.Modules.Commands.Registry.Models;

namespace ContextCompiler.Prompting.Modules.Commands.Registry;

internal sealed class CommandIndexModule(
    IPrompt prompt,
    IOutput output,
    ICommandsIndexSerializer commandsIndexSerializer) : IConfigurationModule
{
    public ModuleMetadata Metadata => ICompilePipelineModule.Meta(
        "commands.index.json",
        CompilePipelineModuleKinds.ReportComposition,
        priority: 10000);

    public async Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
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

        output.AddArtifact(builder =>
        {
            return builder.WithName("commands.index.json")
                .InStore(StoreKeys.Output)
                .WithContent(commandsIndexSerializer.Serialize(index))
                .WithDescription("Commands index file")
                .WithGeneratedBy(GetType());
        });

        return await context.Success();
    }
}
