namespace ContextCompiler.Abstractions.Ports;

public interface IArtifactStore
{
    string Root { get; }
    string Combine(params string[] parts);
    void Ensure();
    void WriteText(string relativePath, string content);
    void WriteBytes(string relativePath, byte[] bytes);
    string ReadText(string relativePath);
    bool Exists(string relativePath);
}
