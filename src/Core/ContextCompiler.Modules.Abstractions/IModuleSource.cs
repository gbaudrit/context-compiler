namespace ContextCompiler.Modules.Abstractions;

public interface IModuleSource
{

    string Id { get; }
    string Provider { get; }
    Uri Url { get; }
    bool ValidatePackagesSignature { get; }

}
