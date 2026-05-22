using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Core.Storage;

internal sealed record StoreResourceUri(Uri Uri) : IStoreResourceUri
{
    public string AbsolutePath => Uri.AbsolutePath;

    public IStoreResourceUri Combine(string relativePath)
    {
        throw new NotImplementedException();
    }
}
