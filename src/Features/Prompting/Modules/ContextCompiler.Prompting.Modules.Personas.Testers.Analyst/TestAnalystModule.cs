using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;

using Microsoft.Extensions.Logging;
using ContextCompiler.Prompting.Abstractions.Personas;
using ContextCompiler.Prompting.Abstractions.Commands;
using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Modules.Personas.Testers.Analyst;

public sealed class TestAnalystModule(IConfigProvider cfgProvider,
                                        IPersonasProvider personasProvider,
                                        IPersonaBuilder personaBuilder,
                                        ICommandsProvider commandsProvider,
                                        ICommandBuilder commandBuilder,
                                        ILogger<TestAnalystModule> logger) : IConfigurationModule
{
    private const string PersonaId = "testers.analyst";

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta($"personas.{PersonaId}", GlobalPipelineModuleKinds.Setup, priority: 10);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("write testcase")
                                    .WithDescription("write all required test case for actual context")
                                    .ForPersona(PersonaId)
                                    .Build());

        BuildPersona();

        return context.Success();
    }

    private void BuildPersona()
    {
        string role = "Test analyst";
        string language = "FR";

        personasProvider.Add(personaBuilder
            .InitNew()
            .WithPersonaId(PersonaId)
            .WithTitle(role)
            .WithMetadata(new Dictionary<string, string> { { "language", language } })
            .WithRole(role)
            .WithMust(
            [
                "Write functional tests cases",
                "Cover all required cases",
                "Always show tests cases coverage summary"
            ])
            .WithMustNot(Array.Empty<string>())
            .Build());
    }
}
