using System.Text;

using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Core.ReasoningIR;
using ContextCompiler.Core.Services;

namespace ContextCompiler.Core.Pipelines
{
    public sealed class DocumentContext(ITagsBuilder tagsBuilder) : IDocumentContext
    {
        public required string InputRoot { get; init; }
        public required string RelativePath { get; init; } // stable path key
        public required string FullPath { get; init; }

        // Data flowing through passes (write-once-ish)
        public IFileReadResult? FileRead { get; private set; }


        private string? _content;
        public string Content { get => _content ??= Encoding.UTF8.GetString(FileRead?.Bytes ?? Array.Empty<byte>()) ?? string.Empty; init => _content = value; }
        public IDataEnvelope? Data { get; private set; }
        public IReadOnlyList<IFragment> Fragments => _fragments;
        public IReadOnlyList<ITag> Tags { get; private set; } = Array.Empty<ITag>();

        // Findings/events are append-only
        public IReadOnlyList<IPipelineFinding> Findings => _findings;

        private readonly List<IFragment> _fragments = new();
        private readonly List<IPipelineFinding> _findings = new();

        public void SetFileRead(IFileReadResult result) => FileRead = FileRead is null ? result : throw new InvalidOperationException("FileRead already set.");
        public void SetData(IDataEnvelope envelope) => Data = Data is null ? envelope : throw new InvalidOperationException("Data already set.");
        public void SetTags(IReadOnlyList<ITag> tags) => Tags = Tags is null ? tags : throw new InvalidOperationException("Tags already set.");

        public void AddFragment(IFragment f) => _fragments.Add(f);
        public void AddFinding(IPipelineFinding f) => _findings.Add(f);

        public IPipelineFinding AddFinding(FindingSeverity Severity, FindingAction Action, string PassId, string Message, ISourceRef? EvidenceRef = null)
        {
            var finding = new PipelineFinding(Severity, Action, PassId, Message, EvidenceRef);
            AddFinding(finding);
            return finding;
        }

        public void AddTags(IReadOnlyList<ITag> tags)
        {
            Tags = tagsBuilder.InitNewFrom(Tags).AddRange(tags).Build();
        }

        public void AddTags(string[] tags)
        {
            Tags = tagsBuilder.InitNewFrom(Tags).AddRange(tags).Build();
        }
    }
}
