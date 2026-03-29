namespace ContextCompiler.Abstractions.Personas;

public interface IPersonasProvider
{
    IReadOnlyList<IPersona> Personas { get; }

    void Add(IPersona persona);
}
