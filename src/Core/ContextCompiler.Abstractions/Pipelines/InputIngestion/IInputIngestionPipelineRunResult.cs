namespace ContextCompiler.Abstractions.Pipelines.InputIngestion;

public interface IInputIngestionPipelineRunResult
{

    IInputItemContextPatch Patch { get; }

}
