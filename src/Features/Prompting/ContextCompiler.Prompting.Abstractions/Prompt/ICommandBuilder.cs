namespace ContextCompiler.Prompting.Abstractions.Prompt
{
    public interface ICommandBuilder
    {
        ICommand Build();
        ICommandBuilder InitNew();
        ICommandBuilder WithName(string name);
        ICommandBuilder WithDescription(string description);
        ICommandBuilder WithExample(string example);
        ICommandBuilder ForPersona(string personaId);
        ICommandBuilder WithSubs(List<ICommand> subs);
    }
}
