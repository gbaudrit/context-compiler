namespace ContextCompiler.Prompting.Abstractions.Prompt;

public interface IGlossaryTermBuilder
{
    IGlossaryTerm Build();
    IGlossaryTermBuilder InitNew();
    IGlossaryTermBuilder WithTerm(string term);
    IGlossaryTermBuilder WithDefinition(string definition);
}
