using System.Text;

using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class TextFileReaderPlugin(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder) : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.text.reader", GlobalPipelinePluginKinds.FileReader, priority: 0);

    private static readonly HashSet<string> Extensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".md",".txt",".cs",".json",".yaml",".yml",".xml",".config",".sln",".csproj",".props"
    };

    public bool CanRead(string path) => Extensions.Contains(Path.GetExtension(path));

    public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var bytes = File.ReadAllBytes(path);
        var text = Encoding.UTF8.GetString(bytes);
        return Task.FromResult(fileReadResultBuilder.InitNew()
                                                    .WithContent(fileContentBuilder.InitNew()
                                                                                   .WithPath(path)
                                                                                   .WithMediaType("text/plain")
                                                                                   .WithReaderType<TextFileReader>()
                                                                                   .Build()).Build());
    }
}

public sealed class TextFileReader : IFileReader
{

    public ValueTask<Stream> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return ValueTask.FromResult<Stream>(File.OpenRead(path));
    }
}
