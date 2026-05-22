namespace ContextCompiler.Abstractions.Storage;

public interface IStoreResource
{
    Task<bool> Exists();

    IStoreResourceUri Uri { get; }

    StreamWriter CreateWriter();

    Stream CreateStream();

    Task<string> ReadAllText(CancellationToken cancellationToken);
    Task<string[]> ReadAllLines(CancellationToken cancellationToken);
    Stream CreateStreamForRead();

    Task WriteAllText(string content, CancellationToken cancellationToken);

}
