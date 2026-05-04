namespace ContextCompiler.Prompting.Abstractions.Personas;

public interface IPersonasProvider
{
    IReadOnlyList<IPersona> Personas { get; }

    void Add(IPersona persona);
}
