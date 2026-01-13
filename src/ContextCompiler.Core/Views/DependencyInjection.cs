using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Views;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Views;

public static class DependencyInjection
{

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<IViewResultBuilder, ViewResultBuilder>()
                       .AddSingleton<IViewsProvider, ViewsProvider>();
    }

}
