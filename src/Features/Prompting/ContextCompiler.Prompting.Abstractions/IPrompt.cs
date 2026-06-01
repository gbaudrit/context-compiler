using ContextCompiler.Prompting.Abstractions.Personas;
using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Abstractions
{
    public interface IPrompt
    {
        //string Global { get; set; }
        IReadOnlyList<IPersona> Personas { get; set; }
        IReadOnlyList<IMustConstraint> MustConstraints { get; set; }
        IReadOnlyList<IMustNotConstraint> MustNotConstraints { get; set; }
        string Name { get; set; }
        string Summary { get; set; }
        string Domain { get; set; }
        IReadOnlyList<IAudience> Audiences { get; set; }
        IReadOnlyList<IObjective> Objectives { get; set; }
        IReadOnlyList<IAssumption> Assumptions { get; set; }
        IReadOnlyList<IGlossaryTerm> Glossary { get; set; }
        IReadOnlyList<ICommand> Commands { get; set; }
        IReadOnlyList<IBlueprint> Blueprints { get; set; }
    }
}
