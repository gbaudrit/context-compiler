using ContextCompiler.Abstractions.Sources;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDocumentContext
    {
        IDocumentContextData Data { get; }
        //IFileReadResult? FileRead { get; }

        //public string Content { get; init; }


        string FullPath { get; init; }
        string InputRoot { get; init; }
        string RelativePath { get; init; }
        //IReadOnlyList<ITag> Tags { get; }
        ISource Source { get; init; }

        //IPipelineFinding AddFinding(FindingSeverity Severity,
        //                            FindingAction Action,
        //                            string PassId,
        //                            string Message,
        //                            ISourceRef? EvidenceRef = null);
        //void AddFragment(IFragment f);
        //void SetData(IDataEnvelope envelope);

        //void SetFileRead(IFileReadResult result);
        //void SetTags(IReadOnlyList<ITag> tags);
        //void AddTags(IReadOnlyList<ITag> tags);
        //void AddTags(string[] tags);

        //IFileInfos FileInfos { get; }
        //Task<IFileContent> GetContentReader();
        //Task<IFileContent> GetContentStream();

    }
}
