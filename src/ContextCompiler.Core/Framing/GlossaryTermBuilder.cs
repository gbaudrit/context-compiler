using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing;

internal sealed class GlossaryTermBuilder : IGlossaryTermBuilder
{
    private string? _term;
    private string? _definition;

    public IGlossaryTermBuilder InitNew()
    {
        _term = null;
        _definition = null;
        return this;
    }

    public IGlossaryTermBuilder WithTerm(string term)
    {
        _term = term;
        return this;
    }

    public IGlossaryTermBuilder WithDefinition(string definition)
    {
        _definition = definition;
        return this;
    }

    public IGlossaryTerm Build()
    {
        if (_term is null) throw new InvalidOperationException("Glossary term is required.");
        if (_definition is null) throw new InvalidOperationException("Glossary definition is required.");
        return new GlossaryTerm { Term = _term, Definition = _definition };
    }
}
