using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Abstractions.Models
{
    public class Prompt(IOutputArtifactBuilder outputArtifactBuilder) : IPrompt
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
        public IReadOnlyList<IViewResult> Views { get; set; } = [];
        public IReadOnlyList<ICommand> Commands { get; set; } = [];
        public IReadOnlyList<IBlueprint> Blueprints { get; set; } = [];

        private readonly List<IOutputArtifact> _artifacts = [];

        public IReadOnlyList<IOutputArtifact> Artifacts => _artifacts.AsReadOnly();

        public void AddArtifact(IOutputArtifact artifact)
        {
            _artifacts.Add(artifact);
        }

        public void AddArtifact(Func<IOutputArtifactBuilder, IOutputArtifactBuilder> builder)
        {
            _artifacts.Add(builder(outputArtifactBuilder.InitNew()).Build());
        }
    }
}
