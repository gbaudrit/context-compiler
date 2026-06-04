using ContextCompiler.Abstractions.Cli;
using ContextCompiler.Cli.Skills.Handlers;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Cli.Skills;

public static class DependencyInjection
{
    /// <summary>
    /// Registers the skills CLI handlers and contributes the <c>skills</c> top-level command
    /// to the unified <c>ctxc</c> CLI through DI.
    /// </summary>
    public static IServiceCollection AddSkillsCli(this IServiceCollection services)
    {
        return services
            .AddSingleton<ISkillsPlanHandler, SkillsPlanHandler>()
            .AddSingleton<ISkillsRestoreHandler, SkillsRestoreHandler>()
            .AddSingleton<ICliCommandContributor, SkillsCliContributor>();
    }
}
