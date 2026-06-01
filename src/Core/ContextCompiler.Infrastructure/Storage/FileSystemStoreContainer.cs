using System.Text;

using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Infrastructure.Storage;

internal sealed class FileSystemStoreContainer(IStoreResourceUri uri) : IStoreContainer
{

    public IStoreResourceUri Uri => uri;

    public IStoreResource GetResource(string relativePath)
    {
        return new FileSystemStoreResource
        {
            Uri = Uri.Combine(new Uri(relativePath, UriKind.Relative)),
            Encoding = Encoding.UTF8
        };
    }

    public IReadOnlyList<IStoreResource> GetResources(string filter, bool recursive)
    {
        return Directory.GetFiles(Uri.AbsolutePath, filter, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
            .Select(file => new FileSystemStoreResource
            {
                Uri = new FileSystemStoreResourceUri { Uri = new Uri(Path.Combine(Uri.AbsolutePath, file)) },
                Encoding = Encoding.UTF8
            })
            .ToList();
    }

    public bool Exists()
    {
        return Directory.Exists(Uri.AbsolutePath);
    }

    public IStoreContainer CreateContainer(string name)
    {
        string path = Path.Combine(Uri.AbsolutePath, name);
        _ = Directory.CreateDirectory(path);
        return new FileSystemStoreContainer(new FileSystemStoreResourceUri { Uri = new Uri(path + "/") });
    }
}
