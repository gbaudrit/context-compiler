using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Guards
{
    public interface IGuardContext
    {
        IDocumentContext DocumentContext { get; }
        IDataPart? Part { get; }
    }
}
