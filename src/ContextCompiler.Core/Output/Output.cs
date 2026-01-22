using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Core.Output
{
    internal sealed class Output(IOutputArtifactBuilder outputArtifactBuilder, IOutputContext outputContext) : IOutput
    {
        private readonly List<IOutputArtifact> _artifacts = new();

        public IReadOnlyList<IOutputArtifact> Artifacts => _artifacts.AsReadOnly();

        public string Path => outputContext.OutputPath;

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
