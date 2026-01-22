namespace ContextCompiler.Abstractions.Output
{
    public interface IOutput
    {
        string Path { get; }

        public IReadOnlyList<IOutputArtifact> Artifacts { get; }

        public void AddArtifact(IOutputArtifact artifact);
        public void AddArtifact(Func<IOutputArtifactBuilder, IOutputArtifactBuilder> builder);

    }
}
