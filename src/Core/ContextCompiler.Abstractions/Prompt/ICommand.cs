namespace ContextCompiler.Abstractions.Prompt
{
    public interface ICommand
    {
        string Id { get; }
        string Description { get; }
        string Example { get; }
        List<ICommand> Subs { get; }
        string PersonaId { get; init; }
    }
}
