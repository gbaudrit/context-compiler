using ContextCompiler.Modules.Abstractions.Prompts;
using ContextCompiler.Modules.BuiltIn.Templates.Scriban.Templates;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.BuiltIn.Templates.Scriban
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
