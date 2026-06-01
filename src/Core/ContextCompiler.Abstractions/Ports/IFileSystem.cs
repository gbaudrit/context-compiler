namespace ContextCompiler.Abstractions.Ports;

public interface IFileSystem
{
    IEnumerable<string> EnumerateFiles(string rootPath);
    bool FileExists(string path);
    Stream OpenRead(string path);
    string ReadAllText(string path);
    void EnsureDirectory(string path);
    void WriteAllText(string path, string content);
    void WriteAllBytes(string path, byte[] bytes);
    void EnsureDirectory(string path, bool clean);
}
