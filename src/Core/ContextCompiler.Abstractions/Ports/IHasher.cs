namespace ContextCompiler.Abstractions.Ports;

public interface IHasher
{
    string Sha256Hex(string input);
    string Sha256Hex(byte[] bytes);
    ulong SimHash64(string normalizedText);
}
