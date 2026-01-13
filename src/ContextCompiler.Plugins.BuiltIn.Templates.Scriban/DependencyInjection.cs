using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Plugins.Prompts;
using ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Templates;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddScribanPromptTemplateEngine(this IServiceCollection services)
        {
            // Register core services here
            services.AddSingleton<ITemplateProvider, TemplateProvider>()
                    .AddTransient<IPromptRenderingPlugin, ScribanPromptTemplatePlugin>();
            return services;
        }

    }
}
