namespace ContextCompiler.Abstractions.Pipelines.InputIngestion
{
    public interface IInputIngestionContext
    {
        string RootPath { get; init; }
        IReadOnlyList<IInputItemContext> InputItems { get; }

        void AddInputItem(IInputItemContext inputItem);
    }
}
