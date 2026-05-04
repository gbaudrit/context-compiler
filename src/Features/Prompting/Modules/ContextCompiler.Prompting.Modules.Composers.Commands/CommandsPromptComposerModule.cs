using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Commands;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;
using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Modules.Composers.Commands;

internal sealed class CommandsPromptComposer(IPrompt prompt, ICommandBuilder commandBuilder, IConfigProvider ctxcConfig, ICommandsProvider commandsProvider) : IPromptComposerModule
{

    public ModuleMetadata Metadata => IPromptComposerModule.Meta("builtin.prompt.composer.commands", GlobalPipelineModuleKinds.OutputComposition, priority: 10);

    public async Task<IResult<IPromptComposerRunResult>> Run(IPromptComposerRunContext context, CancellationToken cancellationToken)
    {
        List<ICommand> commands =
        [
            commandBuilder.InitNew()
                                    .WithName("load")
                                    .WithDescription("Load this context")
                                    .Build(),
                commandBuilder.InitNew()
                                    .WithName("role <name>")
                                    .WithDescription("Load role (persona) <name> and be him")
                                    .Build(),
                commandBuilder.InitNew()
                                    .WithName("evidence used")
                                    .WithDescription("List all evidence fragments you have analysed")
                                    .Build(),
                commandBuilder.InitNew()
                                    .WithName("evidence coverage stats")
                                    .WithDescription("statistical analysis of the evidence used in relation to the complete list to establish coverage")
                                    .Build(),
                commandBuilder.InitNew()
                                    .WithName("write complete report to output")
                                    .WithDescription("Write a complete report to the output")
                                    .Build(),
            ];

        if (ctxcConfig.Current.Views.Views.Count > 0)
        {
            commands.Add(commandBuilder.InitNew()
                                .WithName("view <name>")
                                .WithDescription("Load view view.<name>.yaml and it's index view.<name>.json")
                                .Build());
        }

        foreach (ICommand cmd in commandsProvider.Commands)
        {
            commands.Add(cmd);
        }

        prompt.Commands = commands;
        return await context.Success();
    }
}
