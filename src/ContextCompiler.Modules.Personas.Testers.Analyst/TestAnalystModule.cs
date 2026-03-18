using ContextCompiler.Abstractions.Commands;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Personas.Testers.Analyst;

public sealed class TestAnalystModule(IConfigProvider cfgProvider,
                                        IPersonasProvider personasProvider,
                                        IPersonaBuilder personaBuilder,
                                        ICommandsProvider commandsProvider,
                                        ICommandBuilder commandBuilder,
                                        ILogger<TestAnalystModule> logger) : IConfigurationModule
{
    private const string PersonaId = "testers.analyst";

    public ModuleMetadata Metadata => IModule.Meta($"personas.{PersonaId}", GlobalPipelineModuleKinds.Configuration, priority: 10);

    public Task Run(CancellationToken cancellationToken)
    {
        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("tester write testcase")
                                    .WithDescription("write all required test case for actual context")
                                    .ForPersona(PersonaId)
                                    .Build());

        BuildPersona();

        return Task.CompletedTask;
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
