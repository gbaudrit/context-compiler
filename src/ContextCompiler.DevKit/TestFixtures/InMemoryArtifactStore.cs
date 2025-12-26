namespace ContextCompiler.DevKit.TestFixtures;

public sealed class InMemoryArtifactStore
{
    private readonly Dictionary<string, byte[]> _blobs = new();
    public void Put(string key, byte[] bytes) => _blobs[key] = bytes;
    public bool TryGet(string key, out byte[] bytes) => _blobs.TryGetValue(key, out bytes!);
}
