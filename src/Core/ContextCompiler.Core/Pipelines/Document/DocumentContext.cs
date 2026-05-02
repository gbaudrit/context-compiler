using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Sources;

namespace ContextCompiler.Core.Pipelines.Document
{
    public sealed class DocumentContext() : IDocumentContext
    {
        public required string InputRoot { get; init; }
        public required string RelativePath { get; init; } // stable path key
        public required string FullPath { get; init; }
        public required ISource Source { get; init; }

        public required IDocumentContextData Data { get; init; }



        //public void SetFileRead(IFileReadResult result) => FileRead = FileRead is null ? result : throw new InvalidOperationException("FileRead already set.");


        //public void AddFragment(IFragment f)
        //{
        //    Data = documentContextDataBuilder.InitFrom(Data).WithFragments(Data.Fragments.Concat([f])).Build();
        //}

        //public void AddFinding(IPipelineFinding f)
        //{
        //    Data = documentContextDataBuilder.InitFrom(Data).WithFindings(Data.Findings.Concat([f])).Build();
        //}

        //public IPipelineFinding AddFinding(FindingSeverity Severity, FindingAction Action, string PassId, string Message, ISourceRef? EvidenceRef = null)
        //{
        //    PipelineFinding finding = new(Severity, Action, PassId, Message, EvidenceRef);
        //    AddFinding(finding);
        //    return finding;
        //}

        //public void AddTags(IReadOnlyList<ITag> tags)
        //{
        //    Data = documentContextDataBuilder.InitFrom(Data)
        //                                     .WithTags(Data.Tags.Concat(tags))
        //                                     .Build();
        //}

        //public void AddTags(string[] tags)
        //{
        //    Data = documentContextDataBuilder.InitFrom(Data)
        //                                     .WithTags(Data.Tags.Concat(tagsBuilder.AddRange(tags).Build())).Build();
        //}

        //public async Task<IFileContent> GetContentReader()
        //{
        //    ArgumentNullException.ThrowIfNull(FileRead, nameof(FileRead));

        //    var fileReader = (IFileReader)serviceProvider.GetRequiredService(FileRead.Content.ReaderType);
        //    return await fileReader.ReadAsync(FileRead.Content.Path, CancellationToken.None);
        //}

        //public async Task<IFileContent> GetContentStream()
        //{
        //    ArgumentNullException.ThrowIfNull(FileRead, nameof(FileRead));

        //    var fileReader = (IFileReader)serviceProvider.GetRequiredService(FileRead.Content.ReaderType);
        //    return await fileReader.ReadAsync(FileRead.Content.Path, CancellationToken.None);
        //}

        //public IDocumentContextDataPatchBuilder PatchBuilder => documentContextDataPatchBuilder;
    }
}
