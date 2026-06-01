using System.Text;

using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Infrastructure.Storage;

internal sealed class FileSystemStoreResource : IStoreResource
{
    public required Encoding Encoding { get; init; }
    public required IStoreResourceUri Uri { get; init; }


    public Stream CreateStream()
    {
        return new FileStream(
                Uri.AbsolutePath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.Read);
    }

    public Stream CreateStreamForRead()
    {
        return new FileStream(
                Uri.AbsolutePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);
    }

    public StreamWriter CreateWriter()
    {
        return new StreamWriter(
                new FileStream(
                    Uri.AbsolutePath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.Read),
                Encoding);
    }

    public Task<bool> Exists()
    {
        return Task.FromResult(File.Exists(Uri.AbsolutePath) || Directory.Exists(Uri.AbsolutePath));
    }

    public Task<string[]> ReadAllLines(CancellationToken cancellationToken)
    {
        return File.ReadAllLinesAsync(Uri.AbsolutePath, Encoding, cancellationToken);
    }

    public Task<string> ReadAllText(CancellationToken cancellationToken)
    {
        return File.ReadAllTextAsync(Uri.AbsolutePath, Encoding, cancellationToken);
    }
    public Task<byte[]> ReadAllBytes(CancellationToken cancellationToken)
    {
        return File.ReadAllBytesAsync(Uri.AbsolutePath, cancellationToken);
    }

    public Task WriteAllText(string content, CancellationToken cancellationToken)
    {
        string? directoryPath = Path.GetDirectoryName(Uri.AbsolutePath);
        if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
        {
            _ = Directory.CreateDirectory(directoryPath);
        }
        return File.WriteAllTextAsync(Uri.AbsolutePath, content, Encoding, cancellationToken);
    }
}
