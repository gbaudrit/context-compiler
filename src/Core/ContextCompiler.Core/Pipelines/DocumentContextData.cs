using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.Pipelines;

internal sealed class DocumentContextData : IDocumentContextData
{
    //// Data flowing through passes (write-once-ish)
    //public IFileReadResult? FileRead { get; private set; }

    //public IFileInfos FileInfos => FileRead?.Content ?? throw new InvalidOperationException("FileRead not set.");
    //private string? _content;
    //public string Content { get => _content ??= Encoding.UTF8.GetString(FileRead?.Bytes ?? Array.Empty<byte>()) ?? string.Empty; init => _content = value; }
    public required IDataEnvelope DataEnvelope { get; init; }
    public required IReadOnlyList<IFragment> Fragments { get; init; }
    public required IReadOnlyList<ITag> Tags { get; init; }
    // Findings/events are append-only
    public required IReadOnlyList<IPipelineFinding> Findings { get; init; }

}
