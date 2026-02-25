namespace ContextCompiler.Modules.Abstractions;

public interface IModuleSignature
{
    bool Required { get; }
    bool IsSigned { get; }

    string Note { get; }
    string SignerFingerprint { get; }
}
