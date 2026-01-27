namespace ContextCompiler.Abstractions.Files
{
    public interface IFileReader
    {
        ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct);
    }
}
