using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;

using Microsoft.Extensions.Logging;
using ContextCompiler.Prompting.Abstractions.Personas;
using ContextCompiler.Prompting.Abstractions.Commands;
using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Modules.Personas.Analysts.Business;

public sealed class BusinessAnalystModule(IConfigProvider cfgProvider,
                                        IPersonasProvider personasProvider,
                                        IPersonaBuilder personaBuilder,
                                        ICommandsProvider commandsProvider,
                                        ICommandBuilder commandBuilder,
                                        ILogger<BusinessAnalystModule> logger) : IConfigurationModule
{
    private const string PersonaId = "analysts.business";

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta($"personas.{PersonaId}", GlobalPipelineModuleKinds.Setup, priority: 10);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("write userstory")
                                    .WithDescription("write a user story with actual context")
                                    .ForPersona(PersonaId)
                                    .Build());

        BuildPersona();

        return context.Success();
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
