using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Prompting.Modules.Templates.Scriban
{
    internal sealed class ModuleRegistration : IDependencyInjection
    {

        public IServiceCollection RegisterServices(IServiceCollection services)
        {
            return services.AddScribanPromptTemplateEngine();
        }

    }
}
