using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.CompilePipeline;
using ContextCompiler.Abstractions.Common;

using Microsoft.Extensions.Logging;
using ContextCompiler.Prompting.Abstractions.Personas;
using ContextCompiler.Prompting.Abstractions.Commands;
using ContextCompiler.Prompting.Abstractions.Prompt;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Prompting.Modules.Personas.Analysts.Business;

public sealed class BusinessAnalystModule(IConfigProvider cfgProvider,
                                        IPersonasProvider personasProvider,
                                        IPersonaBuilder personaBuilder,
                                        ICommandsProvider commandsProvider,
                                        ICommandBuilder commandBuilder,
                                        ILogger<BusinessAnalystModule> logger) : IConfigurationModule
{
    private const string PersonaId = "analysts.business";

    public ModuleMetadata Metadata => ICompilePipelineModule.Meta($"personas.{PersonaId}", CompilePipelineModuleKinds.Setup, priority: 10);

    public Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
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
