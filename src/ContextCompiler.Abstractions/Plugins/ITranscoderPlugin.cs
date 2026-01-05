using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Plugins;

public interface ITranscoderPlugin : IPlugin
{
    bool CanTranscode(DataEnvelope envelope);
    Task<IReadOnlyList<TranscodedFragment>> TranscodeAsync(DataEnvelope envelope, SourceRef source, CancellationToken ct);
}

public sealed record TranscodedFragment(
    string Locator,
    string Content
) : ITranscodedFragment
{
    public List<ITag> Tags { get; init; } = new();
};
