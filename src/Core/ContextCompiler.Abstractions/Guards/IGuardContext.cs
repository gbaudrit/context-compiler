using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Abstractions.Guards
{
    public interface IGuardContext
    {
        IInputItemContext InputItemContext { get; }
        IDataPart? Part { get; }
    }
}
