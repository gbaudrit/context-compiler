using ContextCompiler.Skills.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Skills;

public static class DependencyInjection
{
    public static IServiceCollection AddSkills(this IServiceCollection services)
    {
        return services.AddTransient<ISkillInfosBuilder, SkillInfosBuilder>()
                       .AddTransient<ISkillsRestorer, SkillsRestorer>()
                       .AddTransient<ISkillInstallPlanner, SkillInstallPlanner>();
    }
}
