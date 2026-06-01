using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Skills;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Skills.Modules.Providers.Anthropic;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services.AddKeyedSingleton<ISkillProvider, AnthropicSkillProvider>(AnthropicSkillProvider.Id);
    }
}
