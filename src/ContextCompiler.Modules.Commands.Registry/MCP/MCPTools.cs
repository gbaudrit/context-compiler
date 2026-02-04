using System.Text.Json;

using ContextCompiler.Modules.Commands.Registry.Abstractions;
using ContextCompiler.Modules.Commands.Registry.Models;

using Microsoft.Extensions.DependencyInjection;

using ModelContextProtocol.Server;

namespace ContextCompiler.Modules.Commands.Registry.MCP;

[McpServerToolType]
public static class MCPTools
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    [McpServerTool, System.ComponentModel.Description("List current commands produced by the last compileContext call.")]
    public static string ListCommands(IServiceProvider services)
    {
        IListCommands listCommands = services.GetRequiredService<IListCommands>();
        IReadOnlyList<CommandDescriptor> commands = listCommands.Execute(CancellationToken.None).Result;
        return JsonSerializer.Serialize(commands, JsonOptions);
    }
}
