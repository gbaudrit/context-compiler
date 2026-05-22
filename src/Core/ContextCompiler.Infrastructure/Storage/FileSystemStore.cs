using System.Text;

using ContextCompiler.Abstractions.Storage;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Infrastructure.Storage;

internal sealed class FileSystemStore([ServiceKey] string key, IServiceProvider services) : IStore
{
    private readonly IStoreConfiguration _storeConfiguration = services.GetRequiredKeyedService<IStoreConfiguration>(key);

    public string Key { get; } = key;

    public IStoreResourceUri Uri => _storeConfiguration.Root;

    public IStoreResourceUri Combine(string relativePath)
    {
        return Uri.Combine(relativePath);
    }

    public bool Contains(string relativePath)
    {
        return File.Exists(Path.Combine(Uri.AbsolutePath, relativePath)) || Directory.Exists(Path.Combine(Uri.AbsolutePath, relativePath));
    }

    public bool Contains(IStoreResourceUri uri)
    {
        return File.Exists(uri.AbsolutePath) || Directory.Exists(uri.AbsolutePath);
    }

    public IStore CreateContainer(string relativePath)
    {
        if (!Directory.Exists(Path.Combine(Uri.AbsolutePath, relativePath)))
        {
            _ = Directory.CreateDirectory(Path.Combine(Uri.AbsolutePath, relativePath));
        }
        return new FileSystemStore(Path.Combine(Uri.AbsolutePath, relativePath), services);
    }



    public IStore GetContainer(string relativePath)
    {
        return new FileSystemStore(Path.Combine(Uri.AbsolutePath, relativePath), services);
    }

    public IStoreResource GetResource(string relativePath)
    {
        return new FileSystemStoreResource
        {
            Uri = Uri.Combine(relativePath),
            Encoding = Encoding.UTF8
        };
    }
}
