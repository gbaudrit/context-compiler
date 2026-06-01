using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Core.Output;

internal sealed class Output(IOutputContext outputContext, IOutputArtifactBuilder outputArtifactBuilder) : IOutput
{

    public string Path => outputContext.OutputPath;

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

    public IReadOnlyList<IViewResult> Views { get; set; } = [];
}
