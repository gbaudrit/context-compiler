namespace ContextCompiler.Abstractions.Files
{
    public interface IFileContentBuilder
    {
        IFileInfos Build();
        IFileContentBuilder InitNew();
        IFileContentBuilder WithReaderType<TReader>() where TReader : IFileReader;
        IFileContentBuilder WithMediaType(string mediaType);
        IFileContentBuilder WithMetadata(IReadOnlyDictionary<string, string>? metadata);
        IFileContentBuilder WithPath(string path);
    }
}
