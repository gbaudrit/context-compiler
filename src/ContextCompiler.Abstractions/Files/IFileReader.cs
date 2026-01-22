namespace ContextCompiler.Abstractions.Files
{
    public interface IFileReader
    {
        ValueTask<Stream> ReadAsync(string path, CancellationToken ct);
    }
}
