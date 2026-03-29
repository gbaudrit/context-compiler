namespace ContextCompiler.DevKit.TestFixtures;

public sealed class InMemoryArtifactStore
{
    private readonly Dictionary<string, byte[]> _blobs = [];
    public void Put(string key, byte[] bytes)
    {
        _blobs[key] = bytes;
    }

    public bool TryGet(string key, out byte[] bytes)
    {
        return _blobs.TryGetValue(key, out bytes!);
    }
}
