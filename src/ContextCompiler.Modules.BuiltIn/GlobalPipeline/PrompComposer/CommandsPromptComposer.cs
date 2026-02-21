using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class CommandsPromptComposer(IPrompt prompt, ICommandBuilder commandBuilder, ICtxcConfigProvider ctxcConfig) : IPromptComposerModule
    {

        public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.commands", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

        public Task Run(CancellationToken cancellationToken)
        {
            List<ICommand> commands =
            [
                commandBuilder.InitNew()
                                    .WithName("init, load")
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
                                    .Build()
            ];

            if (ctxcConfig.Current.Views.Views.Length != 0)
            {
                commands.Add(commandBuilder.InitNew()
                                    .WithName("view <name>")
                                    .WithDescription("Load view view.<name>.yaml and it's index view.<name>.json")
                                    .Build());
            }


            prompt.Commands = commands;
            return Task.CompletedTask;
        }
    }
}
