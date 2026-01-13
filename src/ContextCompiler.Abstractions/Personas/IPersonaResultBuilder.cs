using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Abstractions.Personas
{
    public interface IPersonaResultBuilder
    {
        IPersonaResult Build();
        IPersonaResultBuilder InitNew();
        IPersonaResultBuilder WithFramingMarkdown(string framingMarkdown);
        IPersonaResultBuilder WithMetadata(IReadOnlyDictionary<string, string> metadata);
        IPersonaResultBuilder WithMust(IReadOnlyList<IMustConstraint> must);
        IPersonaResultBuilder WithMust(IReadOnlyList<string> must);
        IPersonaResultBuilder WithMustNot(IReadOnlyList<IMustNotConstraint> mustNot);
        IPersonaResultBuilder WithMustNot(IReadOnlyList<string> mustNot);
        IPersonaResultBuilder WithPersonaId(string personaId);
        IPersonaResultBuilder WithRole(string role);
        IPersonaResultBuilder WithTitle(string title);
    }
}
