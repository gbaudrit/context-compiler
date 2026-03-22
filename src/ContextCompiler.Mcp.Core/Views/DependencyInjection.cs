using ContextCompiler.Mcp.Core.Views.Read;
using ContextCompiler.Modules.Abstractions.MCP;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Mcp.Core.Views;

public static class DependencyInjection
{

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        // Register core services here
        return services.AddTransient<IMCPReadResourceHandler, ViewReadResourceHandler>();
    }

}
