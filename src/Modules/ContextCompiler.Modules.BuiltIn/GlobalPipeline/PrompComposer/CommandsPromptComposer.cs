using ContextCompiler.Abstractions.Commands;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;

namespace ContextCompiler.Modules.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class CommandsPromptComposer(IPrompt prompt, ICommandBuilder commandBuilder, IConfigProvider ctxcConfig, ICommandsProvider commandsProvider) : IPromptComposerModule
    {

        public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.commands", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

        public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
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
}
