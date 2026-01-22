using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class MarkdownFileReaderPlugin(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder) : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.markdown.reader", GlobalPipelinePluginKinds.FileReader, priority: 9);

    public bool CanRead(string path)
    {
        var ext = Path.GetExtension(path);
        return ext.Equals(".md", StringComparison.OrdinalIgnoreCase) || ext.Equals(".markdown", StringComparison.OrdinalIgnoreCase);
    }

    public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var stream = File.OpenRead(path);
        return Task.FromResult(fileReadResultBuilder.InitNew()
                                                    .WithContent(fileContentBuilder.InitNew()
                                                                                   .WithPath(path)
                                                                                   .WithMediaType("text/markdown")
                                                                                   .WithReaderType<MarkdownFileReader>()
                                                                                   .Build()).Build());
    }
}

public sealed class MarkdownFileReader : IFileReader
{

    public ValueTask<Stream> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return ValueTask.FromResult<Stream>(File.OpenRead(path));
    }
}
