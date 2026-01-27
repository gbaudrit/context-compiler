using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDocumentContext
    {
        IDataEnvelope? Data { get; }
        //IFileReadResult? FileRead { get; }

        //public string Content { get; init; }

        IReadOnlyList<IPipelineFinding> Findings { get; }
        IReadOnlyList<IFragment> Fragments { get; }
        string FullPath { get; init; }
        string InputRoot { get; init; }
        string RelativePath { get; init; }
        IReadOnlyList<ITag> Tags { get; }

        IPipelineFinding AddFinding(FindingSeverity Severity,
                                    FindingAction Action,
                                    string PassId,
                                    string Message,
                                    ISourceRef? EvidenceRef = null);
        void AddFragment(IFragment f);
        void SetData(IDataEnvelope envelope);
        //void SetFileRead(IFileReadResult result);
        void SetTags(IReadOnlyList<ITag> tags);
        void AddTags(IReadOnlyList<ITag> tags);
        void AddTags(string[] tags);

        //IFileInfos FileInfos { get; }
        //Task<IFileContent> GetContentReader();
        //Task<IFileContent> GetContentStream();

    }
}
