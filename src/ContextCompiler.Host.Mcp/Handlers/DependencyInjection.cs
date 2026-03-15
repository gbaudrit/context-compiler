using ContextCompiler.Modules.Abstractions.MCP;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Host.Mcp.Handlers;

public static class DependencyInjection
{

    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        // Register core services here
        return services.AddTransient<IMCPReadResourceHandler, ViewReadResourceHandler>();
    }

}
