namespace ContextCompiler.Abstractions.Pipelines;

public interface IPipeline
{

    string Id => GetType().Name;

}
