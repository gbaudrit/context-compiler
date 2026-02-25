namespace ContextCompiler.Modules.Abstractions;

public interface ISource
{

    string Id { get; }
    string Provider { get; }
    Uri Url { get; }

}
