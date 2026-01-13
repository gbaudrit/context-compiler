using ContextCompiler.Abstractions.Plugins;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban
{
    internal sealed class PluginRegistration : IPluginRegistration
    {

        public IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddScribanPromptTemplateEngine();
            return services; 
        }

    }
}
