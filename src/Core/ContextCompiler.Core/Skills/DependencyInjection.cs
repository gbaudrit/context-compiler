using ContextCompiler.Modules.Abstractions.Skills;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Skills;

internal static class DependencyInjection
{
    public static IServiceCollection AddSkills(this IServiceCollection services)
    {
        return services.AddTransient<ISkillInfosBuilder, SkillInfosBuilder>()
                       .AddTransient<ISkillsRestorer, SkillsRestorer>()
                       .AddTransient<ISkillInstallPlanner, SkillInstallPlanner>();
    }
}
