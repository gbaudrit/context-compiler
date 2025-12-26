using ContextCompiler.Abstractions.Ports;

namespace ContextCompiler.Infrastructure.FileSystem;

public sealed class PhysicalFileSystem : IFileSystem
{
    public IEnumerable<string> EnumerateFiles(string rootPath)
        => Directory.EnumerateFiles(rootPath, "*", SearchOption.AllDirectories);

    public bool FileExists(string path) => File.Exists(path);

    public Stream OpenRead(string path) => File.OpenRead(path);

    public string ReadAllText(string path) => File.ReadAllText(path);

    public void EnsureDirectory(string path) => Directory.CreateDirectory(path);

    public void WriteAllText(string path, string content)
    {
        EnsureDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, content);
    }

    public void WriteAllBytes(string path, byte[] bytes)
    {
        EnsureDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllBytes(path, bytes);
    }
}
