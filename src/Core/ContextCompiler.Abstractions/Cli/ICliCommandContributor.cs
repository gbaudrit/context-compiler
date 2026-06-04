using System.CommandLine;

namespace ContextCompiler.Abstractions.Cli;

/// <summary>
/// Contributes a top-level <see cref="Command"/> to the unified <c>ctxc</c> CLI.
/// Implementations are resolved via DI (<c>IEnumerable&lt;ICliCommandContributor&gt;</c>) and
/// each <see cref="Build"/> result is attached to the root command.
/// </summary>
public interface ICliCommandContributor
{
    /// <summary>
    /// Builds the command this contributor exposes (e.g. <c>modules</c>, <c>mcp</c>).
    /// </summary>
    /// <param name="services">Application services provider.</param>
    /// <returns>The command to attach to the CLI root.</returns>
    Command Build(IServiceProvider services);
}
