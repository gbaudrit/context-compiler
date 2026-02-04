using ContextCompiler.Abstractions.Commands;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Personas.Analysts.Business;

public sealed class BusinessAnalystModule(IConfigProvider cfgProvider,
                                        IPersonasProvider personasProvider,
                                        IPersonaBuilder personaBuilder,
                                        ICommandsProvider commandsProvider,
                                        ICommandBuilder commandBuilder,
                                        ILogger<BusinessAnalystModule> logger) : IConfigurationModule
{
    private const string PersonaId = "analysts.business";

    public ModuleMetadata Metadata => IModule.Meta($"personas.{PersonaId}", GlobalPipelineModuleKinds.Configuration, priority: 10);

    public Task Run(CancellationToken cancellationToken)
    {
        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("write userstory")
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
