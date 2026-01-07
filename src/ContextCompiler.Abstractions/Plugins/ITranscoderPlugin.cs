using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Plugins;

public interface ITranscoderPlugin : IPlugin
{
    bool CanTranscode(IDataEnvelope envelope);
    Task<IReadOnlyList<TranscodedFragment>> TranscodeAsync(IDataEnvelope envelope, ISourceRef source, CancellationToken ct);
}

public sealed record TranscodedFragment(
    string Locator,
    string Content
) : ITranscodedFragment
{
    public List<ITag> Tags { get; init; } = new();
};
