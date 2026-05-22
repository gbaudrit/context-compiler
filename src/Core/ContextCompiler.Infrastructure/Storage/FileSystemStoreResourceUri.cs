using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Infrastructure.Storage;

internal sealed class FileSystemStoreResourceUri : IStoreResourceUri
{
    public required Uri Uri;

    public IStoreResourceUri Combine(string relativePath)
    {
        return new FileSystemStoreResourceUri
        {
            Uri = new Uri(Path.Combine(Uri.LocalPath, relativePath))
        };
    }

    public Task<bool> Exists()
    {
        return Task.FromResult(Path.Exists(Uri.LocalPath));
    }

    public string AbsolutePath => Uri.LocalPath;

}
