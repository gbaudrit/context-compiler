using ContextCompiler.Abstractions.Storage;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Infrastructure.Storage;

internal sealed class FileSystemStore([ServiceKey] string key, IServiceProvider services) : IStore
{
    private readonly IStoreConfiguration _storeConfiguration = services.GetRequiredKeyedService<IStoreConfiguration>(key);

    public string Key { get; } = key;

    public IStoreResourceUri Uri => _storeConfiguration.Uri;

    public IStoreContainer Container => new FileSystemStoreContainer(Uri);

    public IStoreResourceUri Combine(Uri relativeUri)
    {
        return Uri.Combine(relativeUri);
    }

    public bool Contains(string relativePath)
    {
        return File.Exists(Path.Combine(Uri.AbsolutePath, relativePath)) || Directory.Exists(Path.Combine(Uri.AbsolutePath, relativePath));
    }

    public bool Contains(IStoreResourceUri uri)
    {
        return File.Exists(uri.AbsolutePath) || Directory.Exists(uri.AbsolutePath);
    }

    public IStoreContainer CreateContainer(string name)
    {
        if (!Directory.Exists(Path.Combine(Uri.AbsolutePath, name)))
        {
            _ = Directory.CreateDirectory(Path.Combine(Uri.AbsolutePath, name));
        }
        return new FileSystemStoreContainer(Combine(new Uri(name, UriKind.Relative)));
    }

    public IStoreContainer CreateContainer(Uri relativeUri)
    {
        IStoreResourceUri absoluteUri = Combine(relativeUri);
        if (!Directory.Exists(absoluteUri.AbsolutePath))
        {
            _ = Directory.CreateDirectory(absoluteUri.AbsolutePath);
        }
        return new FileSystemStoreContainer(absoluteUri);
    }


    public IStoreContainer GetContainer(string relativePath)
    {
        return new FileSystemStoreContainer(Combine(new Uri(relativePath, UriKind.Relative)));
    }

    public bool Exists()
    {
        return Directory.Exists(Uri.AbsolutePath);
    }

    public IStoreContainer GetContainer(Uri relativeUri)
    {
        return new FileSystemStoreContainer(Combine(relativeUri));
    }

    public Task Init()
    {
        if (!Exists())
        {
            _ = Directory.CreateDirectory(Uri.AbsolutePath);
        }
        return Task.CompletedTask;
    }

}
