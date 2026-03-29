using ContextCompiler.Mcp.Core.Resources;
using ContextCompiler.Mcp.Core.Views;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Mcp.Core;

public static class DependencyInjection
{

    public static IServiceCollection AddMcpCore(this IServiceCollection services)
    {
        // Register core services here
        return services.AddResources().AddViews();
    }

}
