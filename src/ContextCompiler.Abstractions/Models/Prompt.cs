using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Abstractions.Models
{
    public class Prompt : IPrompt
    {
        public string Global { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;

        public IReadOnlyList<IAudience> Audiences { get; set; } = new List<IAudience>();
        public IReadOnlyList<IObjective> Objectives { get; set; } = new List<IObjective>();
        public IReadOnlyList<IAssumption> Assumptions { get; set; } = new List<IAssumption>();
        public IReadOnlyList<IGlossaryTerm> Glossary { get; set; } = new List<IGlossaryTerm>();
        public IReadOnlyList<IMustConstraint> MustConstraints { get; set; } = new List<IMustConstraint>();
        public IReadOnlyList<IMustNotConstraint> MustNotConstraints { get; set; } = new List<IMustNotConstraint>();
        public IReadOnlyList<IPersonaResult> Personas { get; set; } = new List<IPersonaResult>();
        public IReadOnlyList<IViewResult> Views { get; set; } = new List<IViewResult>();
        public IReadOnlyList<ICommand> Commands { get; set; } = new List<ICommand>();
    }
}
