using ContextCompiler.Abstractions.Commands;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Views.View.Index.Json;

public sealed class ViewJsonIndexModule(IConfigProvider cfgProvider,
                                        IPersonasProvider personasProvider,
                                        IPersonaBuilder personaBuilder,
                                        ICommandsProvider commandsProvider,
                                        ICommandBuilder commandBuilder,
                                        ILogger<ViewJsonIndexModule> logger) : IConfigurationModule
{
    private const string PersonaId = "analysts.business";

    public ModuleMetadata Metadata => IModule.Meta($"personas.{PersonaId}", GlobalPipelineModuleKinds.Configuration, priority: 10);

    public Task Run(CancellationToken cancellationToken)
    {
        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("us write")
                                    .WithDescription("write a user story with actual context")
                                    .ForPersona(PersonaId)
                                    .Build());

        BuildPersona();

        return Task.CompletedTask;
    }

    private void BuildPersona()
    {
        string role = "Analyste métier";
        string language = "FR";

        personasProvider.Add(personaBuilder
            .InitNew()
            .WithPersonaId(PersonaId)
            .WithTitle(role)
            .WithMetadata(new Dictionary<string, string> { { "language", language } })
            .WithRole(role)
            .WithMust(
            [
                "Write user stories",
                "Cover all required cases"
            ])
            .WithMustNot(Array.Empty<string>())
            .Build());
    }
}
