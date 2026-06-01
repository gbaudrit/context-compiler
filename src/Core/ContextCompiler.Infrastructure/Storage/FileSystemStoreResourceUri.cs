using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Infrastructure.Storage;

internal sealed class FileSystemStoreResourceUri : IStoreResourceUri
{
    public required Uri Uri;

    public IStoreResourceUri Combine(Uri relativeUri)
    {
        return new FileSystemStoreResourceUri
        {
            Uri = new Uri(Uri, relativeUri)
        };
    }

    public Task<bool> Exists()
    {
        return Task.FromResult(Path.Exists(Uri.LocalPath));
    }

    public string AbsolutePath => Uri.LocalPath;

    public string Name => Path.GetFileName(Uri.LocalPath);

    public Uri MakeRelativeOf(IStoreResourceUri storeResourceUri)
    {
        return storeResourceUri is FileSystemStoreResourceUri fsUri
            ? fsUri.Uri.MakeRelativeUri(Uri)
            : throw new InvalidOperationException("Incompatible URI type");
    }
}
