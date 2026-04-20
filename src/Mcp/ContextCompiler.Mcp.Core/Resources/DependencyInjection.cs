using ContextCompiler.Mcp.Core.Resources.List;
using ContextCompiler.Mcp.Core.Resources.Read;
using ContextCompiler.Mcp.Core.Views.Read;
using ContextCompiler.Modules.Abstractions.MCP;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Mcp.Core.Resources;

public static class DependencyInjection
{

    public static IServiceCollection AddResources(this IServiceCollection services)
    {
        // Register core services here
        return services.AddTransient<IMCPReadResourceHandler, ViewReadResourceHandler>()
                       .AddTransient<IMCPResourceBuilder, ResourceBuilder>()
                       .AddTransient<IMCPResourceContentsBuilder, ResourceContentsBuilder>()
                       .AddTransient<IMCPListResourceResultBuilder, ListResourceResultBuilder>()
                       .AddTransient<IMCPReadResourceResultBuilder, ReadResourceResultBuilder>();
    }

}
