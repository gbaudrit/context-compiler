using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Abstractions.Personas
{
    public interface IPersonaResult
    {
        string PersonaId { get; }
        string Title { get; }
        string Role { get; }
        string FramingMarkdown { get; }
        IReadOnlyDictionary<string, string>? Metadata { get; }
        IReadOnlyList<IMustConstraint> Must { get; }
        IReadOnlyList<IMustNotConstraint> MustNot { get; }
    }
}
