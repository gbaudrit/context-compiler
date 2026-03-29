using System.Text.Json;

using ContextCompiler.Modules.Commands.Registry.Abstractions;
using ContextCompiler.Modules.Commands.Registry.Models;

namespace ContextCompiler.Modules.Commands.Registry;

internal sealed class CommandsIndexSerializer : ICommandsIndexSerializer
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    public string Serialize(CommandsIndex index)
    {
        return JsonSerializer.Serialize(index, JsonOptions);
    }

    public CommandsIndex Deserialize(string json)
    {
        return JsonSerializer.Deserialize<CommandsIndex>(json, JsonOptions)
               ?? throw new InvalidOperationException("Failed to deserialize commands index.");
    }
}
