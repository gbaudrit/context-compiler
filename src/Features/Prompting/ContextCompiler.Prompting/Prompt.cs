using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Personas;
using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting
{
    public class Prompt : IPrompt
    {
        public string Global { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;

        public IReadOnlyList<IAudience> Audiences { get; set; } = [];
        public IReadOnlyList<IObjective> Objectives { get; set; } = [];
        public IReadOnlyList<IAssumption> Assumptions { get; set; } = [];
        public IReadOnlyList<IGlossaryTerm> Glossary { get; set; } = [];
        public IReadOnlyList<IMustConstraint> MustConstraints { get; set; } = [];
        public IReadOnlyList<IMustNotConstraint> MustNotConstraints { get; set; } = [];
        public IReadOnlyList<IPersona> Personas { get; set; } = [];
        public IReadOnlyList<ICommand> Commands { get; set; } = [];
        public IReadOnlyList<IBlueprint> Blueprints { get; set; } = [];
    }
}
