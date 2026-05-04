using ContextCompiler.Prompting.Abstractions.Personas;

namespace ContextCompiler.Prompting.Personas;

internal sealed class PersonasProvider : IPersonasProvider
{

    private readonly List<IPersona> _personas = [];

    public IReadOnlyList<IPersona> Personas => _personas;

    public void Add(IPersona persona)
    {
        if (!_personas.Any(p => p.PersonaId == persona.PersonaId))
        {
            _personas.Add(persona);
        }
    }

}
