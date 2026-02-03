namespace ContextCompiler.Abstractions.Prompt
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        List<ICommand> Subs { get; }
    }
}
