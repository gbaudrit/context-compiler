namespace ContextCompiler.Abstractions.Pipelines.Document;

public interface IDocumentContextPatcher
{

    Task<IDocumentContext> Patch(IDocumentContext context, IDocumentContextPatch patch);

}
