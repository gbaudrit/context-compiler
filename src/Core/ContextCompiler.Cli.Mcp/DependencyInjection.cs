using ContextCompiler.Abstractions.Cli;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Cli.Mcp;

public static class DependencyInjection
{
    /// <summary>
    /// Contributes the <c>mcp</c> top-level command (with <c>serve</c> subcommand) to the
    /// unified <c>ctxc</c> CLI through DI.
    /// </summary>
    /// <param name="services">Host service collection.</param>
    /// <param name="args">Original process arguments forwarded to the MCP host on serve.</param>
    public static IServiceCollection AddMcpCli(this IServiceCollection services, string[] args)
    {
        return services
            .AddSingleton(new McpCliEntryArgs(args))
            .AddSingleton<ICliCommandContributor, McpCliContributor>();
    }
}
