namespace ContextCompiler.Abstractions.Pipelines.InputIngestion;

public interface IInputItemContextPatcher
{

    Task<IInputItemContext> Patch(IInputItemContext context, IInputItemContextPatch patch);

}
