namespace ContextCompiler.Abstractions.Output
{
    public interface IOutput
    {
        string Path { get; }

        IReadOnlyList<IOutputArtifact> Artifacts { get; }

        void AddArtifact(IOutputArtifact artifact);
        void AddArtifact(Func<IOutputArtifactBuilder, IOutputArtifactBuilder> builder);

    }
}
