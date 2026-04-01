using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Prompt.Composers.Blueprints;

public static class DependencyInjection
{
    public static IServiceCollection AddBlueprintsPromptComposer(this IServiceCollection services)
    {
        return services.AddTransient<BlueprintsPromptComposerModule>();
    }
}
