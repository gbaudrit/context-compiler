namespace ContextCompiler.Abstractions.Pipelines.Document;

public interface IDocumentPipelineRunResult
{

    IDocumentContextPatch Patch { get; }

}
