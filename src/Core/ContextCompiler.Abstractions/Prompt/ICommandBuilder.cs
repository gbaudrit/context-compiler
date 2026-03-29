
namespace ContextCompiler.Abstractions.Prompt
{
    public interface ICommandBuilder
    {
        ICommand Build();
        ICommandBuilder ForPersona(string personaId);
        ICommandBuilder InitNew();
        ICommandBuilder WithDescription(string description);
        ICommandBuilder WithName(string name);
        ICommandBuilder WithSubs(List<ICommand> subs);
    }
}
