
namespace ContextCompiler.Abstractions.Prompt
{
    public interface ICommandBuilder
    {
        ICommand Build();
        ICommandBuilder InitNew();
        ICommandBuilder WithDescription(string description);
        ICommandBuilder WithName(string name);
        ICommandBuilder WithSubs(List<ICommand> subs);
    }
}
