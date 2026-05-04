using ContextCompiler.Prompting.Modules.Commands.Registry.Models;

namespace ContextCompiler.Prompting.Modules.Commands.Registry.Abstractions;

public interface ICommandsIndexSerializer
{
    string Serialize(CommandsIndex index);
    CommandsIndex Deserialize(string json);
}
