using ContextCompiler.Modules.Abstractions.Prompts;
using ContextCompiler.Prompting.Modules.Templates.Scriban.Templates;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Prompting.Modules.Templates.Scriban
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddScribanPromptTemplateEngine(this IServiceCollection services)
        {
            // Register core services here
            return services.AddSingleton<ITemplateProvider, TemplateProvider>()
                    .AddTransient<IPromptRenderingModule, ScribanPromptTemplateModule>();
        }

    }
}
