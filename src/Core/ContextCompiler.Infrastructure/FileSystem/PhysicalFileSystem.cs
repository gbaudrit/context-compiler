using ContextCompiler.Abstractions.Ports;

namespace ContextCompiler.Infrastructure.FileSystem;

public sealed class PhysicalFileSystem : IFileSystem
{
    public IEnumerable<string> EnumerateFiles(string rootPath)
    {
        return Directory.EnumerateFiles(rootPath, "*", SearchOption.AllDirectories);
    }

    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public Stream OpenRead(string path)
    {
        return File.OpenRead(path);
    }

    public string ReadAllText(string path)
    {
        return File.ReadAllText(path);
    }

    public void EnsureDirectory(string path)
    {
        _ = Directory.CreateDirectory(path);
    }

    public void EnsureDirectory(string path, bool clean)
    {
        if (clean && Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
        _ = Directory.CreateDirectory(path);
    }

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
