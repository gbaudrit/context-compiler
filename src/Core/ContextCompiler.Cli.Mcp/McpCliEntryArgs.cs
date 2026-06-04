namespace ContextCompiler.Cli.Mcp;

/// <summary>
/// Carries the original process command-line arguments to the MCP CLI contributor
/// so it can re-build a hosted MCP server when <c>ctxc mcp serve</c> is invoked.
/// </summary>
public sealed record McpCliEntryArgs(string[] Args);
